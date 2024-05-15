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
    }

    [Test]
    public void TestSearchBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); tree.Insert(3); tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree.Search(5), Is.EqualTo(true));
        Assert.That(tree.Search(9), Is.EqualTo(false));
        
    }

    [Test]
    public void TestTraversInOrderBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); tree.Insert(3); tree.Insert(5); tree.Insert(7);

        CollectionAssert.AreEqual(new []{1,2,3,4,5,6,7}, tree);
    }
    
    [Test]
    public void TestTraversInReverseOrderBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); tree.Insert(3); tree.Insert(5); tree.Insert(7);

        CollectionAssert.AreEqual(new []{7,6,5,4,3,2,1}, tree.Reverse());
    }

    [Test]
    public void TestDeleteValueNoChildren()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); tree.Insert(3); tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree.Delete(7), Is.EqualTo(true));
        CollectionAssert.AreEqual(new []{1,2,3,4,5,6}, tree);
    }
    
    [Test]
    public void TestDeleteValueOneChild()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(3); tree.Insert(6); tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree.Delete(2), Is.EqualTo(true));
        CollectionAssert.AreEqual(new []{3,4,5,6,7}, tree);
    }
    
    [Test]
    public void TestDeleteValueTwoChildren()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); tree.Insert(3); tree.Insert(5); tree.Insert(7);
        
        Assert.That(tree.Delete(2), Is.EqualTo(true));
        CollectionAssert.AreEqual(new []{1,3,4,5,6,7}, tree);
    }
    
    [Test]
    public void TestCloningTreeBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4); tree.Insert(2); tree.Insert(6); tree.Insert(1); tree.Insert(3); tree.Insert(5); tree.Insert(7);

        var newtree = tree.Clone();

        CollectionAssert.AreEqual(newtree, tree);
    }
}