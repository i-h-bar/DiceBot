using DiceBot.Domain.Dice.Standard;

namespace DiceBot.Tests.Domain.Dice.Standard;

[TestFixture]
public class DiceTests
{
    [Test]
    public void TestDiceString()
    {
        var dice = new StandardDice(6, 2);
        
        Assert.That(dice.ToString(), Is.EqualTo("2d6"));
    }
    
    [Test]
    public void TestSingleDiceString()
    {
        var dice = new StandardDice(6, 1);
        
        Assert.That(dice.ToString(), Is.EqualTo("d6"));
    }
    
    [Test]
    public void TestRoll()
    {
        var dice = new StandardDice(6, 2);

        for (var i = 0; i < 1000; i++)
        {
            var result = dice.Roll();
            Assert.That(result.Result, Is.LessThan(13));
            Assert.That(result.Result, Is.GreaterThan(0));
        }
    }
    
    [Test]
    public void TestSingleRoll()
    {
        var dice = new StandardDice(6, 1);

        for (var i = 0; i < 1000; i++)
        {
            var result = dice.Roll();
            Assert.That(result.Result, Is.LessThan(7));
            Assert.That(result.Result, Is.GreaterThan(0));
        }
    }
}