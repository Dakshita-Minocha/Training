using Classlib;
namespace MsTest;

[TestClass]
public class TestMyQueueT {
   #region Method ---------------------------------------------------
   [TestMethod]
   public void TestDequeue () {
      Assert.IsTrue (mMyQueue.IsEmpty);
      Assert.ThrowsException<InvalidOperationException> (() => mMyQueue.Dequeue ());
      for (int i = 1; i < 5; i++) {
         mMyQueue.Enqueue (i);
         mQueue.Enqueue (i);
      }
      Assert.AreEqual (mQueue.Dequeue (), mMyQueue.Dequeue ());
      Assert.AreEqual (mQueue.Dequeue (), mMyQueue.Dequeue ());
      for (int i = 5; i < 7; i++) {
         mMyQueue.Enqueue (i);
         mQueue.Enqueue (i);
      }
      Assert.AreEqual (mQueue.Dequeue (), mMyQueue.Dequeue ());
      Assert.IsFalse (mMyQueue.IsEmpty);
   }

   [TestMethod]
   public void TestEnqueue () {
      for (int i = 1; i < 5; i++) {
         mMyQueue.Enqueue (i);
         mQueue.Enqueue (i);
      }
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
      for (int i = 0; i < 3; i++) {
         mMyQueue.Enqueue (i);
         mQueue.Enqueue (i);
         Assert.AreEqual (mQueue.Peek (), mMyQueue.Peek ());
      }
      Assert.AreEqual (mQueue.Count, mMyQueue.Count);
   }

   [TestMethod]
   public void TestToString () {
      for (int i = 1; i < 4; i++)
         mMyQueue.Enqueue (i);
      Assert.AreEqual ("1 2 3 ", mMyQueue.ToString ());
      for (int i = 4; i < 9; i++)
         mMyQueue.Enqueue (i);
      Assert.AreEqual ("1 2 3 4 5 6 7 8 ", mMyQueue.ToString ());
   }
   #endregion

   #region Private Data ---------------------------------------------
   MyQueue<int> mMyQueue = new ();
   Queue<int> mQueue = new ();
   #endregion
}