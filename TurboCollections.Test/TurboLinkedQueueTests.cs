namespace TurboCollections.Test;

public class LinkedTurboLinkedQueueTests
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
        
        Assert.That(myQ, Is.Not.Empty);
        Assert.That(myQ, Is.SupersetOf(new []{1,2}));
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
        Assert.That(myQ, Is.Not.Empty);
        
        myQ.Clear();
        Assert.That(myQ, Is.Empty);
    }
    
    [Test]
    public void TestPeekIntoEmptyQueue(){
        var myQ = new TurboLinkedQueue<int>();
        Assert.That(myQ, Is.Empty);
        Assert.Throws<EmptyQueueException>(()=>myQ.Peek());
    }
}