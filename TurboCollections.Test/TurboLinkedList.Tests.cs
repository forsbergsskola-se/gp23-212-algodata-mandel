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
        
        Assert.That(list, Is.EquivalentTo(new []{1,3,5}));
    }

    [Test]
    public void TestCount()
    {
        var list = new TurboLinkedList<int>();
        
        list.Add(1);
        list.Add(3);
        list.Add(5);
        
        Assert.That(list.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void TestRemove()
    {
        var list = new TurboLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        
        list.Remove(2);
        Assert.That(list, Is.EquivalentTo(new[]{1,3}));
    }
    
    [Test]
    public void TestRemoveAtIndex()
    {
        var list = new TurboLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        
        list.RemoveAtIndex(1);
        Assert.That(list, Is.EquivalentTo(new[]{1,3}));
    }
    
    [Test]
    public void TestClear()
    {
        var list = new TurboLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);
        
        Assert.That(list, Is.Not.Empty);
        list.Clear();
        Assert.That(list, Is.Empty);
    }
    
    [Test]
    public void TestPeek()
    {
        var list = new TurboLinkedList<int>();
        
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Assert.That(list.Peek(), Is.EqualTo(1));
    }
}