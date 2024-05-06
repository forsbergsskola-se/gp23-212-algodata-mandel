
namespace P0_Fib;

public class Fib
{
    public int GetFibRecursive(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        int result = GetFibRecursive(n - 1) + GetFibRecursive(n - 2);
        return result;
    }

    public int GetFibIterative(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        int first = 0;
        int second = 1;
        
        nextIteration:
        int current = first + second;
        first = second;
        second = current;
        if (n > 1)
        {
            goto nextIteration;
        }

        return current;
    }
}