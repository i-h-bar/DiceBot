using DiceBot.Drivers.Adapters.Discord;
using DiceBot.Drivers.Ports;

namespace DiceBot.Drivers.Adapters;

public static class BotHost
{
    public static IBotHost GetHost()
    {
        return new DiscordHost();
    }
}