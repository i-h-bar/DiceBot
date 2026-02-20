using DiceBot.Domain;
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
    public string Ping()
    {
        return $"Pong! {Math.Round(Context.Client.Latency.TotalMilliseconds)} ms";
    }
}

public class SlashCommands : ApplicationCommandModule<ApplicationCommandContext>
{
    [SlashCommand("roll", "roll a dice expression")]
    public string RollDice(
        [SlashCommandParameter(Name = "expression", Description = "Roll expression e.g '2d6'")]
        string expression,
        [SlashCommandParameter(Name = "modifier", Description = "Roll modifier like advantage etc..")]
        DiceModifier modifier = DiceModifier.Normal
    )
    {
        return $"{expression} {modifier.ToString()}";
        ;
    }

    [SlashCommand("ping", "pong")]
    public string Ping()
    {
        return $"Pong! {Math.Round(Context.Client.Latency.TotalMilliseconds)} ms";
    }
}