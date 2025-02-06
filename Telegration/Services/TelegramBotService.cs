using DotNetEnv;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Telegration.Services
{
    public class TelegramBotService
    {
        private static int lastUpdateId = 0;

        [Obsolete]
        public static async Task Run()
        {
            var token = GetToken();

            if (string.IsNullOrEmpty(token))
                return;

            var bot = new TelegramBotClient(token);
            var me = await bot.GetMe();
            var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions { AllowedUpdates = [] };

            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cts.Token);

            Console.Clear();
            Console.WriteLine($"Bot '{me.FirstName}' it is running...");

            await Task.Delay(-1);
        }

        [Obsolete]
        private static async Task HandleUpdateAsync(
            ITelegramBotClient bot,
            Update update,
            CancellationToken cancellationToken
        )
        {
            if (update.Message is not { } message || message.Text is not { } messageText)
                return;

            // If the update has already been processed, ignore it
            if (update.Id <= lastUpdateId)
                return;

            lastUpdateId = update.Id; // Update the last processed update

            Console.WriteLine($"Message received: {messageText}");

            if (messageText.Contains("registerpoint", StringComparison.OrdinalIgnoreCase))
            {
                await RegisterPointAsync(bot, message.Chat.Id, cancellationToken);
            }
        }

        private static Task HandleErrorAsync(
            ITelegramBotClient botClient,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            Console.WriteLine($"Error: {exception.Message}");
            return Task.CompletedTask;
        }

        private static async Task RegisterPointAsync(
            ITelegramBotClient bot,
            long chatId,
            CancellationToken cancellationToken
        )
        {
            Env.Load();
            var siteUrl = Environment.GetEnvironmentVariable("SITE_URL");
            var registration = Environment.GetEnvironmentVariable("USER_REGISTRATION");
            var password = Environment.GetEnvironmentVariable("USER_PASSWORD");

            using var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(siteUrl);

            IWebElement rootButton = driver.FindElement(By.Id("root"));
            rootButton.Click();

            IWebElement registrationField = driver.FindElement(By.Id("outlined-basic-account"));
            registrationField.SendKeys(registration);

            IWebElement passwordField = driver.FindElement(By.Id("outlined-basic-password"));
            passwordField.SendKeys(password);

            IWebElement advanceButton = driver.FindElement(By.XPath("//button[.//p[text()='Advance']]"));
            advanceButton.Click();

            IWebElement clockInButton = driver.FindElement(By.XPath("//button[.//p[text()='Clocking in']]"));
            clockInButton.Click();

            await bot.SendMessage(
                chatId: chatId,
                text: "Your point has been registered!",
                cancellationToken: cancellationToken
            );
        }

        private static string GetToken()
        {
            try
            {
                Env.Load();
                var token = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN");

                if (!string.IsNullOrEmpty(token))
                    return token;

                throw new Exception("Token does not exist! Verify your .env file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
    }
}
