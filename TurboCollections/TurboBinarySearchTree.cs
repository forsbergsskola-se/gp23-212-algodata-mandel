
using System.Collections;


namespace TurboCollections;
public class TurboBinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
{
   private class Node
    {
        public T Data;
        public int Height;
        public Node? Left;
        public Node? Right;

        public Node(T value) 
        {
           Data = value;
           Height = 1;
           Left = null;
           Right = null;
        }
    }
   private Node? root;

   private static int GetHeight(Node? n)
   {
      return n == null ? 0 : n.Height;
   }
   private static int Max(int a, int b)
   {
      return (a > b) ? a : b;
   }

   private static int GetBalance(Node? n)
   {
      return n == null ? 0 : GetHeight(n.Left) - GetHeight(n.Right);
   }
   
   private Node RightRotate(Node y)
   {
      // Right rotate node y, place x as new root of subtree
      var x = y.Left;
      var z = x.Right;
      
      x.Right = y;
      y.Left = z;
      
      y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
      x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
      
      return x;
   }
   
   private Node LeftRotate(Node x)
   {
      // Left rotate node x, place y as new root of subtree 
      Node y = x.Right;
      Node z = y.Left;
      
      y.Left = x;
      x.Right = z;
      
      x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
      y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
      
      return y;
   }
   
   public int GetTreeHeight() // added for testing
   {
      return GetHeight(root);
   }
   
   public void Insert(T value)
   {
      root = InsertHelper(root, value);
   }

   private Node InsertHelper(Node? node, T value)
   {
      if (node == null)
      {
         return new Node(value);
      }

      if (value.CompareTo(node.Data) < 0)
      {
         node.Left = InsertHelper(node.Left, value);
      }
      else if (value.CompareTo(node.Data) > 0)
      {
         node.Right = InsertHelper(node.Right, value);
      }
      else
      {
         return node; // Duplicate values are not allowed
      }
      
      // Update height of inserted node: H(node) = Max(H(LeftSubTree), H(RightSubTree)) +1
      node.Height = Max(GetHeight(node.Left), GetHeight(node.Right)) +1;
      
      // Get balance of tree: B(H) = H(LeftSubTree) - H(RightSubTree)
      var balance = GetBalance(node);

      // Left-Left Case
      if (balance > 1 && value.CompareTo(node.Left.Data) < 0)
      {
         return RightRotate(node);
      }

      // Right-Right Case
      if (balance < -1 && value.CompareTo(node.Right.Data) > 0)
      {
         return LeftRotate(node);
      }

      // Left-Right Case
      if (balance > 1 && value.CompareTo(node.Left.Data) > 0)
      {
         node.Left = LeftRotate(node.Left);
         return RightRotate(node);
      }

      // Right-Left Case
      if (balance < -1 && value.CompareTo(node.Right.Data) < 0)
      {
         node.Right = RightRotate(node.Right);
         return LeftRotate(node);
      }

      return node;
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

      if (toDelete == null) return true;
      
      toDelete.Height = Max(GetHeight(toDelete.Left), GetHeight(toDelete.Right)) + 1;
      int balance = GetBalance(toDelete);
      
      if (balance > 1 && GetBalance(toDelete.Left) >= 0)
      {
         toDelete = RightRotate(toDelete);
      }
      
      if (balance < -1 && GetBalance(toDelete.Right) <= 0)
      {
         toDelete = LeftRotate(toDelete);
      }
      
      if (balance > 1 && GetBalance(toDelete.Left) < 0)
      {
         toDelete.Left = LeftRotate(toDelete.Left);
         toDelete = RightRotate(toDelete);
      }
      
      if (balance < -1 && GetBalance(toDelete.Right) > 0)
      {
         toDelete.Right = RightRotate(toDelete.Right);
         toDelete = LeftRotate(toDelete);
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
   
   public IEnumerator<T> GetPreEnumerator()
   {
      return TraversPreorder(root).GetEnumerator();
   }

   IEnumerator IEnumerable.GetEnumerator() 
   {
      return GetEnumerator();
   }
   
   public void PrintTree()
   {
      PrintTreeHelper(root, "", true);
   }

   private void PrintTreeHelper(Node? node, string indent, bool isLast) // Got this to visualise the tree structure
   {
      if (node != null)
      {
         Console.WriteLine(indent + (isLast ? "└── " : "├── ") + node.Data);

         // Prepare the indent for the next level
         indent += isLast ? "    " : "│   ";

         // Determine if the current node has one child
         bool hasOneChild = (node.Left != null && node.Right == null) || (node.Left == null && node.Right != null);
        
         // Print left and right children
         if (node.Left != null)
         {
            PrintTreeHelper(node.Left, indent, node.Right == null);
         }
         if (node.Right != null)
         {
            PrintTreeHelper(node.Right, indent, true);
         }
      }
   }
}

// Left Rotation: When a node becomes unbalanced with a balance factor of -2, and its right child has a balance factor of -1 or 0.
// Right Rotation: When a node becomes unbalanced with a balance factor of 2, and its left child has a balance factor of 1 or 0.
// Left-Right Rotation: When a node becomes unbalanced with a balance factor of 2, and its left child has a balance factor of -1.
// Right-Left Rotation: When a node becomes unbalanced with a balance factor of -2, and its right child has a balance factor of 1.