using System.Collections;

namespace TurboCollections;

public interface ITurboQueue<T> : IEnumerable<T> {
    int Count {get;}// returns the current amount of items contained in the queue.
    void Enqueue(T item);// adds one item to the back of the queue.
    T Peek();// returns the item in the front of the queue without removing it.
    T Dequeue();// returns the item in the front of the queue and removes it at the same time.
    void Clear();// removes all items from the queue.
}
public class TurboLinkedQueue<T> : ITurboQueue<T> {
    class Node {
        public T Value = default!;
        public Node Next = null!;
    }
    Node FirstNode = null!;

    public int Count 
    {
        get
        {
            int count = 0;
            var current = FirstNode;
            while (true)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    public void Enqueue(T value){
        Node newNode = new()
        {
            Value = value,
            Next = null!
        };
        
        if (FirstNode == null)
        {
            FirstNode = newNode;
        }
        else
        {
            var current = FirstNode;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;  
        }
    }

    public T Peek()
    {
        if (FirstNode == null)
            throw new EmptyQueueException();
        return FirstNode.Value;
    }

    public T Dequeue()
    {
        var temp = FirstNode;
        FirstNode = temp.Next;
        return temp.Value;
    }

    public void Clear()
    {
        FirstNode = null;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        var current = FirstNode;
        while (true)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class EmptyQueueException : Exception
{
    public override string Message => "The Queue is empty. Operation not possible.";
}