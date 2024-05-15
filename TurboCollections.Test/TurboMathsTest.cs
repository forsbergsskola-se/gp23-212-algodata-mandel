using System.Diagnostics;

namespace TurboCollections.Test;

public static class MathsTests
{
    [Test]
    public static void SayHelloExists()
    {
        TurboMaths.SayHello();
        Assert.Pass();
    }

    [Test]
    public static void TestGetOddNumbersList()
    {
        Assert.That(TurboMaths.GetOddNumbersList(12), 
            Is.EqualTo(new List<int> { 1, 3, 5, 7, 9, 11 }));
    }

    [Test]
    public static void TestGetEvenNumbers()
    {
        Assert.That(TurboMaths.GetEvenNumbers(12),
            Is.EqualTo(new List<int> {0, 2, 4, 6, 8, 10, 12}));
    }

    [Test]
    public static void TestGetOddNumbers()
    {
        Assert.That(TurboMaths.GetOddNumbers(12),
            Is.EqualTo(new List<int> { 1, 3, 5, 7, 9, 11 }));
    }
}