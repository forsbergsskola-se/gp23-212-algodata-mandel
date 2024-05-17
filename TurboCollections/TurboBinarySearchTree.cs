
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
         Node minParent = toDelete;
         while (min.Left != null)
         {
            minParent = min;
            min = min.Left;
         }

         if (minParent != toDelete)
         {
            minParent.Left = min.Right;
            min.Right = toDelete.Right;
         }

         min.Left = toDelete.Left;

         if (parent == null) // if deleting the root
            root = min;
         else if (toDelete == parent.Left)
            parent.Left = min;
         else if (toDelete == parent.Right)
            parent.Right = min;
      }
      return true;
   }

   public TurboBinarySearchTree<T> Clone()
   {
      var newTree = new TurboBinarySearchTree<T>();
      foreach (var n in TraversPreorder(root))
      {
         newTree.Insert(n);
      }
      return newTree;
   }

   public void DeleteTree()
   {
      DeleteTree(root);
      root = null;
   }

   private void DeleteTree(Node node)
   {
      if (node == null) return;
      DeleteTree(node.Left);
      DeleteTree(node.Right);

      node.Data = default(T);
      node.Left = null;
      node.Right = null;
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
   
   private IEnumerable<T> TraversPreorder(Node n)
   {
      if (n == null) yield break;
      yield return n.Data;
      foreach (var node in TraversPreorder(n.Left))
         yield return node;
      foreach (var node in TraversPreorder(n.Right))
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