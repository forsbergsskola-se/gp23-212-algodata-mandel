using System.Collections;
namespace TurboCollections;

public class TurboSearch
{
    public static int LinearSearch<T>(IEnumerable<T> list, T value)
    {
        int index = 0;
        foreach (var item in list)
        {
            if (EqualityComparer<T>.Default.Equals(item, value)) // why is Default needed?
            {
                return index;
            }
            index++;
        }
        return -1;
    }
}