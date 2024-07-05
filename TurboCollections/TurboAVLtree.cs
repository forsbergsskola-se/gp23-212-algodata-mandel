using System; 
namespace TurboCollections;

// I did not make this myself, this is from https://www.geeksforgeeks.org/insertion-in-an-avl-tree/
// But writing test for this tree and debugging the functions was a great learning experience


public class AVLTree
{
    public class Node  
    {  
        public int Key, Height;  
        public Node? Left;
        public Node? Right;

        public Node(int d) 
        {  
            Key = d;  
            Height = 1;  
        }  
    }

    public Node? root;
    
    // Get the height of the tree  
    private static int Height(Node? n)
    {
        if (n == null)
            return 0;

        return n.Height;
    }
    
    // Get the maximum of two integers  
    int Max(int a, int b)
    {
        return (a > b) ? a : b;
    }
    
    // Right-rotate subtree rooted with y  
    Node? RightRotate(Node? y)
    {
        Node? x = y.Left;
        Node? T2 = x.Right;

        // Perform rotation  
        x.Right = y;
        y.Left = T2;

        // Update heights  
        y.Height = Max(Height(y.Left), Height(y.Right)) + 1;
        x.Height = Max(Height(x.Left), Height(x.Right)) + 1;

        // Return new root  
        return x;
    }
    
    // Left-rotate subtree rooted with x  
    Node? LeftRotate(Node? x)
    {
        Node? y = x.Right;
        Node? T2 = y.Left;

        // Perform rotation  
        y.Left = x;
        x.Right = T2;

        // Update heights  
        x.Height = Max(Height(x.Left),
            Height(x.Right)) + 1;
        y.Height = Max(Height(y.Left),
            Height(y.Right)) + 1;

        // Return new root  
        return y;
    }

    // Get Balance factor of node n  
    int GetBalance(Node? n)
    {
        if (n == null)
            return 0;

        return Height(n.Left) - Height(n.Right);
    }

    public Node? Insert(Node? node, int key)
    {

        /* 1. Perform the normal BST insertion */
        if (node == null)
            return (new Node(key));

        if (key < node.Key)
            node.Left = Insert(node.Left, key);
        else if (key > node.Key)
            node.Right = Insert(node.Right, key);
        else // Duplicate keys not allowed  
            return node;

        /* 2. Update height of this ancestor node */
        node.Height = 1 + Max(Height(node.Left),
            Height(node.Right));

        /* 3. Get the balance factor of this ancestor
            node to check whether this node became
            unbalanced */
        int balance = GetBalance(node);

        // If this node becomes unbalanced, then there are 4 cases:  
        // Left-Left Case  
        if (balance > 1 && key < node.Left.Key)
            return RightRotate(node);

        // Right-Right Case  
        if (balance < -1 && key > node.Right.Key)
            return LeftRotate(node);

        // Left-Right Case  
        if (balance > 1 && key > node.Left.Key)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Right-Left Case  
        if (balance < -1 && key < node.Right.Key)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        /* return the (unchanged) node pointer */
        return node;
    }

    // A utility function to print preorder traversal  
    // of the tree.  
    // The function also prints height of every node  
    void PreOrder(Node? node)
    {
        if (node != null)
        {
            Console.Write(node.Key + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
    }
}