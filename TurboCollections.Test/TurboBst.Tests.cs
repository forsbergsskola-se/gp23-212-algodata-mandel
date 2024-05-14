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

        tree.Insert(3);
        tree.Insert(1);
        tree.Insert(2);
        tree.Insert(5);
        tree.Insert(4);
        
        Assert.That(tree.Search(5), Is.EqualTo(true));
        Assert.That(tree.Search(6), Is.EqualTo(false));
        
    }
    
    
    
}