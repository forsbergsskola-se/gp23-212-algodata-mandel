using System.Diagnostics;

namespace TurboCollections.Test;

public class TurboSearchTests
{
    public class LinearSearchTests : SearchTestBase
    {
        protected override int SearchList(List<int> list, int value)
        {
            return TurboSearch.LinearSearch(list, value);
        }
    }

    public class BinarySearchTests : SearchTestBase
    {
        protected override int SearchList(List<int> list, int value)
        {
            return TurboSearch.BinarySearch(list, value);
        }
    }
    
    public class GenericLinearSearchTests : SearchTestBase
    {
        protected override int SearchList(List<int> list, int value)
        {
            return TurboSearch.GenericLinearSearch(list, value);
        }
    }
    
    public class GenericBinarySearchTests : SearchTestBase
    {
        protected override int SearchList(List<int> list, int value)
        {
            return TurboSearch.GenericBinarySearch(list, value);
        }
    }
}

public abstract class SearchTestBase
{
    protected abstract int SearchList(List<int> list, int value);
    
    [TestCase(100), TestCase(10), TestCase(100000)]
    public void TestWithRandomNumbers(int count)
    {
        var value = Random.Shared.Next();
        
        var numbers = Enumerable.Repeat(0, count)
            .Select(it => Random.Shared.Next())
            .ToList();

        TurboSort.QuickSort(numbers, 0, numbers.Count -1);

        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        SearchList(numbers, value);
        stopwatch.Stop();
        
        Console.WriteLine($"Sort Benchmark: {stopwatch.Elapsed:s\\.fffffff}"); 
        
        var result = SearchList(numbers, value);
        if(result == -1)
            CollectionAssert.DoesNotContain(numbers, value);
        else
            Assert.That(numbers[result], Is.EqualTo(value));
        
        //Assert.Pass();
        //Assert.That(stopwatch.Elapsed, Is.LessThan(xx))
    }
}