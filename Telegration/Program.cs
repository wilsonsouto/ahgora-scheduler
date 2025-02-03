using Telegration.Services;

internal class Program
{
    [Obsolete]
    private static async Task Main(string[] args) => await TelegramBotService.Run();
};
