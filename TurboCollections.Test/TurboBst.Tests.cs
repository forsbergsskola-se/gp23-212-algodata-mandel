using System.Collections;

namespace TurboCollections.Test;

public class TurboBstTests
{
    [Test]
    public void TestInsertionToTree()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (var i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        Assert.That(tree, Is.EquivalentTo(new []{1,2,3,4,5,6,7,8,9,10}));
        Console.WriteLine("Inserted values 1 - 10;");
        tree.PrintTree();
    }
    [Test]
    public void TestBalancingRightHeavyTree()
    {
        var tree = new TurboBinarySearchTree<int>();
        
        tree.Insert(4); tree.Insert(5); tree.Insert(6); 
        
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(2));
        Console.WriteLine("Inserted 4 - 5 - 3 -> Left rotation on 5;");
        tree.PrintTree();
    }
    
    [Test]
    public void TestBalancingLeftHeavyTree()
    {
        var tree = new TurboBinarySearchTree<int>();
        
        tree.Insert(3); tree.Insert(2); tree.Insert(1); 
        
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(2));
        Console.WriteLine("Inserted 3 - 2 - 1 -> Right rotation on 2;");
        tree.PrintTree();
    }
    
    [Test]
    public void TestBalancingLeftRightTree()
    {
        var tree = new TurboBinarySearchTree<int>();
        
        tree.Insert(3); tree.Insert(1); tree.Insert(2); 
        
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(2));
        Console.WriteLine("Inserted 3 - 1 - 2 -> Left-Right rotation;");
        tree.PrintTree();
    }
    
    [Test]
    public void TestBalancingRightLeftTree()
    {
        var tree = new TurboBinarySearchTree<int>();
        
        tree.Insert(3); tree.Insert(5); tree.Insert(4); 
        
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(2));
        Console.WriteLine("Inserted 3 - 5 - 4 -> Right-Left rotation;");
        tree.PrintTree();
    }
    

    [Test]
    public void TestSearchBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (var i = 1; i <= 10; i++)
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

        for (var i = 1; i <= 10; i++)
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

        for (var i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        Assert.That(tree, Is.EquivalentTo(new []{10,9,8,7,6,5,4,3,2,1}));
        Console.WriteLine("The tree in reversed order:");
        foreach (var n in (IEnumerable)tree.GetReverseEnumerator())
        {
            Console.Write($"{n} ");
        }
    }
    
    [Test]
    public void TestTraversPreOrderBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (var i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        Assert.That(tree.GetPreEnumerator(), Is.EquivalentTo(new []{4,2,1,3,8,6,5,7,9,10}));
        Console.WriteLine("The tree traversed PreOrder: (used when cloning)");
        foreach (var n in (IEnumerable)tree.GetPreEnumerator())
        {
            Console.Write($"{n} ");
        }
    }

    [Test]
    public void TestDeleteValueNoChildren()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (var i = 1; i <= 10; i++)
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

        for (var i = 1; i <= 10; i++)
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

        for (var i = 1; i <= 10; i++)
        {
            tree.Insert(i);
        }
        
        Console.WriteLine("Tree before deleting 8:");
        tree.PrintTree();
        Assert.That(tree.Delete(8), Is.EqualTo(true));
        Console.WriteLine("Tree after deleting 8:");
        tree.PrintTree();
    }
    
    [Test]
    public void TestDeleteValueRoot()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (var i = 1; i <= 10; i++)
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

        for (var i = 1; i <= 7; i++)
        {
            tree.Insert(i);
        }

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
        var tree = new TurboBinarySearchTree<char>();

        for (char i = 'a'; i <= 'g'; i++)
        {
            tree.Insert(i);
        }
        
        Assert.That(tree, Is.Not.Empty);
        Console.WriteLine("The tree contains:");
        foreach (var c in tree)
        {
            Console.Write($"{c} ");
        }
        
        tree.DeleteTree();
        Assert.That(tree, Is.Empty);
        Console.WriteLine("\nAfter deleting, the tree contains:");
        foreach (var c in tree)
        {
            Console.Write($"{c} ");
        }
        
    }

    [Test]
    public void TestBstWithOtherTs()
    {
        var floatTree = new TurboBinarySearchTree<float>();
        var stringTree = new TurboBinarySearchTree<string>();
        var charTree = new TurboBinarySearchTree<char>();
        
        floatTree.Insert(0.5f); floatTree.Insert(4.5f); floatTree.Insert(6f);
        stringTree.Insert("Tree");stringTree.Insert("Binary"); stringTree.Insert("Search");
        charTree.Insert('a'); charTree.Insert('b'); charTree.Insert('c');
        
        Assert.That(floatTree.GetTreeHeight(), Is.EqualTo(2));
        Console.WriteLine("The floatTree:");
        floatTree.PrintTree();
        
        Console.WriteLine("\nThe String tree contains:");
        foreach (var s in stringTree)
        {
            Console.Write($"{s} ");
        }
        Console.WriteLine("\n \nThe Char tree contains:");
        foreach (var c in charTree)
        {
            Console.Write($"{c} ");
        }
        Console.WriteLine("\n \nThe Char tree reversed:");
        foreach (var r in (IEnumerable)charTree.GetReverseEnumerator())
        {
            Console.Write($"{r} ");
        }
    }

    [Test]
    public void TestBalancingTreeWith100Nodes()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (var i = 1; i <= 100; i++)
        {
            tree.Insert(i);
        }

        // The height of the balanced tree is O(log(n)) 
        Console.WriteLine($"A tree with 100 nodes has a height of ≈ {MathF.Round(MathF.Log2(100))}");
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(MathF.Log2(100)).Within(1)); // Allowing a margin of 1 for variations
    }
    
    [Test]
    public void TestBalancingTreeWith1000Nodes()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (var i = 1; i <= 1000; i++)
        {
            tree.Insert(i);
        }
        
        Console.WriteLine($"A tree with 1000 nodes has a height of ≈ {MathF.Round(MathF.Log2(1000))}");
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(MathF.Log2(1000)).Within(1));
    }
    
    [Test]
    public void TestBalancingTreeWith100000Nodes()
    {
        var tree = new TurboBinarySearchTree<int>();

        for (var i = 1; i <= 100000; i++)
        {
            tree.Insert(i);
        }
        
        Console.WriteLine($"A tree with 100 000 nodes has a height of ≈ {MathF.Round(MathF.Log2(100000))}");
        Assert.That(tree.GetTreeHeight(), Is.EqualTo(MathF.Log2(100000)).Within(1));
    }
}