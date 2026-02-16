using DiceBot.Domain;

namespace DiceBot.Tests.Domain;

[TestFixture]
public class RollResultTests
{
    [Test]
    public void TestAddResults()
    {
        var a = new RollResult(dice: "1d6", result: 3);
        var b = new RollResult(dice: "1d4", result: 2);

        var sum = a + b;

        Assert.That(sum.Total, Is.EqualTo(5));
        Assert.That(sum.Expression, Is.EqualTo("(1d6) 3 + (1d4) 2"));
    }
    
    [Test]
    public void TestAddResultsNullDice()
    {
        var a = new RollResult(dice: "1d6", result: 3);
        var b = new RollResult(dice: null, result: 7);

        var sum = a + b;

        Assert.That(sum.Total, Is.EqualTo(10));
        Assert.That(sum.Expression, Is.EqualTo("(1d6) 3 + 7"));
    }
    
    [Test]
    public void TestAddResultsToResultCollection()
    {
        var a = new RollResult(dice: "1d6", result: 3);
        var b = new RollResult(dice: null, result: 7);
        var c = new RollResult(dice: "1d8", result: 2);

        var sum = a + b;
        sum += c;

        Assert.That(sum.Total, Is.EqualTo(12));
        Assert.That(sum.Expression, Is.EqualTo("(1d6) 3 + 7 + (1d8) 2"));
    }

    [Test]
    public void TestAddResultsCollectionToString()
    {
        var a = new RollResult(dice: "1d6", result: 3);
        var b = new RollResult(dice: "1d4", result: 2);

        var sum = a + b;

        Assert.That(sum.ToString(), Is.EqualTo("(1d6) 3 + (1d4) 2 = 5"));
    }
}