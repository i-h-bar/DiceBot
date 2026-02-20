using DiceBot.Drivers.Adapters;

internal class Program
{
    public static async Task Main(string[] args)
    {
        var host = BotHost.GetHost();
        await host.Init(args);
        await host.RunAsync();
    }
}