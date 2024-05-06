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
        CollectionAssert.AreEqual(
            new List<int> { 1, 3, 5, 7, 9, 11 }, 
            TurboMaths.GetOddNumbersList(12));
        CollectionAssert.AreEqual(
            new List<int> { 1, 3, 5, 7, 9, 11, 13, 15 }, 
            TurboMaths.GetOddNumbersList(15));
        CollectionAssert.AreEqual(
            new List<int> {}, 
            TurboMaths.GetOddNumbersList(-1));
        CollectionAssert.AreEqual(
            new List<int> {}, 
            TurboMaths.GetOddNumbersList(0));
    }

    [Test]
    public static void TestGetEvenNumbers()
    {
        CollectionAssert.AreEqual(
            new List<int> {0, 2, 4, 6, 8, 10, 12}, 
            TurboMaths.GetEvenNumbers(12));
        CollectionAssert.AreEqual(
            new List<int> {0, 2, 4, 6, 8, 10, 12, 14}, 
            TurboMaths.GetEvenNumbers(15));
        CollectionAssert.IsEmpty(
            TurboMaths.GetEvenNumbers(-1));
        CollectionAssert.AreEqual(
            new List<int> {0}, 
            TurboMaths.GetEvenNumbers(0));
    }

    [Test]
    public static void TestGetOddNumbers()
    {
        CollectionAssert.AreEqual(
            new List<int> { 1, 3, 5, 7, 9, 11 }, 
            TurboMaths.GetOddNumbers(12));
        CollectionAssert.AreEqual(
            new List<int> { 1, 3, 5, 7, 9, 11, 13, 15 }, 
            TurboMaths.GetOddNumbers(15));
        CollectionAssert.AreEqual(
            new List<int> {}, 
            TurboMaths.GetOddNumbers(-1));
        CollectionAssert.IsEmpty(
            TurboMaths.GetOddNumbers(0));
    }
}