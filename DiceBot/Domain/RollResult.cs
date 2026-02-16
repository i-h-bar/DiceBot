namespace DiceBot.Domain;

internal delegate int Operation(int a, int b);


internal static class Maths
{
    internal static int Add(int x, int y) => x + y;
    internal static int Sub(int x, int y) => x - y;
    internal static int Mul(int x, int y) => x * y;
    internal static int Div(int x, int y) => x / y;

    public static string GetRepr(Operation operation) => operation switch                                                                                                                                                                                                                                            
    {
        _ when operation == Add => "+",                                                                                                                                                                                                                                                                              
        _ when operation == Sub => "-",
        _ when operation == Mul => "*",
        _ when operation == Div => "/",
        _ => throw new InvalidOperationException($"Operation {operation} is not supported.")
    };

}

public class RollResult
{
    public RollResult(string? dice, int result)
    {
        _dice = dice;
        _result = result;
    }
    
    private readonly string? _dice;
    private readonly int _result;
    
    public override string ToString()
    {
        return _dice is not null ? $"({_dice}) {_result}" : _result.ToString();
    }

    public static ResultCollection operator +(RollResult a, RollResult b)
    {
        return new ResultCollection(expression: $"{a} + {b}", total: a._result + b._result);
    }

    public static ResultCollection operator +(RollResult a, ResultCollection b) => CalculateResult(a, b, Maths.Add);
    public static ResultCollection operator +(ResultCollection a, RollResult b) => CalculateResult(b, a, Maths.Add);

    private static ResultCollection CalculateResult(RollResult a, ResultCollection b, Operation operation)
    {
        return new ResultCollection($"{b.Expression} {Maths.GetRepr(operation)} {a}", operation(a._result, b.Total));
    }
}


public class ResultCollection
{
    public ResultCollection(string expression, int total)
    {
        Expression = expression;
        Total = total;
    }
    
    public readonly string Expression;
    public readonly int Total;
    
    public override string ToString()
    {
        return $"{Expression} = {Total}";
    }
}