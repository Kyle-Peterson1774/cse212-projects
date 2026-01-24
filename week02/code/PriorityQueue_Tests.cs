using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities.
    // Expected Result: Dequeue returns the item with the highest priority.
    // Defect(s) Found: I didnt find a defect. 
    public void TestPriorityQueue_HighestPriorityWins()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var result = pq.Dequeue();
        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario: Two items share the highest priority.
    // Expected Result: Dequeue returns the first enqueued item among the tied highest-priority items (FIFO tie-break).
    // Defect(s) Found: when multiple items shared the highest priority, the queue did not consistently
    // return the correct next highest-priority item after the first dequeue. The remaining highest-
    // priority item was skipped, and a lower-priority item was returned instead.
    public void TestPriorityQueue_TieBreaksByFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 1);
        pq.Enqueue("C", 5);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Highest priority item is the LAST item enqueued.
    // Expected Result: Dequeue still returns the last item because it has the highest priority.
    // Defect(s) Found: The queue failed to consider the last item when determining the highest
    // priority due to an off-by-one error in the search loop, which created an incorrect item to be returned.
    public void TestPriorityQueue_LastItemCanBeHighest()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 10); // highest at the end

        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue should remove an item from the queue.
    // Expected Result: After dequeuing the highest item, the next dequeue returns the next highest item, not the same one again.
    // Defect(s) Found: Dequeue returned the correct value but did not remove the item from the queue,
    // this caused the same value being returned repeatedly.
    public void TestPriorityQueue_DequeueRemovesItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 3);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
    }
}
