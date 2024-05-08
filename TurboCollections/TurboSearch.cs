using System.Collections;
namespace TurboCollections;

public class TurboSearch
{
    public static int LinearSearch<T>(IEnumerable<T> list, T value)
    {
        for (int i = 0; i < list.Count(); i++)
        {
            if (Comparer<T>.Default.Compare(list.ElementAt(i), value) == 0)
            {
                return i;
            }
        }
        return -1;
    }
}