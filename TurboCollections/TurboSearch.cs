using System.Collections;
namespace TurboCollections;

public static class TurboSearch
{
    public static int LinearSearch(List<int> list, int value)
    {
        int index = 0;
        foreach (int item in list)
        {
            if (list[index] == value)
            {
                return index;
            }
            index++;
        }
        return -1;
    }

    public static int BinarySearch(List<int> list, int value)
    {
        var lowerBound = 0;
        var upperBound = list.Count - 1;

        while (lowerBound <= upperBound)
        {
            var mid = (lowerBound + upperBound) / 2;

            if (list[mid] < value)
                lowerBound = mid + 1;
            else if (list[mid] > value)
                upperBound = mid - 1;
            else if (list[mid] == value)
                return mid;
        }
        return -1;
    }
    
    
    // Generics
    
    public static int GenericLinearSearch<T>(IEnumerable<T> list, T value)
    {
        int index = 0;
        foreach (var item in list)
        {
            if (item == null && value == null || item.Equals(value))
            {
                return index;
            }
            index++;
        }
        return -1;
    }
    
    public static int GenericBinarySearch<T>(List<T> list, T value) where T : IComparable<T>
    {
        var lowerBound = 0;
        var upperBound = list.Count - 1;

        while (lowerBound <= upperBound)
        {
            var mid = (lowerBound + upperBound) / 2;

            if (list.ElementAt(mid).CompareTo(value) < 0)
                lowerBound = mid + 1;
            else if (list.ElementAt(mid).CompareTo(value) > 0)
                upperBound = mid - 1;
            else if (list.ElementAt(mid).CompareTo(value) == 0)
                return mid;
        }

        return -1;
    }
    
}