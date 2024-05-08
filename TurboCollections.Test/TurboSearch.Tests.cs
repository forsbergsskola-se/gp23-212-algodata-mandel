namespace TurboCollections.Test;

public class TurboSearchTests
{
    [Test]
    public void LinearSearchTest()
    {
        var list = new List<int>() { 1, 2, 3, 4, 5, 6 };
        
        Assert.That(TurboSearch.LinearSearch(list, 6), Is.EqualTo(5));
        Assert.That(TurboSearch.LinearSearch(list, 8), Is.EqualTo(-1));
    }
    
    
}