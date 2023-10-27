using Classlib;
namespace MsTest;

[TestClass]
public class TestMyQueueT {
   #region Method ---------------------------------------------------
   [TestMethod]
   public void TestDequeue () {
      Assert.IsTrue (mMyQueue.IsEmpty);
      Assert.ThrowsException<InvalidOperationException> (() => mMyQueue.Dequeue ());
      mMyQueue.Enqueue (1);
      mMyQueue.Enqueue (2);
      mMyQueue.Enqueue (3);
      mQueue.Enqueue (1);
      mQueue.Enqueue (2);
      mQueue.Enqueue (3);
      Assert.AreEqual (mQueue.Dequeue (), mMyQueue.Dequeue ());
      Assert.IsFalse (mMyQueue.IsEmpty);
   }

   [TestMethod]
   public void TestEnqueue () {
      mMyQueue.Enqueue (1);
      mMyQueue.Enqueue (2);
      mMyQueue.Enqueue (3);
      mQueue.Enqueue (1);
      mQueue.Enqueue (2);
      mQueue.Enqueue (3);
      Assert.AreEqual (mQueue.Count, mMyQueue.Count);
      mMyQueue.Enqueue (4);
      mMyQueue.Enqueue (5);
      mQueue.Enqueue (4);
      mQueue.Enqueue (5);
      Assert.AreEqual (mQueue.Count, mMyQueue.Count);
      Assert.AreEqual (8, mMyQueue.Capacity);
      for (int i = 1; i <= 3; i++)
         Assert.AreEqual (mQueue.Dequeue (), mMyQueue.Dequeue ());
   }

   [TestMethod]
   public void TestPeek () {
      Assert.IsTrue (mMyQueue.IsEmpty);
      Assert.ThrowsException<InvalidOperationException> (() => mMyQueue.Peek ());
      mMyQueue.Enqueue (1);
      mMyQueue.Enqueue (2);
      mMyQueue.Enqueue (3);
      mQueue.Enqueue (1);
      mQueue.Enqueue (2);
      mQueue.Enqueue (3);
      Assert.AreEqual (mQueue.Peek (), mMyQueue.Peek ());
      Assert.AreEqual (mQueue.Count, mMyQueue.Count);
   }

   [TestMethod]
   public void TestToString () {
      mMyQueue.Enqueue (1);
      mMyQueue.Enqueue (2);
      mMyQueue.Enqueue (3);
      Assert.AreEqual ("1 2 3 ", mMyQueue.ToString ());
   }
   #endregion

   #region Private Data ---------------------------------------------
   MyQueue<int> mMyQueue = new ();
   Queue<int> mQueue = new ();
   #endregion
}