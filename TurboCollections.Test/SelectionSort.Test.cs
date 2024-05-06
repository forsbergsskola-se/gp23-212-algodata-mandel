namespace TurboCollections.Test;

[TestFixture]
public static class SelectionSort_Test
{
    [Test]
    public static void TestSelectionSort()
    {
        var list = new List<int>() {5, 2, 4, 6, 1, 3};
        TurboSort.SelectionSort(list);
        
        CollectionAssert.AreEqual(new []{1, 2, 3, 4, 5, 6}, list);
    }
}