namespace DiceBot.Domain.Dice.Standard;

public class StandardDice(int type, int amount) : IDice<RollResult>
{
    private readonly int _upperBound = type + 1;

    private string Format(int result)
    {
        return $"({ToString()}) {result}";
    }
    
    public override string ToString()
    {
        var diceAmount = amount > 1 ? amount.ToString() : "";
        return $"{diceAmount}d{type}";
    }

    public RollResult Roll()
    {
        var result = 0;
        var random = new Random();
        for (var i = 0; i < amount; i++) result += random.Next(1, _upperBound);

        return new RollResult(Format(result), result);
    }
}