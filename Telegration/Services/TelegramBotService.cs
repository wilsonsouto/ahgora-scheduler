using DotNetEnv;
using Telegram.Bot;

namespace Telegration.Services
{
    public class TelegramBotService
    {
        public static async Task Run()
        {
            var token = GetToken();

            if (string.IsNullOrEmpty(token))
                return;

            var bot = new TelegramBotClient(token);
            var me = await bot.GetMe();
            Console.Clear();
            Console.WriteLine($"Bot '{me.FirstName}' it is running...");

            await Task.Delay(-1);
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
