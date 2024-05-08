using System.Diagnostics;

namespace TurboCollections.Test;

public class TurboSearchTests
{
    public class SearchLinearSearchTests : SearchTestBase
    {
        protected override int SearchList(List<int> list, int value)
        {
            return TurboSearch.LinearSearch(list, value);
        }
    }

    public class SearchBinarySearchTests : SearchTestBase
    {
        protected override int SearchList(List<int> list, int value)
        {
            return TurboSearch.BinarySearch(list, value);
        }
    }
    
    /*
    public class SearchGenericLinearSearchTests : SearchTestBase
    {
        protected override int SearchList(List<int> list, int value)
        {
            return TurboSearch.GenericLinearSearch(list, value);
        }
    }
    
    public class SearchGenericBinarySearchTests : SearchTestBase
    {
        protected override int SearchList(List<int> list, int value)
        {
            return TurboSearch.GenericBinarySearch(list, value);
        }
    }*/
    
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

        var timeResults = new List<TimeSpan>();

        Stopwatch stopwatch = new Stopwatch();

        for (int i = 0; i < 101; i++)
        {
            stopwatch.Start();
            SearchList(numbers, value);
            stopwatch.Stop();
            
            timeResults.Add(stopwatch.Elapsed);
        }
        
        TurboSort.GenericQuickSort(timeResults, 0, timeResults.Count -1);
        var median = timeResults.ElementAt(50);

        TimeSpan addedResults = default;
        var resultsCount = 0;
        
        for (int i = 0; i < 100; i++)
        {
            var timeResult = timeResults.ElementAt(i);
            var ratio = Math.Abs(timeResult / median);

            if (ratio is < 1.1f or > 0.9)
            {
                addedResults += timeResult;
                resultsCount++;
            }
        }

        var averageResult = addedResults / resultsCount;
        
        Console.WriteLine($"The average result for TestCase({count}) was: \n" +
                          $"{averageResult:s\\.fffffff} ten millionths of a second.");
        
        var result = SearchList(numbers, value);
        if(result == -1)
            CollectionAssert.DoesNotContain(numbers, value);
        else
            Assert.That(numbers[result], Is.EqualTo(value));
        
        //Assert.Pass();
        //Assert.That(stopwatch.Elapsed, Is.LessThan(xx))
    }
}