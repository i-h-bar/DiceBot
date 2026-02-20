using DiceBot.Drivers.Ports;
using Microsoft.Extensions.Hosting;
using NetCord.Gateway;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services;
using NetCord.Hosting.Services.ApplicationCommands;
using NetCord.Hosting.Services.Commands;

namespace DiceBot.Drivers.Adapters.Discord;

internal class DiscordHost : IBotHost
{
    private IHost? Host { get; set; }

    public async Task Init(string[] args)
    {
        var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(args);

        builder.Services
            .AddDiscordGateway(options =>
                {
                    options.Intents = GatewayIntents.GuildMessages |
                                      GatewayIntents.DirectMessages |
                                      GatewayIntents.MessageContent;
                }
            )
            .AddCommands()
            .AddApplicationCommands();

        Host = builder.Build();

        Host.AddModules(typeof(Program).Assembly);
    }

    public async Task RunAsync()
    {
        if (Host is not null) await Host.RunAsync();
    }
}