using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Basic dequeue behavior with mixed priorities.
    // Expected Result: Item with highest priority (20) is removed first.
    // Defect(s) Found: None.
    public void TestPriorityQueue_1()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("low", 5);
        queue.Enqueue("medium", 10);
        queue.Enqueue("high", 20);

        var result = queue.Dequeue();
        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario: Tie in priorities — should respect FIFO.
    // Expected Result: First "alpha" with priority 10 is removed before "beta" with same priority.
    // Defect(s) Found: None.
    public void TestPriorityQueue_2()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("alpha", 10);
        queue.Enqueue("beta", 10);
        queue.Enqueue("gamma", 5);

        var result = queue.Dequeue();
        Assert.AreEqual("alpha", result);
    }
    
    [TestMethod]
    // Scenario: Dequeue on empty queue
    // Expected Result: InvalidOperationException is thrown
    // Defect(s) Found: None.
    public void TestPriorityQueue_EmptyQueueThrows()
    {
        var queue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
    }

    // Add more test cases as needed below.
}