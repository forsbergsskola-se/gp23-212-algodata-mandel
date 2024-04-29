List<string> names = new List<string>();
names.Add("Marc");
names.Add("Daniel");
names.Add("René");
names.Add("ABC");

var iterator = names.GetEnumerator();
bool isThereOneMoreItem = iterator.MoveNext();
if (isThereOneMoreItem)
{
    //Console.WriteLine(iterator.Current);
}

foreach (var name in names)
{
    Console.WriteLine(name);
}

