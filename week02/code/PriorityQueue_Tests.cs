using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: A priority queue is created, and three items with different priorities are added.
    //           The items are then dequeued sequentially.
    // Expected Result: Items should be dequeued according to their priority, with the highest-priority item dequeued first.
    // Defect(s) Found: The dequeue method fails to remove items from the queue, and the for-loop condition is incorrect.
    //                  The correct condition should be: index <= _queue.Count - 1.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 1);
        priorityQueue.Enqueue("Task2", 2);
        priorityQueue.Enqueue("Task3", 3);
        Assert.AreEqual("Task3", priorityQueue.Dequeue(), "Highest priority item should be Task3");
        Assert.AreEqual("Task2", priorityQueue.Dequeue(), "Next highest priority item should be Task2");
        Assert.AreEqual("Task1", priorityQueue.Dequeue(), "Last item should be Task1");
    }

    [TestMethod]
    // Scenario: Multiple items with the same priority are added to the queue.
    //           When dequeued, the items should be returned in the order in which they were added.
    // Expected Result: The order of dequeued items should match the order in which they were enqueued.
    // Defect(s) Found: The dequeue method does not correctly handle cases where multiple items share the same priority.
    //                  As implemented, it returns the most recently added item with the highest priority.
    //                  Removing the '=' operator from the if-statement preserves the first highest-priority item,
    //                  ensuring it is dequeued in the correct order.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Task1", 1);
        priorityQueue.Enqueue("Task2", 1);
        priorityQueue.Enqueue("Task3", 1);
        Assert.AreEqual("Task1", priorityQueue.Dequeue(), "First item should be Task1");
        Assert.AreEqual("Task2", priorityQueue.Dequeue(), "Second item should be Task2");
        Assert.AreEqual("Task3", priorityQueue.Dequeue(), "Last item should be Task3");
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Verify that the queue correctly handles operations on an empty queue.
    // Expected Result: An exception should be thrown when attempting to dequeue from an empty queue.
    // Defect(s) Found: The dequeue method does not properly handle the empty-queue condition,
    //                  as it fails to throw the expected exception.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Dequeue should have thrown an exception when the queue is empty.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}