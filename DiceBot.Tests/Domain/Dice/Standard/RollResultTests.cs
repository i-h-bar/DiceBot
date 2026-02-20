using DiceBot.Domain.Dice.Standard;

namespace DiceBot.Tests.Domain.Dice.Standard;

[TestFixture]
public class RollResultTests
{
    [Test]
    public void TestAddResults()
    {
        var a = new RollResult("(1d6) 3", 3);
        var b = new RollResult("(1d4) 2", 2);

        var sum = a + b;

        Assert.That(sum.Result, Is.EqualTo(5));
        Assert.That(sum.Repr, Is.EqualTo("(1d6) 3 + (1d4) 2"));
    }

    [Test]
    public void TestAddResultsNullDice()
    {
        var a = new RollResult("(1d6) 3", 3);
        var b = new RollResult(null, 7);

        var sum = a + b;

        Assert.That(sum.Result, Is.EqualTo(10));
        Assert.That(sum.Repr, Is.EqualTo("(1d6) 3 + 7"));
    }

    [Test]
    public void TestAddResultsToResultCollection()
    {
        var a = new RollResult("(1d6) 3", 3);
        var b = new RollResult(null, 7);
        var c = new RollResult("(1d8) 2", 2);

        var sum = a + b;
        sum += c;

        Assert.That(sum.Result, Is.EqualTo(12));
        Assert.That(sum.Repr, Is.EqualTo("(1d6) 3 + 7 + (1d8) 2"));
    }

    [Test]
    public void TestAddResultsCollectionToResultCollection()
    {
        var a = new RollResult("(1d6) 3", 3);
        var b = new RollResult(null, 7);
        var c = new RollResult("(1d8) 2", 2);
        var d = new RollResult("(1d10) 5", 5);

        var sum = a + b;
        var sum2 = c + d;
        var sum3 = sum + sum2;

        Assert.That(sum3.Result, Is.EqualTo(17));
        Assert.That(sum3.Repr, Is.EqualTo("(1d6) 3 + 7 + (1d8) 2 + (1d10) 5"));
    }

    [Test]
    public void TestAddResultsFormat()
    {
        var a = new RollResult("(1d6) 3", 3);
        var b = new RollResult("(1d4) 2", 2);

        var sum = a + b;

        Assert.That(sum.FormatResult(), Is.EqualTo("(1d6) 3 + (1d4) 2 = 5"));
    }

    [Test]
    public void TestMultiplyResults()
    {
        var a = new RollResult("(1d6) 3", 3);
        var b = new RollResult("(1d4) 2", 2);

        var product = a * b;

        Assert.That(product.Result, Is.EqualTo(6));
        Assert.That(product.Repr, Is.EqualTo("((1d6) 3) * (1d4) 2"));
    }

    [Test]
    public void TestMultiplyResultsNullDice()
    {
        var a = new RollResult("(1d6) 3", 3);
        var b = new RollResult(null, 2);

        var product = a * b;

        Assert.That(product.Result, Is.EqualTo(6));
        Assert.That(product.Repr, Is.EqualTo("((1d6) 3) * 2"));
    }

    [Test]
    public void TestMultiplyResultsFormat()
    {
        var a = new RollResult("(1d6) 3", 3);
        var b = new RollResult("(1d4) 2", 2);

        var product = a * b;

        Assert.That(product.FormatResult(), Is.EqualTo("((1d6) 3) * (1d4) 2 = 6"));
    }

    [Test]
    public void TestDivideResults()
    {
        var a = new RollResult("(1d6) 6", 6);
        var b = new RollResult("(1d4) 2", 2);

        var quotient = a / b;

        Assert.That(quotient.Result, Is.EqualTo(3));
        Assert.That(quotient.Repr, Is.EqualTo("((1d6) 6) / (1d4) 2"));
    }

    [Test]
    public void TestDivideResultsNullDice()
    {
        var a = new RollResult("(1d6) 6", 6);
        var b = new RollResult(null, 2);

        var quotient = a / b;

        Assert.That(quotient.Result, Is.EqualTo(3));
        Assert.That(quotient.Repr, Is.EqualTo("((1d6) 6) / 2"));
    }

    [Test]
    public void TestDivideResultsFormat()
    {
        var a = new RollResult("(1d6) 6", 6);
        var b = new RollResult("(1d4) 2", 2);

        var quotient = a / b;

        Assert.That(quotient.FormatResult(), Is.EqualTo("((1d6) 6) / (1d4) 2 = 3"));
    }

    [Test]
    public void TestAddThenMultiplyResultsFormat()
    {
        var a = new RollResult("(1d6) 3", 3);
        var b = new RollResult("(1d4) 2", 2);
        var c = new RollResult("(1d10) 5", 5);

        var product = a + b;
        product *= c;

        Assert.That(product.FormatResult(), Is.EqualTo("((1d6) 3 + (1d4) 2) * (1d10) 5 = 25"));
    }
}