// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ------------------------------------------------------------------
// UnitTest1.cs                                                                     
// MS Test program to test custom MyList<T> class.
// ------------------------------------------------------------------------------------------------
using Classlib;
namespace MsTest;

[TestClass]
#region Test Class --------------------------------------------------------------------------------
public class TestMyListT {
   #region Test Methods ---------------------------------------------
   [TestMethod]
   public void TestAdd () {
      mMyList.Add (1);
      mMyList.Add (2);
      mMyList.Add (2);
      mMyList.Add (2);
      Assert.IsTrue (mMyList[0] == 1);
      Assert.AreEqual (4, mMyList.Capacity);
      mMyList.Add (4);
      Assert.AreEqual (8, mMyList.Capacity);
      mList.Add (1);
      mList.Add (2);
      mList.Add (2);
      mList.Add (2);
      mList.Add (4);
      for (int i = 0; i < mList.Count; i++)
         Assert.AreEqual (mList[i], mMyList[i]);
   }

   [TestMethod]
   public void TestClear () {
      mMyList.Add (1);
      mList.Add (1);
      Assert.AreEqual (1, mMyList.Count);
      mMyList.Clear ();
      mList.Clear ();
      Assert.AreEqual (0, mMyList.Count);
      Assert.IsTrue (mMyList.Count == 0);
      Assert.IsTrue (mList.Count == 0);
      for (int i = 0; i < mList.Count; i++)
         Assert.AreEqual (mList[i], mMyList[i]);
   }

   [TestMethod]
   public void TestInsert () {
      mMyList.Add (1);
      mMyList.Add (1);
      mMyList.Add (1);
      mMyList.Add (1);
      mMyList.Insert (0, 5);
      Assert.AreEqual (5, mMyList[0]);
      mList.Add (1);
      mList.Add (1);
      mList.Add (1);
      mList.Add (1);
      mList.Insert (0, 5);
      for (int i = 0; i < mList.Count; i++)
         Assert.AreEqual (mList[i], mMyList[i]);
      Assert.ThrowsException<IndexOutOfRangeException> (() => mMyList.Insert (-1, 2));
      Assert.ThrowsException<IndexOutOfRangeException> (() => mMyList.Insert (10, 2));
   }

   [TestMethod]
   public void TestRemove () {
      mMyList.Add (1);
      mMyList.Add (2);
      mMyList.Add (3);
      Assert.IsTrue (mMyList.Remove (3));
      mList.Add (1);
      mList.Add (2);
      mList.Add (3);
      Assert.IsTrue (mList.Remove (3));
      for (int i = 0; i < mList.Count; i++)
         Assert.AreEqual (mList[i], mMyList[i]);
      Assert.ThrowsException<InvalidOperationException> (() => mMyList.Remove (10));
   }

   [TestMethod]
   public void TestRemoveAt () {
      mMyList.Add (1);
      mMyList.Add (2);
      mMyList.Add (3);
      int prevCount = mMyList.Count;
      mMyList.RemoveAt (0);
      Assert.AreEqual (prevCount - 1, mMyList.Count);
      mList.Add (1);
      mList.Add (2);
      mList.Add (3);
      mList.RemoveAt (0);
      for (int i = 0; i < mList.Count; i++)
         Assert.AreEqual (mList[i], mMyList[i]);
      Assert.ThrowsException<IndexOutOfRangeException> (() => mMyList.RemoveAt (-1));
      Assert.ThrowsException<IndexOutOfRangeException> (() => mMyList.Insert (10, 2));
   }

   [TestMethod]
   public void TestThisOp () {
      mMyList.Add (1);
      mMyList.Add (2);
      mMyList.Add (3);
      mMyList[2] = 5;
      mList.Add (1);
      mList.Add (2);
      mList.Add (3);
      mList[2] = 5;
      Assert.AreEqual (mList[2], mMyList[2]);
      Assert.ThrowsException<IndexOutOfRangeException> (() => mMyList.RemoveAt (-1));
   }
   #endregion

   #region Private Data ---------------------------------------------
   MyList<int> mMyList = new ();
   List<int> mList = new ();
   #endregion
}
#endregion
