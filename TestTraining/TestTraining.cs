// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// TestTraining.cs
// TestProgram on main branch.
// ------------------------------------------------------------------------------------------------
using Training;
using static System.Console;
namespace TestTraining;

[TestClass]
public class TestTraining {
   [TestMethod]
   public void DoubleQueue () {
      DoubleQueue<int> q = new ();

      Random random = new ();
      for (int i = 0; i < 50; i++) {
         int r = random.Next (0, 4);
         try {
            switch (r) {
               case 0: WriteLine ($"Back EnQ: {i}"); q.BackEnqueue (i); break;
               case 1: WriteLine ($"Fron EnQ: {i}"); q.FrontEnqueue (i); break;
               case 2: WriteLine ($"Fron DeQ: {q.FrontDequeue ()}"); break;
               case 3: WriteLine ($"Back DeQ: {q.BackDequeue ()}"); break;
            }
         } catch (Exception e) { WriteLine (e.Message); }
         WriteLine (q);
      }
   }
}