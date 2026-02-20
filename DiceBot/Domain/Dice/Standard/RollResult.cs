namespace DiceBot.Domain.Dice.Standard;

internal class Operation
{
    public static readonly Operation Add = new((x, y) => x + y, "+");
    public static readonly Operation Sub = new((x, y) => x - y, "-");
    public static readonly Operation Mul = new((x, y) => x * y, "*");
    public static readonly Operation Div = new((x, y) => x / y, "/");
    private readonly Func<int, int, int> _func;
    private readonly string _repr;

    private Operation(Func<int, int, int> func, string repr)
    {
        _func = func;
        _repr = repr;
    }

    public int Invoke(int x, int y)
    {
        return _func(x, y);
    }

    public override string ToString()
    {
        return _repr;
    }
}

public class RollResult : IResult<RollResult>
{
    public readonly string? Repr;
    public readonly int Result;

    public RollResult(string? repr, int result)
    {
        Repr = repr;
        Result = result;
    }

    public string FormatResult()
    {
        return $"{Repr} = {Result}";
    }
    
    public override string ToString()
    {
        return Repr ?? Result.ToString();
    }

    public static RollResult operator +(RollResult a, RollResult b)
    {
        return CalculateResult(a, b, Operation.Add);
    }
    
    public static RollResult operator -(RollResult a, RollResult b)
    {
        return CalculateResult(a, b, Operation.Sub);
    }

    public static RollResult operator *(RollResult a, RollResult b)
    {
        return CalculateResult(a, b, Operation.Mul);
    }
    
    public static RollResult operator /(RollResult a, RollResult b)
    {
        return CalculateResult(a, b, Operation.Div);
    }

    private static RollResult CalculateResult(RollResult a, RollResult b, Operation operation)
    {
        var repr = operation switch
        {
            _ when operation == Operation.Mul || operation == Operation.Div => $"({a.Repr}) {operation} {b}",
            _ => $"{a} {operation} {b}",
        };
        
        return new RollResult(repr, operation.Invoke(a.Result, b.Result));
    }
}
