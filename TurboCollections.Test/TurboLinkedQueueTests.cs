namespace TurboCollections.Test;

public class TurboLinkedQueueTests
{
    [Test]
    public void TestQueueCount()
    {
        var myQ = new TurboLinkedQueue<int>();
        myQ.Enqueue(1);
        myQ.Enqueue(2);
        myQ.Enqueue(5);
        
        Assert.That(myQ.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void TestQueueEnqueue()
    {
        var myQ = new TurboLinkedQueue<int>();
        myQ.Enqueue(1);
        myQ.Enqueue(2);
        
        CollectionAssert.IsNotEmpty(myQ);
        CollectionAssert.AreEqual(new []{1,2}, myQ);
        Assert.That(myQ.FirstNode.Value, Is.EqualTo(1));
    }
    
    [Test]
    public void TestQueuePeek()
    {
        var myQ = new TurboLinkedQueue<char>();
        myQ.Enqueue('a');
        myQ.Enqueue('b');
        myQ.Enqueue('c');
        
        Assert.That(myQ.Peek(), Is.EqualTo('a'));
        Assert.That(myQ.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void TestQueueDequeue()
    {
        var myQ = new TurboLinkedQueue<char>();
        myQ.Enqueue('a');
        myQ.Enqueue('b');
        myQ.Enqueue('c');
        
        Assert.That(myQ.Dequeue(), Is.EqualTo('a'));
        Assert.That(myQ.Count, Is.EqualTo(2));
    }
    
    [Test]
    public void TestQueueClear()
    {
        var myQ = new TurboLinkedQueue<int>();
        myQ.Enqueue(1);
        myQ.Enqueue(2);
        CollectionAssert.IsNotEmpty(myQ);
        
        myQ.Clear();
        CollectionAssert.IsEmpty(myQ);
    }
    
    [Test]
    public void TestPeekIntoEmptyQueue(){
        var myQ = new TurboLinkedQueue<int>();
        CollectionAssert.IsEmpty(myQ);
        Assert.Throws<EmptyQueueException>(()=>myQ.Peek());
    }
}