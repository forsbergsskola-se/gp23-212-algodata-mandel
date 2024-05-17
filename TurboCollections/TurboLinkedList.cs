using System.Collections;

namespace TurboCollections;

public class TurboLinkedList<T> : IEnumerable<T> 
{
    class Node {
        public T Value;
        public Node Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node first;

    public void Add(T value)
    {
        if (first == null)
        {
            first = new Node(value);
            return;
        }
        var current = first;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = new Node(value);
    }
    
    // Remove
    // Remove at index
    // Clear/delete
    // Count
    // Count a value
    // Peek
    // Peek at index
    
    public IEnumerator<T> GetEnumerator()
    {
        var current = first;
        
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