namespace TurboCollections;

public static partial class TurboSort
{
    public static void BubbleSort(List<int> list)
    {
        var loop = list.Count;
        
        for (var i = loop-1; i > 0; i--)
        {
            var swapped = false;
            for (var j = 0; j < i; j++)
            {
                if (list[j] > list[j + 1])
                {
                    (list[j], list[j + 1]) = (list[j + 1], list[j]);
                    swapped = true;
                }
            }
            if(!swapped) break;
        }
    }
    
}

