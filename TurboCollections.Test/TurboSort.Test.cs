using System.Diagnostics;

namespace TurboCollections.Test;

public static class TurboSortTest
{ 
    public class SelectionSortTests : SortTestBase
    {
        protected override void SortList(List<int> list)
        {
            TurboSort.SelectionSort(list);
        }
    }
    
    public class BubbleSortTests : SortTestBase
    {
        protected override void SortList(List<int> list)
        {
            TurboSort.BubbleSort(list);
        }
    }
    
}

public abstract class SortTestBase
{
    // This will be implemented by the inheriting class that calls a specific sorting algorithm
    protected abstract void SortList(List<int> list);
    
    // These test cases will be inherited by any class inheriting from this class
    [TestCase(100), TestCase(10), TestCase(100000)]
    public void TestWithRandomNumbers(int count)
    {
        var numbers = Enumerable.Repeat(0, count)
            .Select(it => Random.Shared.Next())
            .ToList();

        var expected = numbers.OrderBy(it => it)
            .ToArray();

        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        SortList(numbers);
        stopwatch.Stop();
        
        Console.WriteLine(stopwatch.Elapsed);
        
        CollectionAssert.AreEqual(expected, numbers);
    }
}