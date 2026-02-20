namespace DiceBot.Domain.Dice;


public interface IDice<out T> where T: IResult<T>
{
    T Roll();
}