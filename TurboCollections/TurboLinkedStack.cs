using System.Collections;


namespace TurboCollections;

public class TurboLinkedStack<T> : IEnumerable<T> {
    class Node {
        public T Value;
        public Node Previous;
    }
    Node LastNode;

    public void Push(T item)
    {
        Node newNode = new()
        {
            Value = item,
            Previous = null
        };
        newNode.Previous = LastNode;
        LastNode = newNode;
    }

    public T Peek()
    {
        if (LastNode.Value == null)
            throw new NullReferenceException();
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
        LastNode = null;
    }

    public int Count {
        get{
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
        while(current != null){
            yield return current.Value;
            current = current.Previous;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /*
    public IEnumerator<T> GetEnumerator() {
        // This one is a bonus and a bit more difficult.
        // You need to create a new class named Enumerator.
        // You find the details below.
        var enumerator = new Enumerator(LastNode);
        return enumerator;
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    class Enumerator : IEnumerator<T> {
        private Node CurrentNode;
        private Node FirstNode;
        private Node _lastNode;

        public Enumerator(Node lastNode) {
            _lastNode = lastNode;
        }

        public bool MoveNext()
        {
            // if we don't have a current node, we start with the first node
            if(CurrentNode == null){
                CurrentNode = FirstNode;
            } else
            {
                CurrentNode = CurrentNode.Previous;
                // Assign the Current Node's Previous Node to be the Current Node.
            }

            return CurrentNode != null;
            // Return, whether there is a CurrentNode. Else, we have reached the end of the Stack, there's no more Elements.
        }

        public T Current {
            get{
                throw new NotImplementedException();
                // Return the Current Node's Value.
            }
        }

        // This Boiler Plate is necessary to correctly implement `IEnumerable` interface.
        object IEnumerator.Current => Current;

        public void Reset() {
            // Look at Move. How can you make sure that this Enumerator starts over again?
        }

        public void Dispose()
        {
            // This function is not needed right now.
        }
    }*/
    
}