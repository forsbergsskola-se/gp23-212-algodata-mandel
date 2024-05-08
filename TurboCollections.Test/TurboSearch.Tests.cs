namespace TurboCollections.Test;

public class TurboSearchTests
{
    [Test]
    public void LinearSearchIntTest()
    {
        var list = new List<int>() { 1, 2, 3, 4, 5, 6 };
        
        Assert.That(TurboSearch.LinearSearch(list, 6), Is.EqualTo(5));
        Assert.That(TurboSearch.LinearSearch(list, 8), Is.EqualTo(-1));
    }

    [Test]
    public void BinarySearchIntTest()
    {
        var list = new List<int>() { 1, 2, 3, 4, 5, 6 };
        
        Assert.That(TurboSearch.BinarySearch(list, 3), Is.EqualTo(2));
        Assert.That(TurboSearch.BinarySearch(list, 8), Is.EqualTo(-1));
    }
    
}