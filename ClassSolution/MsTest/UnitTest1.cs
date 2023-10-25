// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ------------------------------------------------------------------
// UnitTest1.cs                                                                     
// MS Test program to test custom MyList<T> class.
// ------------------------------------------------------------------------------------------------
namespace MsTest;
using Classlib;

[TestClass]
#region Test Class --------------------------------------------------------------------------------
public class UnitTest1 {

   #region Test Methods ---------------------------------------------
   [TestMethod]
   public void TestAdd () {
      myList.Add (1);
      Assert.IsTrue (myList[0] == 1);
      myList.Add (2);
      myList.Add (2);
      myList.Add (2);
      Assert.AreEqual (4, myList.Capacity);
      myList.Add (4);
      Assert.AreEqual (8, myList.Capacity);
   }

   [TestMethod]
   public void TestClear () {
      myList.Add (1);
      Assert.AreEqual (1, myList.Count);
      myList.Clear ();
      Assert.AreEqual (0, myList.Count);
   }

   [TestMethod]
   public void TestInsert () {
      myList.Add (1);
      myList.Add (1);
      myList.Add (1);
      myList.Add (1);
      myList.Insert (0, 5);
      Assert.AreEqual (5, myList[0]);
      Assert.ThrowsException<IndexOutOfRangeException> (() => myList.Insert (-1, 2));
      Assert.ThrowsException<IndexOutOfRangeException> (() => myList.Insert (10, 2));
   }

   [TestMethod]
   public void TestRemove () {
      myList.Add (1);
      myList.Add (2);
      myList.Add (3);
      Assert.IsTrue (myList.Remove (3));
      Assert.ThrowsException<InvalidOperationException> (() => myList.Remove (10));
   }

   [TestMethod]
   public void TestRemoveAt () {
      myList.Add (1);
      myList.Add (2);
      myList.Add (3);
      int prevCount = myList.Count;
      myList.RemoveAt (0);
      Assert.AreEqual (prevCount - 1, myList.Count);
      Assert.ThrowsException<IndexOutOfRangeException> (() => myList.RemoveAt (-1));
      Assert.ThrowsException<IndexOutOfRangeException> (() => myList.Insert (10, 2));
   }

   [TestMethod]
   public void TestThisOp () {
      myList.Add (1);
      myList.Add (2);
      myList.Add (3);
      myList[2] = 5;
      Assert.AreEqual (5, myList[2]);
      Assert.ThrowsException<IndexOutOfRangeException> (() => myList.RemoveAt (-1));
   }
   #endregion

   #region Private Data ---------------------------------------------
   MyList<int> myList = new ();
   #endregion
}
#endregion
