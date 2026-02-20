namespace DiceBot.Domain.Dice;

public interface IResult<T> where T : IResult<T>
{
    static abstract T operator +(T a, T b);
    static abstract T operator -(T a, T b);
    static abstract T operator *(T a, T b);
    static abstract T operator /(T a, T b);
}