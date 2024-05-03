namespace TurboCollections;

public static class TurboMaths
{ 
    public static void SayHello()
    {
        Console.WriteLine($"Hello, I'm {typeof(TurboMaths)}");
    }
    
    public static List<int> GetOddNumbersList(int maxNumber)
    {
        var oddNumbers = new List<int>();
        for (var i = 0; i <= maxNumber; i++)
        {
            if(i % 2 != 0)
                oddNumbers.Add(i);
        }
        return oddNumbers;
    }
    
    public static IEnumerable<int> GetEvenNumbers(int maxNumber){
        for (var i = 0; i <= maxNumber; i++)
        {
            if (i % 2 == 0)
            {
                yield return i;
            }
        }
    }
    
    public static IEnumerable<int> GetOddNumbers(int maxNumber){
        for (var i = 0; i <= maxNumber; i++)
        {
            if (i % 2 != 0)
            {
                yield return i;
            }
        }
    }
}