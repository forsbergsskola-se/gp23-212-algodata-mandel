
using TurboCollections;

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
      throw new NotImplementedException();
   }
    
}