using NetCord.Services.Commands;

namespace DiceBot.Drivers.Adapters.Discord;

public class Commands : CommandModule<CommandContext>
{
    [Command("roll")]
    public async Task<string> RollDice(string expression)
    {
        return expression;
    }
    
    [Command("ping")]
    public string Ping() => $"Pong! {Math.Round(Context.Client.Latency.TotalMilliseconds)} ms";
}