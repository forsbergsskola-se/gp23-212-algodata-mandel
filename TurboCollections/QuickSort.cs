namespace TurboCollections;

public static partial class TurboSort
{
    public static void QuickSort(List<int> list)
    {
       /* // Fields needed
        * Low (leftIndex)
        * High (rightIndex)
        * Pivot = list[High]
        *
        * Procedure quicksort(list, low, high)
              if low <= high then
                  partitionIndex := partition(list, low, high)
                  quicksort(list, low, partitionIndex - 1)
                  quicksort(list, partitionIndex + 1, high)
              end if
          end procedure
        *
        * partition(list, low, high)
              pivotValue := list[high] // could be replaced by alternative pivot selection methods
              partitionIndex := low
              for j := partitionIndex to high - 1 do
                  if list[j] < pivotValue then
                      swap list[partitionIndex] with list[j]
                      partitionIndex++
                  end if
              end for
              swap list[partitionIndex] with list[high]
              return partitionIndex
          end procedure
        * 
        */
        
    }
}
