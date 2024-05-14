
using System.Collections;
using TurboCollections;

namespace TurboCollections;
public class TurboBinarySearchTree<T> : IEnumerable where T : IComparable<T>
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
      throw new NotImplementedException();
   }

   public IEnumerator<T> GetEnumerator()
   {
      throw new NotImplementedException();
   }

   //Traverse(node n)
   // Traverse(n.left)
   // Visit(n)
   // Traverse(n.right)
   
   
   IEnumerator IEnumerable.GetEnumerator()
   {
      return GetEnumerator();
   }
}