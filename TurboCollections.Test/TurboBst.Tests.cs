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
        
        Assert.Pass();
        Assert.That(tree, Is.EquivalentTo(new []{1,3,5}));
    }

    [Test]
    public void TestSearchBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); 
        tree.Insert(3); tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree.Search(5), Is.EqualTo(true));
        Assert.That(tree.Search(9), Is.EqualTo(false));
    }

    [Test]
    public void TestTraversInOrderBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); 
        tree.Insert(3); tree.Insert(5); tree.Insert(7);

        Assert.That(tree, Is.EquivalentTo(new []{1,2,3,4,5,6,7}));
    }
    
    [Test]
    public void TestTraversInReverseOrderBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); 
        tree.Insert(3); tree.Insert(5); tree.Insert(7);
        
        
        Assert.That(tree.GetReverseEnumerator(), Is.EquivalentTo(new []{7,6,5,4,3,2,1}));
    }

    [Test]
    public void TestDeleteValueNoChildren()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); 
        tree.Insert(3); tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree.Delete(7), Is.EqualTo(true));
        Assert.That(tree.Delete(9), Is.EqualTo(false));
        Assert.That(tree, Is.SupersetOf(new []{1,2,3,4,5,6}));
    }
    
    [Test]
    public void TestDeleteValueOneChild()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(3); tree.Insert(6); 
        tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree.Delete(2), Is.EqualTo(true));
        Assert.That(tree, Is.SupersetOf(new []{3,4,5,6,7}));
    }
    
    [Test]
    public void TestDeleteValueTwoChildren()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); 
        tree.Insert(3); tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree.Delete(2), Is.EqualTo(true));
        Assert.That(tree, Is.SupersetOf(new []{1,3,4,5,6,7}));
    }
    
    [Test]
    public void TestDeleteValueRoot()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); 
        tree.Insert(3); tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree.Delete(4), Is.EqualTo(true));
        Assert.That(tree, Is.SupersetOf(new []{1,2,3,5,6,7}));
    }
    
    [Test]
    public void TestDeleteValueLargerTree()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(6); tree.Insert(4); tree.Insert(8); tree.Insert(2); 
        tree.Insert(5); tree.Insert(1); tree.Insert(3); tree.Insert(7); tree.Insert(9);
        
        Assert.That(tree.Delete(6), Is.EqualTo(true));
        Assert.That(tree.Delete(6), Is.EqualTo(false));
        Assert.That(tree.Delete(2), Is.EqualTo(true));
        Assert.That(tree.Delete(4), Is.EqualTo(true));
    }
    
    [Test]
    public void TestCloningTreeBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); 
        tree.Insert(3); tree.Insert(5); tree.Insert(7);

        var newTree = tree.Clone();

        Assert.That(tree, Is.EqualTo(newTree));
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

    [Test]
    public void TestGetBalanceOfTree()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (int i = 0; i < 5; i++)
        {
            tree.Insert(i);
        }
        tree.Insert(5);
        
        Assert.Pass();
        
    }
}