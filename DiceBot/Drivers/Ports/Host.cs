namespace DiceBot.Drivers.Ports;

public interface IBotHost

{
    public Task Init(string[] args);
    public Task RunAsync();
}