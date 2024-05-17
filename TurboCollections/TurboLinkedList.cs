using System.Collections;

namespace TurboCollections;

public class TurboLinkedList<T> : IEnumerable<T> 
{
    class Node {
        public T Value;
        public Node? Next;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node? first;

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
    
    public int Count 
    {
        get
        {
            int count = 0;
            var current = first;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    public void Remove(T value)
    {
        var current = first;

        if (current.Value.Equals(value))
        {
            first = first.Next;
            return;
        }
        while (current.Next != null)
        {
            if (current.Next.Value.Equals(value))
            {
                current.Next = current.Next.Next;
            }
            current = current.Next;
        }
    }

    public void RemoveAtIndex(int index)
    {
        var current = first;
        int currentIndex = 0;
        
        if (Count < index)
            return;
        if (currentIndex == index)
        {
            first = current.Next;
            return;
        }

        while (current != null)
        {
            currentIndex++;
            if (currentIndex == index)
            {
                current.Next = current.Next.Next;
            }

            current = current.Next;
        }
        
    }

    public void Clear()
    {
        first = null;
    }
    
    
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