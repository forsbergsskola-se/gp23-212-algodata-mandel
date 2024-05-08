using System.Collections;
namespace TurboCollections;

public class TurboSearch
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
    
}