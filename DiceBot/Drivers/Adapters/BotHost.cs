using DiceBot.Drivers.Ports;
using DiceBot.Drivers.Adapters.Discord;

namespace DiceBot.Drivers.Adapters;

public static class BotHost
{
    public static IBotHost GetHost()
    {
        return new DiscordHost();
    }
}