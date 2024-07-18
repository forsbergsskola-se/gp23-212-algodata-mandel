namespace TurboCollections;
/// <summary>
/// Let's try adding summary comments to generate documentation from!
/// </summary>
public static partial class TurboSort
{
    /// <summary>
    /// A Bubble Sort algorithm to sort all elements in a list.
    /// </summary>
    /// <param name="list"></param>
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

