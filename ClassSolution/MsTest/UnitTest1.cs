// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ------------------------------------------------------------------
// UnitTest1.cs                                                                     
// Test Program to cover a custom MyStack<T> class using arrays as the underlying data structure.
// The MyStack<T> should start with an initial capacity of 4 and double its capacity when needed. 
// ------------------------------------------------------------------------------------------------
namespace MsTest;
using Classlib;
[TestClass]
public class UnitTest1 {
   #region Test Methods ---------------------------------------------
   [TestMethod]
   public void TestPeek () {
      Assert.IsTrue (stack.IsEmpty);
      Assert.ThrowsException<InvalidOperationException> (() => stack.Peek ());
      stack.Push (1);
      stack.Push (2);
      stack.Push (3);
      stack.Push (4);
      Assert.IsFalse (stack.IsEmpty);
      Assert.AreEqual (4, stack.Peek ());
      Assert.AreEqual (4, stack.Count);
      Assert.AreEqual (4, stack.Capacity);
   }

   [TestMethod]
   public void TestPop () {
      Assert.ThrowsException<InvalidOperationException> (() => stack.Pop ());
      stack.Push (1);
      stack.Push (2);
      stack.Push (3);
      stack.Push (4);
      Assert.AreEqual (4, stack.Pop ());
      Assert.AreEqual (3, stack.Count);
      Assert.AreEqual (4, stack.Capacity);
   }

   [TestMethod]
   public void TestPush () {
      Assert.IsTrue (stack.IsEmpty);
      stack.Push (1);
      Assert.AreEqual (1, stack.Peek ());
      stack.Push (2);
      Assert.IsFalse (stack.IsEmpty);
      stack.Push (3);
      Assert.AreEqual (3, stack.Peek ());
      stack.Push (4);
      Assert.AreEqual (4, stack.Peek ());
      stack.Push (5);
      Assert.AreEqual (5, stack.Peek ());
      Assert.AreEqual (5, stack.Count);
      Assert.AreEqual(8, stack.Capacity);
   }
   #endregion

   #region Private Data ---------------------------------------------
   MyStack<int> stack = new ();
   #endregion
}