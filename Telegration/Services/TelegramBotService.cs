using DotNetEnv;

namespace Telegration.Services
{
    public class TelegramBotService
    {
        public static string GetToken()
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
