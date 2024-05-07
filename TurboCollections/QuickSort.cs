using System.Collections.Concurrent;

namespace TurboCollections;

public static partial class TurboSort
{
    public static void QuickSort(List<int> list, int low, int high)
    {
        if (low <= high)
        {
            var partitionIndex = Partition(list, low, high);
            QuickSort(list, low, partitionIndex - 1);
            QuickSort(list, partitionIndex + 1, high);
        }
    }

    private static int Partition(List<int> list, int low, int high)
    {
        var pivotValue = list[high]; // could be replaced by alternative pivot selection methods
        var partitionIndex = low;
        for (int j = low; j <= high -1; j++)
        {
            if (list[j] < pivotValue)
            {
                (list[j], list[partitionIndex]) = (list[partitionIndex], list[j]);
                partitionIndex++;
            }
        }
        (list[partitionIndex], list[high]) = (list[high], list[partitionIndex]);
        return partitionIndex;
    }
}
