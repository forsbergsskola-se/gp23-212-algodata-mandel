using System.Collections;

List<string> names = new List<string>();
names.Add("Marc");
names.Add("Daniel");
names.Add("René");
names.Add("ABC");

var iterator = names.GetEnumerator();
bool isThereOneMoreItem = iterator.MoveNext();

while (iterator.MoveNext())
{
    //Console.WriteLine(iterator.Current);
}

for (var i = names.GetEnumerator(); iterator.MoveNext();)
{
    //Console.WriteLine(iterator.Current);
}

foreach (var name in names)
{
    //Console.WriteLine(name);
}

/* Create a List to store the numbers 137,1000, -200
Use a for-Loop and the index-Operator [] to print all values in the List
Create an ArrayList to store the values true, "Forsbergs", 'a', 1000, .12f;
Use a for-Loop and the index-Operator [] to print all values in the ArrayList */

List<int> numbers = new();
numbers.Add(137);
numbers.Add(1000);
numbers.Add(-200);

for (var i = 0; i < numbers.Count; i++)
{
    Console.WriteLine(numbers[i]);
}

ArrayList arrayList = new();
arrayList.Add(true);
arrayList.Add("Forsbergs");
arrayList.Add('a');
arrayList.Add(1000);
arrayList.Add(.12f);

for (var i = 0; i < arrayList.Count; i++)
{
    Console.WriteLine(arrayList[i]);
}