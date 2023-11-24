// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// TestTraining.cs
// Test Program for Double Ended Queue.
// ------------------------------------------------------------------------------------------------
using Training;
namespace TestTraining;

[TestClass]
public class TestDoubleQueue {
   [TestMethod]
   public void TestProperties () {
      Assert.IsTrue (mQ.IsEmpty);
      AddToQ (1);
      Assert.IsFalse (mQ.IsEmpty);
      Equals (mQ.Count, 1);
      Equals (mQ.Capacity, 4);
      AddToQ (4);
      Equals (mQ.Count, 5);
      Equals (mQ.Capacity, 8);
   }

   [TestMethod]
   public void TestEnqueue () {
      mQ.BackEnqueue (1);
      mQ.BackEnqueue (2);
      mQ.BackEnqueue (3);
      mQ.BackEnqueue (4);
      Equals (mQ.ToString (), "1 2 3 4 ");
      mQ.FrontDequeue ();
      mQ.BackEnqueue (5);
      mQ.BackEnqueue (5);
      Equals (mQ.ToString (), "2 3 4 5 5 ");
      mQ.FrontDequeue ();
      mQ.FrontEnqueue (-1);
      Equals (mQ, "-1 3 4 5 5 ");
      mQ.FrontEnqueue (-2);
      Equals (mQ.Count, 5);
      Equals (mQ.Capacity, 8);
      mQ.FrontEnqueue (-3);
      Equals (mQ, "-3 -2 -1 3 4 5 5 ");
      mQ.BackEnqueue (1);
      mQ.BackEnqueue (2);
      mQ.BackEnqueue (4);
      Equals (mQ, "-3 -2 -1 3 4 5 1 2 4 5 ");
   }

   [TestMethod]
   public void TestDequeue () {
      Assert.ThrowsException<InvalidOperationException> (() => mQ.BackDequeue ());
      Assert.ThrowsException<InvalidOperationException> (() => mQ.FrontDequeue ());
      mQ.BackEnqueue (1);
      mQ.BackEnqueue (2);
      mQ.BackEnqueue (3);
      mQ.BackEnqueue (4);
      Equals (mQ.FrontDequeue (), 1);
      Equals (mQ.Count, 3);
      mQ.BackEnqueue (5);
      Equals (mQ.BackDequeue (), 5);
      Equals (mQ.FrontDequeue (), 2);
      Equals (mQ.Count, 2);
      mQ.FrontEnqueue (-1);
      mQ.FrontEnqueue (-2);
      mQ.FrontEnqueue (-3);
      Equals (mQ.Count, 5);
      Equals (mQ.FrontDequeue (), -3);
      Equals (mQ.Capacity, 8);
      Equals (mQ.Count, 4);
      mQ.BackEnqueue (1);
      mQ.BackEnqueue (2);
      mQ.BackEnqueue (4);
      Equals (mQ.Count, 5);
      Equals (mQ.BackDequeue (), 4);
      Equals (mQ.Capacity, 8);
      Equals (mQ.Count, 4);
      Assert.ThrowsException<InvalidOperationException> (() => Remove (mQ.Count + 1));
   }

   /// <summary>Checks if two elements are equal.</summary>
   public void Equals (string actual, string expected) =>
      Assert.AreEqual (expected, actual);

   /// <summary>Randomly removes elements from front and back of queue.</summary>
   /// <param name="count">No of elements to remove</param>
   public void Remove (int count) {
      for (int i = 0; i < count; i++) {
         int r = mRandom.Next (0, 2);
         switch (r) {
            case 0: mQ.FrontDequeue (); break;
            case 1: mQ.BackDequeue (); break;
         }
      }
   }

   /// <summary>Randomly adds intergers to front and back of queue.</summary>
   /// <param name="count">No. of integers to be added.</param>
   public void AddToQ (int count) {
      for (int i = 0; i < count; i++) {
         int r = mRandom.Next (0, 2);
         switch (r) {
            case 0: mQ.BackEnqueue (i); break;
            case 1: mQ.FrontEnqueue (i); break;
         }
      }
   }

   Random mRandom = new ();
   DoubleQueue<int> mQ = new ();
}