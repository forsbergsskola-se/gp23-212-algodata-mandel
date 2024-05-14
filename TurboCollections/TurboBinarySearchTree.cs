
using System.Collections;
using TurboCollections;

namespace TurboCollections;
public class TurboBinarySearchTree<T> : IEnumerable where T : IComparable<T>
{
   public class Node
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
      else
      {
         Node current = root;
         bool leafFound = false;

         while (!leafFound)
         {
            if (current.data.CompareTo(value) < 0)
            {
               if (current.right == null)
               {
                  current.right = new Node(value);
                  leafFound = true;
               }
               else
                  current = current.right;
            }
            if (current.data.CompareTo(value) > 0)
            {
               if (current.left == null)
               {
                  current.left = new Node(value);
                  leafFound = true;
               }
               else
                  current = current.left;
            }
         }
      }
   }
   
   public bool Search(T value)
   {
      Node current = root;

      while (current != null)
      {
         if (current.data.CompareTo(value) == 0)
            return true;
         if (current.data.CompareTo(value) < 0)
            current = current.right;
         else
            current = current.left;
      }
      return false;
   }
   
   public bool Delete(T value)
   {
      Node toDelete = root;
      while (toDelete != null && !toDelete.data.Equals(value))
      {
         if (value.CompareTo(toDelete.data) < 0)
         {
            toDelete = toDelete.left;
         }
         else
         {
            toDelete = toDelete.right;
         }
      }

      if (toDelete == null) // Return false if value doesn't exist in tree
      {
         return false;
      }

      if (toDelete.left == null && toDelete.right == null) // No children
      {
         toDelete = null; // This should set parents pointer to null, right?
      }
      
      // One child
      else if (toDelete.left == null) // Swap with right child
      {
         toDelete = toDelete.right;
         toDelete.right = null;
      }

      else if (toDelete.right == null) // Swap with left child
      {
         toDelete = toDelete.left;
         toDelete.left = null;
      }

      else // has two children
      {
         Node min = toDelete.right;
         while (min.left != null)
         {
            min = min.left;
         }
         toDelete = min;
      }
      
      return true;
   }

   private IEnumerable<T> TraversInOrder(Node n)
   {
      if (n == null) yield break;
      foreach (var node in TraversInOrder(n.left))
         yield return node;
      yield return n.data;
      foreach (var node in TraversInOrder(n.right))
         yield return node;
   }
   
   public IEnumerator GetEnumerator()
   {
      return TraversInOrder(root).GetEnumerator();
   }
}