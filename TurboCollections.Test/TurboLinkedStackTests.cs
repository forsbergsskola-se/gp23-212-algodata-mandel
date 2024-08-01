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
        
        Assert.That(stack, Is.Not.Empty);
        Assert.That(stack, Is.EquivalentTo(new []{3,2,1}));
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
        Assert.That(stack, Is.EqualTo(new []{3,2,1}));
        stack.Pop();
        Assert.That(stack, Is.EqualTo(new []{2,1}));
    }
    
    [Test]
    public void TestStackClear()
    {
        var stack = new TurboLinkedStack<int>();
        stack.Push(33);
        Assert.That(stack, Is.Not.Empty);
        stack.Clear();
        Assert.That(stack, Is.Empty);
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
        Assert.That(stack, Is.Empty);
        Assert.Throws<EmptyStackException>(()=>stack.Peek());
    }
}