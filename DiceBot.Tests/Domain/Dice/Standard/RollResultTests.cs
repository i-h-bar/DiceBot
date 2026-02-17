using DiceBot.Domain.Dice.Standard;

namespace DiceBot.Tests.Domain.Dice.Standard;

[TestFixture]
public class RollResultTests
{
    [Test]
    public void TestAddResults()
    {
        var a = new RollResult(repr: "1d6", result: 3);
        var b = new RollResult(repr: "1d4", result: 2);

        var sum = a + b;

        Assert.That(sum.Total, Is.EqualTo(5));
        Assert.That(sum.Expression, Is.EqualTo("(1d6) 3 + (1d4) 2"));
    }
    
    [Test]
    public void TestAddResultsNullDice()
    {
        var a = new RollResult(repr: "1d6", result: 3);
        var b = new RollResult(repr: null, result: 7);

        var sum = a + b;

        Assert.That(sum.Total, Is.EqualTo(10));
        Assert.That(sum.Expression, Is.EqualTo("(1d6) 3 + 7"));
    }
    
    [Test]
    public void TestAddResultsToResultCollection()
    {
        var a = new RollResult(repr: "1d6", result: 3);
        var b = new RollResult(repr: null, result: 7);
        var c = new RollResult(repr: "1d8", result: 2);

        var sum = a + b;
        sum += c;

        Assert.That(sum.Total, Is.EqualTo(12));
        Assert.That(sum.Expression, Is.EqualTo("(1d6) 3 + 7 + (1d8) 2"));
    }
    
    [Test]
    public void TestAddResultsCollectionToResultCollection()
    {
        var a = new RollResult(repr: "1d6", result: 3);
        var b = new RollResult(repr: null, result: 7);
        var c = new RollResult(repr: "1d8", result: 2);
        var d = new RollResult(repr: "1d10", result: 5);

        var sum = a + b;
        var sum2 = c + d;
        var sum3 = sum + sum2;

        Assert.That(sum3.Total, Is.EqualTo(17));
        Assert.That(sum3.Expression, Is.EqualTo("((1d6) 3 + 7) + ((1d8) 2 + (1d10) 5)"));
    }

    [Test]
    public void TestAddResultsCollectionToString()
    {
        var a = new RollResult(repr: "1d6", result: 3);
        var b = new RollResult(repr: "1d4", result: 2);

        var sum = a + b;

        Assert.That(sum.ToString(), Is.EqualTo("(1d6) 3 + (1d4) 2 = 5"));
    }

    [Test]
    public void TestSubResults()
    {
        var a = new RollResult(repr: "1d6", result: 5);
        var b = new RollResult(repr: "1d4", result: 2);

        var result = a - b;

        Assert.That(result.Total, Is.EqualTo(3));
        Assert.That(result.Expression, Is.EqualTo("(1d6) 5 - (1d4) 2"));
    }

    [Test]
    public void TestSubResultsNullDice()
    {
        var a = new RollResult(repr: "1d6", result: 10);
        var b = new RollResult(repr: null, result: 3);

        var result = a - b;

        Assert.That(result.Total, Is.EqualTo(7));
        Assert.That(result.Expression, Is.EqualTo("(1d6) 10 - 3"));
    }

    [Test]
    public void TestSubResultsToResultCollection()
    {
        var a = new RollResult(repr: "1d6", result: 10);
        var b = new RollResult(repr: null, result: 3);
        var c = new RollResult(repr: "1d8", result: 2);

        var result = a - b;
        result -= c;

        Assert.That(result.Total, Is.EqualTo(5));
        Assert.That(result.Expression, Is.EqualTo("(1d6) 10 - 3 - (1d8) 2"));
    }

    [Test]
    public void TestSubResultsCollectionToResultCollection()
    {
        var a = new RollResult(repr: "1d6", result: 10);
        var b = new RollResult(repr: null, result: 3);
        var c = new RollResult(repr: "1d8", result: 8);
        var d = new RollResult(repr: "1d4", result: 2);

        var result1 = a - b;
        var result2 = c - d;
        var result3 = result1 - result2;

        Assert.That(result3.Total, Is.EqualTo(1));
        Assert.That(result3.Expression, Is.EqualTo("((1d6) 10 - 3) - ((1d8) 8 - (1d4) 2)"));
    }

    [Test]
    public void TestMulResults()
    {
        var a = new RollResult(repr: "1d6", result: 3);
        var b = new RollResult(repr: "1d4", result: 4);

        var result = a * b;

        Assert.That(result.Total, Is.EqualTo(12));
        Assert.That(result.Expression, Is.EqualTo("(1d6) 3 * (1d4) 4"));
    }

    [Test]
    public void TestMulResultsNullDice()
    {
        var a = new RollResult(repr: "1d6", result: 5);
        var b = new RollResult(repr: null, result: 3);

        var result = a * b;

        Assert.That(result.Total, Is.EqualTo(15));
        Assert.That(result.Expression, Is.EqualTo("(1d6) 5 * 3"));
    }

    [Test]
    public void TestMulResultsToResultCollection()
    {
        var a = new RollResult(repr: "1d6", result: 2);
        var b = new RollResult(repr: null, result: 3);
        var c = new RollResult(repr: "1d4", result: 4);

        var result = a * b;
        result *= c;

        Assert.That(result.Total, Is.EqualTo(24));
        Assert.That(result.Expression, Is.EqualTo("(1d6) 2 * 3 * (1d4) 4"));
    }

    [Test]
    public void TestMulResultsCollectionToResultCollection()
    {
        var a = new RollResult(repr: "1d6", result: 2);
        var b = new RollResult(repr: null, result: 3);
        var c = new RollResult(repr: "1d8", result: 4);
        var d = new RollResult(repr: "1d4", result: 5);

        var result1 = a * b;
        var result2 = c * d;
        var result3 = result1 * result2;

        Assert.That(result3.Total, Is.EqualTo(120));
        Assert.That(result3.Expression, Is.EqualTo("((1d6) 2 * 3) * ((1d8) 4 * (1d4) 5)"));
    }

    [Test]
    public void TestDivResults()
    {
        var a = new RollResult(repr: "1d6", result: 6);
        var b = new RollResult(repr: "1d4", result: 3);

        var result = a / b;

        Assert.That(result.Total, Is.EqualTo(2));
        Assert.That(result.Expression, Is.EqualTo("(1d6) 6 / (1d4) 3"));
    }

    [Test]
    public void TestDivResultsNullDice()
    {
        var a = new RollResult(repr: "1d6", result: 10);
        var b = new RollResult(repr: null, result: 2);

        var result = a / b;

        Assert.That(result.Total, Is.EqualTo(5));
        Assert.That(result.Expression, Is.EqualTo("(1d6) 10 / 2"));
    }

    [Test]
    public void TestDivResultsToResultCollection()
    {
        var a = new RollResult(repr: "1d6", result: 24);
        var b = new RollResult(repr: null, result: 2);
        var c = new RollResult(repr: "1d4", result: 3);

        var result = a / b;
        result /= c;

        Assert.That(result.Total, Is.EqualTo(4));
        Assert.That(result.Expression, Is.EqualTo("(1d6) 24 / 2 / (1d4) 3"));
    }

    [Test]
    public void TestDivResultsCollectionToResultCollection()
    {
        var a = new RollResult(repr: "1d6", result: 20);
        var b = new RollResult(repr: null, result: 2);
        var c = new RollResult(repr: "1d8", result: 10);
        var d = new RollResult(repr: "1d4", result: 5);

        var result1 = a / b;
        var result2 = c / d;
        var result3 = result1 / result2;

        Assert.That(result3.Total, Is.EqualTo(5));
        Assert.That(result3.Expression, Is.EqualTo("((1d6) 20 / 2) / ((1d8) 10 / (1d4) 5)"));
    }
    
    [Test]
    public void TestDifferentOperators()
    {
        var a = new RollResult(repr: "1d6", result: 2);
        var b = new RollResult(repr: null, result: 3);
        var c = new RollResult(repr: "1d8", result: 4);
        var d = new RollResult(repr: "1d4", result: 5);

        var result1 = a * b;
        var result2 = c * d;
        var result3 = result1 + result2;

        Assert.That(result3.Total, Is.EqualTo(26));
        Assert.That(result3.Expression, Is.EqualTo("((1d6) 2 * 3) + ((1d8) 4 * (1d4) 5)"));
    }
}