namespace DiceBot.Domain.Dice.Standard;


internal class Operation                                                                                                                                                                                                                                                                                         
{
    private readonly Func<int, int, int> _func;                                                                                                                                                                                                                                                                  
    private readonly string _repr;

    private Operation(Func<int, int, int> func, string repr)
    {
        _func = func;
        _repr = repr;
    }

    public int Invoke(int x, int y) => _func(x, y);
    public override string ToString() => _repr;

    public static readonly Operation Add = new((x, y) => x + y, "+");
    public static readonly Operation Sub = new((x, y) => x - y, "-");
    public static readonly Operation Mul = new((x, y) => x * y, "*");
    public static readonly Operation Div = new((x, y) => x / y, "/");
}


public class RollResult
{
    public RollResult(string? repr, int result)
    {
        Repr = repr;
        Result = result;
    }
    
    public readonly string? Repr;
    public readonly int Result;
    
    public override string ToString()
    {
        return Repr is not null ? $"({Repr}) {Result}" : Result.ToString();
    }

    public static ResultCollection operator +(RollResult a, RollResult b) => CalculateResult(a, b, Operation.Add);
    public static ResultCollection operator +(RollResult a, ResultCollection b) => CalculateResult(a, b, Operation.Add);
    public static ResultCollection operator +(ResultCollection a, RollResult b) => CalculateResult(b, a, Operation.Add);
    public static ResultCollection operator -(RollResult a, RollResult b) => CalculateResult(a, b, Operation.Sub);
    public static ResultCollection operator -(RollResult a, ResultCollection b) => CalculateResult(a, b, Operation.Sub);
    public static ResultCollection operator -(ResultCollection a, RollResult b) => CalculateResult(b, a, Operation.Sub);
    public static ResultCollection operator *(RollResult a, RollResult b) => CalculateResult(a, b, Operation.Mul);
    public static ResultCollection operator *(RollResult a, ResultCollection b) => CalculateResult(a, b, Operation.Mul);
    public static ResultCollection operator *(ResultCollection a, RollResult b) => CalculateResult(b, a, Operation.Mul);
    public static ResultCollection operator /(RollResult a, RollResult b) => CalculateResult(a, b, Operation.Div);
    public static ResultCollection operator /(RollResult a, ResultCollection b) => CalculateResult(a, b, Operation.Div);
    public static ResultCollection operator /(ResultCollection a, RollResult b) => CalculateResult(b, a, Operation.Div);
    
    private static ResultCollection CalculateResult(RollResult a, RollResult b, Operation operation)
    {
        return new ResultCollection(expression: $"{a} {operation} {b}", total: operation.Invoke(a.Result, b.Result));
    }
    
    private static ResultCollection CalculateResult(RollResult a, ResultCollection b, Operation operation)
    {
        return new ResultCollection($"{b.Expression} {operation} {a}", operation.Invoke(b.Total, a.Result));
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
    
    public static ResultCollection operator +(ResultCollection a, ResultCollection b) => CalculateResult(a, b, Operation.Add);
    public static ResultCollection operator -(ResultCollection a, ResultCollection b) => CalculateResult(a, b, Operation.Sub);
    public static ResultCollection operator *(ResultCollection a, ResultCollection b) => CalculateResult(a, b, Operation.Mul);
    public static ResultCollection operator /(ResultCollection a, ResultCollection b) => CalculateResult(a, b, Operation.Div);
    
    private static ResultCollection CalculateResult(ResultCollection a, ResultCollection b, Operation operation)
    {
        return new ResultCollection($"({a.Expression}) {operation} ({b.Expression})", operation.Invoke(a.Total, b.Total));
    }
}