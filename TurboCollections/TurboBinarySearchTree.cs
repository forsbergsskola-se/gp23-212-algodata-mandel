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
   
   public Node Insert(Node node, T value)
   {
      if (root == null)
      {
         root = new Node();
         root.data = value;
         return root;
      }
      else
      {
         //If root exists then
         //    compare the data with node.data
         //    while until insertion position is located
         //       If data is greater than node.data
         //          goto right subtree
         //       else
         //          goto left subtree
         //    endwhile 
         //    insert data
         // end If  ????
      }
      
      throw new NotImplementedException();
   }
   public Node Search(Node node, T value)
   {
      if (root.data.Equals(value))
      {
         return root;
      }
      throw new NotImplementedException();
      
      while (!node.data.Equals(value)) // "while Data not found" 
      {
         if (node.data.CompareTo(value) > 0)
         {
            // go to right subtree
         }
         else if (node.data.CompareTo(value) < 0)
         {
            // go to left subtree
         }
         else if (node.data.CompareTo(value) == 0)
         {
            // return node 
         }
         //If there is no subtree
         // return data not found
      }
   }
   
   public void Delete(Node node)
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