
using System.Collections;


namespace TurboCollections;
public class TurboBinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
{
   public class Node
    {
        public T Data;
        public int Height;
        public Node? Left;
        public Node? Right;

        public Node(T value) 
        {
           Data = value;
           Height = 0;
           Left = null;
           Right = null;
        }
    }
   private Node? root;
   
   private static int Height(Node n)
   {
      return n == null ? 0 : n.Height;
   }
   private int Max(int a, int b)
   {
      return (a > b) ? a : b;
   }
   
   public void Insert(T value)
   {
      InsertHelper(root, value);
   }

   private void InsertHelper(Node node, T value)
   {
      if (root == null)
      {
         root = new Node(value);
      }

      else if (node.Data.CompareTo(value) < 0)
      {
         if (node.Right == null)
         {
            node.Right = new Node(value);
         }
         else
         {
            InsertHelper(node.Right, value);
         }
      }
      else
      {
         if (node.Left == null)
         {
            node.Left = new Node(value);
         }
         else
            InsertHelper(node.Left, value);
      }
      
      // Update heights of inserted node: H(node) = Max(H(LeftSubTree), H(RightSubTree)) +1
      // Get balance of tree:             B(H) = H(LeftSubTree) - H(RightSubTree)
      // Check if tree needs rotating:    ABS(B(H)) <= 1 ? 
      // If Left heavy  -> Right or Right-Left rotate
      // If Right heavy -> Left or Left-Right rotate
   }
   
   public bool Search(T value)
   {
      Node? current = root;
      while (current != null)
      {
         switch (current.Data.CompareTo(value))
         {
            case 0: 
               return true;
            case < 0:
               current = current.Right;
               break;
            default:
               current = current.Left;
               break;
         }
      }
      return false;
   }

   public bool Delete(T value)
   {
      return root != null && DeleteHelper(root, value, out root);
   }

   private bool DeleteHelper(Node? node, T value, out Node toDelete) // out Node to update the tree
   {
      if (node == null)
      {
         toDelete = null;
         return false;
      }

      var compareResult = value.CompareTo(node.Data);
      if (compareResult < 0)
      {
         var result = DeleteHelper(node.Left, value, out node.Left);
         toDelete = node;
         return result;
      }
      if (compareResult > 0)
      {
         var result = DeleteHelper(node.Right, value, out node.Right);
         toDelete = node; 
         return result;
      }
      
      if (node.Left == null && node.Right == null) // No children
      {
         toDelete = null;
      }
      else if (node.Left == null) // one child left/right
      {
         toDelete = node.Right;
      }
      else if (node.Right == null)
      {
         toDelete = node.Left;
      }
      else // two children
      {
         var swap = FindMin(node.Right);
         node.Data = swap.Data;
         DeleteHelper(node.Right, swap.Data, out node.Right);
         toDelete = node;
      }
      return true;
   }

   private Node FindMin(Node node)
   {
      while (node.Left != null)
      {
         node = node.Left;
      }
      return node;
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

   private void DeleteTree(Node? node)
   {
      if (node == null) return;
      DeleteTree(node.Left);
      DeleteTree(node.Right);

      node.Data = default(T);
      node.Left = null;
      node.Right = null;
   }

   private IEnumerable<T> TraversInOrder(Node? n)
   {
      if (n == null) yield break;
      foreach (var node in TraversInOrder(n.Left))
         yield return node;
      yield return n.Data;
      foreach (var node in TraversInOrder(n.Right))
         yield return node;
   }
   
   private IEnumerable<T> TraversInReverseOrder(Node? n)
   {
      if (n == null) yield break;
      foreach (var node in TraversInReverseOrder(n.Right))
         yield return node;
      yield return n.Data;
      foreach (var node in TraversInReverseOrder(n.Left))
         yield return node;
   }
   
   private IEnumerable<T> TraversPreorder(Node? n)
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
   
   public IEnumerator<T> GetReverseEnumerator()
   {
      return TraversInReverseOrder(root).GetEnumerator();
   }

   IEnumerator IEnumerable.GetEnumerator() 
   {
      return GetEnumerator();
   }
}