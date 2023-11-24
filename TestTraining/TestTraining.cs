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
      Assert.IsTrue (q.IsEmpty);
      AddtoQ (1);
      Assert.IsFalse (q.IsEmpty);
      Equals (q.Count, 1);
      Equals (q.Capacity, 4);
      AddtoQ (4);
      Equals (q.Count, 5);
      Equals (q.Capacity, 8);
   }

   [TestMethod]
   public void TestEnqueue () {
      q.BackEnqueue (1);
      q.BackEnqueue (2);
      q.BackEnqueue (3);
      q.BackEnqueue (4);
      Equals (q.ToString (), "1 2 3 4 ");
      q.FrontDequeue ();
      q.BackEnqueue (5);
      q.BackEnqueue (5);
      Equals (q.ToString (), "2 3 4 5 5 ");
      q.FrontDequeue ();
      q.FrontEnqueue (-1);
      Equals (q, "-1 3 4 5 5 ");
      q.FrontEnqueue (-2);
      Equals (q.Count, 5);
      Equals (q.Capacity, 8);
      q.FrontEnqueue (-3);
      Equals (q, "-3 -2 -1 3 4 5 5 ");
      q.BackEnqueue (1);
      q.BackEnqueue (2);
      q.BackEnqueue (4);
      Equals (q, "-3 -2 -1 3 4 5 1 2 4 5 ");
   }

   [TestMethod]
   public void TestDequeue () {
      Assert.ThrowsException<InvalidOperationException> (() => q.BackDequeue ());
      Assert.ThrowsException<InvalidOperationException> (() => q.FrontDequeue ());
      q.BackEnqueue (1);
      q.BackEnqueue (2);
      q.BackEnqueue (3);
      q.BackEnqueue (4);
      Equals (q.FrontDequeue (), 1);
      Equals (q.Count, 3);
      q.BackEnqueue (5);
      Equals (q.BackDequeue (), 5);
      Equals (q.FrontDequeue (), 2);
      Equals (q.Count, 2);
      q.FrontEnqueue (-1);
      q.FrontEnqueue (-2);
      q.FrontEnqueue (-3);
      Equals (q.Count, 5);
      Equals (q.FrontDequeue (), -3);
      Equals (q.Capacity, 8);
      Equals (q.Count, 4);
      q.BackEnqueue (1);
      q.BackEnqueue (2);
      q.BackEnqueue (4);
      Equals (q.Count, 5);
      Equals (q.BackDequeue (), 4);
      Equals (q.Capacity, 8);
      Equals (q.Count, 4);
      Assert.ThrowsException<InvalidOperationException> (() => Remove (q.Count + 1));
   }

   /// <summary>Checks if two elements are equal.</summary>
   public void Equals (string actual, string expected) =>
      Assert.AreEqual (expected, actual);

   /// <summary>Randomly removes elements from front and back of queue.</summary>
   /// <param name="count">No of elements to remove</param>
   public void Remove (int count) {
      for (int i = 0; i < count; i++) {
         int r = random.Next (0, 2);
         switch (r) {
            case 0: q.FrontDequeue (); break;
            case 1: q.BackDequeue (); break;
         }
      }
   }

   /// <summary>Randomly adds intergers to front and back of queue.</summary>
   /// <param name="count">No. of integers to be added.</param>
   public void AddtoQ (int count) {
      for (int i = 0; i < count; i++) {
         int r = random.Next (0, 2);
         switch (r) {
            case 0: q.BackEnqueue (i); break;
            case 1: q.FrontEnqueue (i); break;
         }
      }
   }

   Random random = new ();
   DoubleQueue<int> q = new ();
}