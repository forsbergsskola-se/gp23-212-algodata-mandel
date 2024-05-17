namespace TurboCollections.Test;

public class TurboLinkedList_Tests
{
    [Test]
    public void TestAddToList()
    {
        var list = new TurboLinkedList<int>();
        
        list.Add(1);
        list.Add(3);
        list.Add(5);
        
        foreach (var i in list)
        {
            Console.Write(i);
        }
        Assert.That(list, Is.EqualTo(new []{1,3,5}));
    }
}