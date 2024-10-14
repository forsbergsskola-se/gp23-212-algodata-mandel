
using System.Diagnostics;

int GetFibRecursive(int n)
{
    if (n == 0) return 0;
    if (n == 1) return 1;

    int result = GetFibRecursive(n - 1) + GetFibRecursive(n - 2);
    return result;
}

int GetFibIterative(int n)
{
    if (n == 0) return 0;
    if (n == 1) return 1;

    int first = 0;
    int second = 1;
        
    nextIteration:
    int current = first + second;
    first = second;
    second = current;
    n--;
    if (n > 1)
    {
        goto nextIteration;
    }
    return current;
}
    
void TestFibRecursive(int n)
{
    Stopwatch stopwatch = new Stopwatch();
        
    stopwatch.Start();
    GetFibRecursive(n);
    stopwatch.Stop();
    
    TimeSpan ts = stopwatch.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
    Console.WriteLine("Fib Recursive took " + elapsedTime);
}
    
void TestFibIterative(int n)
{
    Stopwatch stopwatch = new Stopwatch();
        
    stopwatch.Start();
    GetFibIterative(n);
    stopwatch.Stop();
    
    TimeSpan ts = stopwatch.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        ts.Hours, ts.Minutes, ts.Seconds,
        ts.Milliseconds / 10);
    Console.WriteLine("Fib Iterative took " + elapsedTime);
}

TestFibRecursive(40);
TestFibIterative(40);