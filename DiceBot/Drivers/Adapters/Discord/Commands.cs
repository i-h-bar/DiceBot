using NetCord.Services.ApplicationCommands;
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

public class SlashCommands : ApplicationCommandModule<ApplicationCommandContext>
{
    [SlashCommand("roll", "roll a dice expression")]
    public async Task<string> RollDice(string expression)
    {
        return expression;
    }
    
    [SlashCommand("ping", "pong")]
    public string Ping() => $"Pong! {Math.Round(Context.Client.Latency.TotalMilliseconds)} ms";
}