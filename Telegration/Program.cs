using Telegration.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await TelegramBotService.Run();
    }
};
