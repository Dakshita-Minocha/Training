// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// TestTraining.cs
// TestProgram for PriorityQueue<T>.
// ------------------------------------------------------------------------------------------------
using Training;
namespace TestTraining;

[TestClass]
public class TestTraining {
   [TestMethod]
   public void TestPriorityQ () {
      PriorityQueue<int> p = new ();
      List<int> q = new ();
      Random r = new (), t = new ();
      for (int i = 0; i < 100; i++) {
         int j = t.Next (1, 101);
         switch (r.Next (0, 2)) {
            case 0: Add (j); break;
            case 1: Remove (); break;
         }
         Console.WriteLine ("   " + p);
      }

      PriorityQueue<int> p1 = new () { 4, 2, 3, 1 }, p2 = new();
      p2.Enqueue (4);
      p2.Enqueue(2);
      p2.Enqueue (3);
      p2.Enqueue (1);
      Assert.IsTrue (p2.SequenceEqual (p1));

      void Add (int x) {
         Console.Write ("adding" + x);
         p.Enqueue (x);
         q.Add (x);
         q.Sort ();
      }

      void Remove () {
         try {
            int x = p.Dequeue ();
            Console.Write ("removing" + x);
            Assert.AreEqual (q[0], x);
            q.RemoveAt (0);
         } catch (Exception e) { Console.WriteLine (e.Message); }
      }
   }
}