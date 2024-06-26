﻿
/*
Create a List with 5 numbers: 1, 1, 2, 3, 5.
Assign it to a Variable of Type IEnumerable.
Use GetEnumerator() and a while-Loop to print all elements of the IEnumerable-Variable.
*/

using TurboCollections;

List<int> numberList = new() { 1, 1, 2, 3, 5 };

IEnumerable<int> numbers = numberList;
var iterator = numbers.GetEnumerator();
while (iterator.MoveNext())
{
    Console.WriteLine(iterator.Current);
}

/*
Can you also add up all numbers of the List using IEnumerable and then print the sum?
If not, then what do you need to change?
*/
var sum = 0;
foreach (var number in numbers)
{
    sum += number;
}
Console.WriteLine($"Sum: {sum}");

Console.WriteLine("Odd Numbers List:");
foreach (var n in TurboMaths.GetOddNumbersList(12))
{
    Console.Write($"{n}, ");
}
Console.WriteLine();
Console.WriteLine("Odd Numbers Enumerator:");
foreach (var n in TurboMaths.GetOddNumbers(12))
{
    Console.Write($"{n}, ");
}
Console.WriteLine();
