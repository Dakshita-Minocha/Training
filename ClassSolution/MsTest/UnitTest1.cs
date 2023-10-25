using Classlib;
namespace MsTest;

[TestClass]
public class UnitTest1 {
   #region Method ---------------------------------------------------
   [TestMethod]
   public void TestDequeue () {
      Assert.IsTrue (queue.IsEmpty);
      Assert.ThrowsException<InvalidOperationException> (() => queue.Dequeue ());
      queue.Enqueue (1);
      queue.Enqueue (2);
      queue.Enqueue (3);
      Assert.AreEqual (1, queue.Dequeue ());
      Assert.IsFalse (queue.IsEmpty);
   }

   [TestMethod]
   public void TestEnqueue () {
      queue.Enqueue (1);
      queue.Enqueue (2);
      queue.Enqueue (3);
      Assert.AreEqual (3, queue.Count);
      queue.Enqueue (4);
      queue.Enqueue (5);
      Assert.AreEqual (5, queue.Count);
      Assert.AreEqual (8, queue.Capacity);
      for (int i = 1; i <= 3; i++)
         Assert.AreEqual (i, queue.Dequeue ());
   }

   [TestMethod]
   public void TestPeek () {
      Assert.IsTrue (queue.IsEmpty);
      Assert.ThrowsException<InvalidOperationException> (() => queue.Peek ());
      queue.Enqueue (1);
      queue.Enqueue (2);
      queue.Enqueue (3);
      Assert.AreEqual (1, queue.Peek ());
      Assert.AreEqual (3, queue.Count);
   }

   [TestMethod]
   public void TestToString () {
      queue.Enqueue (1);
      queue.Enqueue (2);
      queue.Enqueue (3);
      Assert.AreEqual ("1 2 3 ", queue.ToString ());
   }
   #endregion

   #region Private Data ---------------------------------------------
   TQueue<int> queue = new ();
   #endregion
}