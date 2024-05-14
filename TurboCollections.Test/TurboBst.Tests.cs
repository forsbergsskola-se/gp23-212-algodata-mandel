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

        tree.Insert(4);
        tree.Insert(2);
        tree.Insert(6);
        tree.Insert(1);
        tree.Insert(3);
        tree.Insert(5);
        tree.Insert(7);
        
        Assert.That(tree.Search(5), Is.EqualTo(true));
        Assert.That(tree.Search(9), Is.EqualTo(false));
        
    }

    [Test]
    public void TestTraversInOrderBst()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4);
        tree.Insert(2);
        tree.Insert(6);
        tree.Insert(1);
        tree.Insert(3);
        tree.Insert(5);
        tree.Insert(7);

        CollectionAssert.AreEqual(new []{1,2,3,4,5,6,7}, tree);
    }

    [Test]
    public void TestDeleteValueFromTree()
    {
        var tree = new TurboBinarySearchTree<int>();

        tree.Insert(4);
        tree.Insert(2);
        tree.Insert(6);
        tree.Insert(1);
        tree.Insert(3);
        tree.Insert(5);
        tree.Insert(7);
        
        Assert.That(tree.Delete(5), Is.EqualTo(true));
        CollectionAssert.AreEqual(new []{1,2,3,4,6,7}, tree);
    }
}