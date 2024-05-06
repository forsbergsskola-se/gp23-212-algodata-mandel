namespace TurboCollections;

public class TurboSort
{
    public void SelectionSort(List<int> list)
    {
        int min;
        for (var i = 0; i < list.Count - 2; i++)
        {
            min = i;
            for (var j = i + 1; j < list.Count -1 ; j++)
            {
                if (list[j] < list[min])
                {
                    min = j;
                }
            }

            if (min != i)
            {
                (list[min], list[i]) = (list[i], list[min]);
            }
        }
    }
}