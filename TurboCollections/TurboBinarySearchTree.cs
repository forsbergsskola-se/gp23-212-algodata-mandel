
using System.Collections;


namespace TurboCollections;
public class TurboBinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
{
   public class Node
    {
        public T Data;
        public Node Left, Right;

        public Node(T value) 
        {
           Data = value;
           Left = null;
           Right = null;
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
            if (current.Data.CompareTo(value) < 0)
            {
               if (current.Right == null)
               {
                  current.Right = new Node(value);
                  leafFound = true;
               }
               else
                  current = current.Right;
            }
            if (current.Data.CompareTo(value) > 0)
            {
               if (current.Left == null)
               {
                  current.Left = new Node(value);
                  leafFound = true;
               }
               else
                  current = current.Left;
            }
         }
      }
   }
   
   public bool Search(T value)
   {
      Node current = root;

      while (current != null)
      {
         if (current.Data.CompareTo(value) == 0)
            return true;
         if (current.Data.CompareTo(value) < 0)
            current = current.Right;
         else
            current = current.Left;
      }
      return false;
   }
   
   public bool Delete(T value)
   {
      Node toDelete = root;
      Node parent = null;
      while (toDelete != null && !toDelete.Data.Equals(value))
      {
         parent = toDelete;
         if (value.CompareTo(toDelete.Data) < 0)
            toDelete = toDelete.Left;
         else
            toDelete = toDelete.Right;
      }

      if (toDelete == null) // Return false if value doesn't exist in tree
         return false;

      if (toDelete.Left == null && toDelete.Right == null) // No children
      {
         if (toDelete == parent.Left)
            parent.Left = null;

         if (toDelete == parent.Right)
            parent.Right = null;
      }
      
      // One child
      else if (toDelete.Left == null && toDelete.Right != null) // Swap with right child
      {
         if (toDelete == parent.Left)
         {
            parent.Left = toDelete.Right;
         }

         if (toDelete == parent.Right)
         {
            parent.Right = toDelete.Right;
         }
      }

      else if (toDelete.Left != null && toDelete.Right == null) // Swap with left child
      {
         if (toDelete == parent.Left)
         {
            parent.Left = toDelete.Left;
         }

         if (toDelete == parent.Right)
         {
            parent.Right = toDelete.Left;
         }
      }

      else // has two children
      {
         Node min = toDelete.Right;
         while (min.Left != null)
         {
            min = min.Left;
         }
         if (toDelete == parent.Left)
         {
            parent.Left = min;
            min.Left = toDelete.Left;
         }

         if (toDelete == parent.Right)
         {
            parent.Right = min;
            min.Left = toDelete.Left;
         }
      }
      return true;
   }

   public TurboBinarySearchTree<T> Clone(TurboBinarySearchTree<T> tree)
   {
      // use preorder traversal?
      // Traverse(node n)
      // Visit(n)
      // Traverse(n.left)
      // Traverse(n.right)
      throw new NotImplementedException();
   }

   public void DeleteTree(TurboBinarySearchTree<T> tree)
   {
      // deletes the tree, but node by node (set the value to 0, then set left to null and right to null)
      throw new NotImplementedException();
   }

   private IEnumerable<T> TraversInOrder(Node n)
   {
      if (n == null) yield break;
      foreach (var node in TraversInOrder(n.Left))
         yield return node;
      yield return n.Data;
      foreach (var node in TraversInOrder(n.Right))
         yield return node;
   }
   

   private IEnumerable<T> TraversInReverseOrder(Node n)
   {
      if (n == null) yield break;
      foreach (var node in TraversInReverseOrder(n.Right))
         yield return node;
      yield return n.Data;
      foreach (var node in TraversInReverseOrder(n.Left))
         yield return node;
   }


   public IEnumerator<T> GetEnumerator() // Strongly typed 
   {
      return TraversInOrder(root).GetEnumerator();
   }

   IEnumerator IEnumerable.GetEnumerator() 
   {
      return GetEnumerator();
   }
}