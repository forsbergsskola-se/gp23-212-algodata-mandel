namespace TurboCollections.Test;

public class LinkedTurboLinkedStackTests
{
    [Test]
    public void TestStackPush()
    {
        var stack = new TurboLinkedStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        
        CollectionAssert.IsNotEmpty(stack);
        CollectionAssert.AreEqual(new []{3,2,1}, stack);
    }

    [Test]
    public void TestStackPeek()
    {                                             
        var stack = new TurboLinkedStack<int>();
        stack.Push(4);
        stack.Push(3);
        
        Assert.That(stack.Peek(), Is.EqualTo(3));
    }

    [Test]
    public void TestStackPop()
    {
        var stack = new TurboLinkedStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        CollectionAssert.AreEqual(new []{3,2,1}, stack);
        stack.Pop();
        CollectionAssert.AreEqual(new []{2,1}, stack);
    }
    
    [Test]
    public void TestStackClear()
    {
        var stack = new TurboLinkedStack<int>();
        stack.Push(33);
        CollectionAssert.IsNotEmpty(stack);
        stack.Clear();
        CollectionAssert.IsEmpty(stack);
    }
    
    [Test]
    public void TestStackCount()
    {
        var stack = new TurboLinkedStack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        
        Assert.That(stack.Count, Is.EqualTo(3));
    }
    
    [Test]
    public void TestPeekIntoEmptyStack(){
        var stack = new TurboLinkedStack<int>();
        CollectionAssert.IsEmpty(stack);
        Assert.Throws<EmptyStackException>(()=>stack.Peek());
    }
}