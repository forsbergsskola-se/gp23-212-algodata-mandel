namespace TurboCollections.Test;

[TestFixture]
public static class SelectionSort_Test
{
    [Test]
    public static void TestSelectionSort()
    {
        var list = new List<int>();
        CollectionAssert.IsEmpty(list);
        list.Add(5);
        list.Add(2);
        list.Add(4);
        list.Add(6);
        list.Add(1);
        list.Add(3);
        TurboSort.SelectionSort(list);
        
        CollectionAssert.AreEqual(new []{1, 2, 3, 4, 5, 6}, list);
    }
}