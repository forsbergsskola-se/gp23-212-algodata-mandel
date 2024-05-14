using Microsoft.Win32.SafeHandles;

namespace TurboCollections;
public class TurboBinarySearchTree<T> where T : IComparable<T>
{
   private class Node
    {
        public T data;
        public Node left, right;

        public Node(T value) 
        {
           data = value;
           left = null;
           right = null;
        }
    }

   private Node root;
   
   public void Insert(T value)
   {
      if (root == null)
         root = new Node(value);

      Node current = root;
      Node parent = null;
      bool isLeaf = false;

      while (!isLeaf)
      {
         parent = current;

         if (current.data.CompareTo(value) > 0)
         {
            //goto right subtree
            // if current.right == null -> leaf found
         }

         if (current.data.CompareTo(value) < 0)
         {
            // go left
            // if current.left == null -> leaf found
         }
         // insert data
      }
   }
   
   public bool Search(T value)
   {
      Node current = root;

      while (current != null)
      {
         if (current.data.CompareTo(value) == 0)
            return true;
         if (current.data.CompareTo(value) > 0)
            current = current.right;
         else
            current = current.left;
      }
      return false;
   }
   
   public bool Delete(T value)
   {
      throw new NotImplementedException();
   }
    
}

/*
 Implement a simple Binary Search Tree TurboBinarySearchTree or TurboBinarySearchTree<T> 
 where T:IComparable<T> without Balancing Algorithms. 
 It should have these methods:
   Insert, Search, Delete,
   GetEnumerator: returns all items in order, from min to max
   GetInOrder: same as GetEnumerator
   GetInReverseOrder: returns all items in reverse order, from max to min
   Clone: creates a clone of the tree
   
Excellent Criteria
   Delete: deletes the tree, but node by node (set the value to 0, then set left to null and right to null)
   Implement the Tree using an Array to store all values instead of Node-classes.
*/