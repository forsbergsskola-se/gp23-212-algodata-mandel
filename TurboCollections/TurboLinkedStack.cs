using System.Collections;


namespace TurboCollections;

public class TurboLinkedStack<T> : IEnumerable<T> {
    class Node {
        public T Value = default!;
        public Node Previous = null!;
    }
    Node LastNode = null!;

    public void Push(T item)
    {
        Node newNode = new()
        {
            Value = item,
            Previous = null!
        };
        newNode.Previous = LastNode;
        LastNode = newNode;
    }

    public T Peek()
    {
        if (LastNode == null)
            throw new EmptyStackException();
        return LastNode.Value;
    }

    public T Pop()
    {
        Node temp = LastNode;
        LastNode = temp.Previous;
        return temp.Value;
    }

    public void Clear()
    {
        LastNode = null!;
    }

    public int Count 
    {
        get
        {
            int count = 0;
            while(LastNode != null){
                count++;
                LastNode = LastNode.Previous;
            }
            return count;
        }
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        var current = LastNode;
        while (true)
        {
            yield return current.Value;
            current = current.Previous;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class EmptyStackException : Exception
{
    public override string Message => "The Stack is empty. Operation not possible.";
}