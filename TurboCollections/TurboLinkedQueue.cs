using System.Collections;

namespace TurboCollections;

public interface ITurboQueue<T> : IEnumerable<T> {
    int Count {get;}// returns the current amount of items contained in the stack.
    void Enqueue(T item);// adds one item to the back of the queue.
    T Peek();// returns the item in the front of the queue without removing it.
    T Dequeue();// returns the item in the front of the queue and removes it at the same time.
    void Clear();// removes all items from the queue.
}
public class TurboLinkedQueue<T> : ITurboQueue<T> {
    class Node {
        public T Value;
        public Node Next;
    }
    Node FirstNode;

    public int Count 
    {
        get
        {
            int count = 0;
            while (FirstNode != null)
            {
                count++;
                FirstNode = FirstNode.Next;
            }
            return count;
        }
    }

    public void Enqueue(T value){
        Node newNode = new()
        {
            Value = value,
            Next = null
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
        
        // This is a bit more complicated. You need to let the last Node in the Queue know who's next after him.
        // No other choice but looping through your Nodes until you reach the end.
        // You know that you've reached the end, if the current Node's Next Node is null.
        // Then, you assign a new Node containing the value to the current node's Next field.
    }

    public T Peek()
    {
        if (FirstNode == null)
            throw new Exception();
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
        while (current != null)
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