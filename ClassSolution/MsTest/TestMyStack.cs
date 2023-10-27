// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ------------------------------------------------------------------
// TestMyStack.cs                                                                     
// Test Program to cover a custom MyStack<T> class using arrays as the underlying data structure.
// The MyStack<T> should start with an initial capacity of 4 and double its capacity when needed. 
// ------------------------------------------------------------------------------------------------
using Classlib;
namespace MsTest;

[TestClass]
public class TestMyStack {
   #region Test Methods ---------------------------------------------
   [TestMethod]
   public void TestPeek () {
      Assert.IsTrue (mMyStack.IsEmpty);
      Assert.ThrowsException<InvalidOperationException> (() => mMyStack.Peek ());
      mMyStack.Push (1);
      mMyStack.Push (2);
      mMyStack.Push (3);
      mMyStack.Push (4);
      Assert.IsFalse (mMyStack.IsEmpty);
      mStack.Push (1);
      mStack.Push (2);
      mStack.Push (3);
      mStack.Push (4);
      Assert.AreEqual (mStack.Peek (), mMyStack.Peek ());
      Assert.AreEqual (mStack.Count, mMyStack.Count);
      Assert.AreEqual (4, mMyStack.Capacity);
   }

   [TestMethod]
   public void TestPop () {
      Assert.ThrowsException<InvalidOperationException> (() => mMyStack.Pop ());
      mMyStack.Push (1);
      mMyStack.Push (2);
      mMyStack.Push (3);
      mMyStack.Push (4);
      mStack.Push (1);
      mStack.Push (2);
      mStack.Push (3);
      mStack.Push (4);
      Assert.AreEqual (mStack.Pop (), mMyStack.Pop ());
      Assert.AreEqual (mStack.Count, mMyStack.Count);
      Assert.AreEqual (4, mMyStack.Capacity);
   }

   [TestMethod]
   public void TestPush () {
      Assert.IsTrue (mMyStack.IsEmpty);
      mMyStack.Push (1);
      mStack.Push (1);
      Assert.AreEqual (mStack.Peek (), mMyStack.Peek ());
      mMyStack.Push (2);
      mStack.Push (2);
      Assert.IsFalse (mMyStack.IsEmpty);
      mMyStack.Push (3);
      mStack.Push (3);
      Assert.AreEqual (mStack.Peek (), mMyStack.Peek ());
      mMyStack.Push (4);
      mStack.Push (4);
      Assert.AreEqual (mStack.Peek (), mMyStack.Peek ());
      mMyStack.Push (5);
      mStack.Push (5);
      Assert.AreEqual (mStack.Peek (), mMyStack.Peek ());
      Assert.AreEqual (mStack.Count, mMyStack.Count);
      Assert.AreEqual (8, mMyStack.Capacity);
   }
   #endregion

   #region Private Data ---------------------------------------------
   MyStack<int> mMyStack = new ();
   Stack<int> mStack = new ();
   #endregion
}