using System.Collections;

namespace TurboCollections.Test;

public class TurboBstTests
{
    [Test]
    public void TestInsertBst()
    {
        var tree = new TurboBinarySearchTree<int>();
        
        tree.Insert(3);
        tree.Insert(1);
        tree.Insert(5);
        
        Assert.That(tree, Is.EquivalentTo(new []{1,3,5}));
    }
    
    [Test]
    public void TestBalancingRightHeavyTree()
    {
        var tree = new TurboBinarySearchTree<int>();
        
        tree.Insert(4); tree.Insert(5); tree.Insert(6); 
        
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(2));
    }
    
    [Test]
    public void TestBalancingLeftHeavyTree()
    {
        var tree = new TurboBinarySearchTree<int>();
        
        tree.Insert(3); tree.Insert(2); tree.Insert(1); 
        
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(2));
    }
    
    [Test]
    public void TestLeftRightBalancingTree()
    {
        var tree = new TurboBinarySearchTree<int>();
        
        tree.Insert(3); tree.Insert(1); tree.Insert(2); 
        
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(2));
    }
    
    [Test]
    public void TestRightLeftBalancingTree()
    {
        var tree = new TurboBinarySearchTree<int>();
        
        tree.Insert(3); tree.Insert(5); tree.Insert(4); 
        
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(2));
    }
    

    [Test]
    public void TestSearchBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (int i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        tree.PrintTree();
        Assert.That(tree.Search(5), Is.EqualTo(true));
        Assert.That(tree.Search(22), Is.EqualTo(false));
    }

    [Test]
    public void TestTraversInOrderBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (int i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        Assert.That(tree, Is.EquivalentTo(new []{1,2,3,4,5,6,7,8,9,10}));
        Console.WriteLine("The tree in order:");
        foreach (var n in tree)
        {
            Console.Write($"{n} ");
        }
    }
    
    [Test]
    public void TestTraversInReverseOrderBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (int i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        Assert.That(tree.GetReverseEnumerator(), Is.EquivalentTo(new []{10,9,8,7,6,5,4,3,2,1}));
        Console.WriteLine("The tree reversed:");
        foreach (var n in (IEnumerable)tree.GetReverseEnumerator())
        {
            Console.Write($"{n} ");
        }
    }

    [Test]
    public void TestDeleteValueNoChildren()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (int i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        Assert.That(tree.Delete(22), Is.EqualTo(false));
        
        Console.WriteLine("Tree before deleting 10:");
        tree.PrintTree();
        Assert.That(tree.Delete(10), Is.EqualTo(true));
        Console.WriteLine("Tree after deleting 10:");
        tree.PrintTree();
    }
    
    [Test]
    public void TestDeleteValueOneChild()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (int i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        Console.WriteLine("Tree before deleting 9:");
        tree.PrintTree();
        Assert.That(tree.Delete(9), Is.EqualTo(true));
        Console.WriteLine("Tree after deleting 9:");
        tree.PrintTree();
    }
    
    [Test]
    public void TestDeleteValueTwoChildren()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (int i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        Console.WriteLine("Tree before deleting 2:");
        tree.PrintTree();
        Assert.That(tree.Delete(2), Is.EqualTo(true));
        Console.WriteLine("Tree after deleting 2:");
        tree.PrintTree();
    }
    
    [Test]
    public void TestDeleteValueRoot()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (int i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        Console.WriteLine("Tree before deleting the root:");
        tree.PrintTree();
        Assert.That(tree.Delete(4), Is.EqualTo(true));
        Console.WriteLine("Tree after deleting the root:");
        tree.PrintTree();
    }
    
    [Test]
    public void TestCloningTreeBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); 
        tree.Insert(3); tree.Insert(5); tree.Insert(7);

        var newTree = tree.Clone();

        Assert.That(tree, Is.EqualTo(newTree));
        Console.WriteLine("The original tree:");
        tree.PrintTree();
        Console.WriteLine("The cloned tree:");
        newTree.PrintTree();
    }
    
    [Test]
    public void TestDeleteTreeBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); 
        tree.Insert(3); tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree, Is.Not.Empty);
        
        tree.DeleteTree();
        Assert.That(tree, Is.Empty);
    }

    [Test]
    public void TestBstWithOtherTs()
    {
        var floatTree = new TurboBinarySearchTree<float>();
        var stringTree = new TurboBinarySearchTree<string>();
        var charTree = new TurboBinarySearchTree<char>();
        
        floatTree.Insert(0.5f); floatTree.Insert(4.5f);
        stringTree.Insert("hello"); stringTree.Insert("bye");
        charTree.Insert('b'); charTree.Insert('a'); charTree.Insert('c');
        
        Assert.That(floatTree.GetReverseEnumerator(), Is.EquivalentTo(new []{4.5f, 0.5f}));
        Console.WriteLine("The String tree contains:");
        foreach (var s in stringTree)
        {
            Console.Write($"{s} ");
        }
        Console.WriteLine("\nThe Char tree contains:");
        foreach (var c in charTree)
        {
            Console.Write($"{c} ");
        }
        Console.WriteLine("\nThe Char tree reversed:");
        foreach (var r in (IEnumerable)charTree.GetReverseEnumerator())
        {
            Console.Write($"{r} ");
        }
    }
}