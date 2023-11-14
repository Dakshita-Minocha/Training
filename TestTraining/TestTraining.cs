// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (kvp) Metamation India.
// ------------------------------------------------------------------
// TestTraining.cs
// Program to test double.TryParse implementation.
// ------------------------------------------------------------------------------------------------
using static Training.DoubleTryParse;
namespace TestTraining;

[TestClass]
public class TestTraining {
   [TestMethod]
   public void TestParse () {
      // Valid cases: 
      Dictionary<string, double> validCases = new () { { "0", 0 }, { "7", 7 }, { "7.1", 7.1 }, { "08.6", 08.6 }, { "7897", 7897 }, { "00990.009", 00990.009 },
         { "0.003", 0.003 }, { "-7.78", -7.78 }, { "-7.78e1", -77.8 }, {"778e0", 778 }, {"-7e2",-700 }, { "8e-3", 0.008 }, {"4e2.3",798.1049259875515 }, {"+4e2.3", 798.1049259875515 } };
      double num;
      foreach (var kvp in validCases) {
         Assert.IsTrue (TryParse (kvp.Key, out num));
         Check (kvp.Value, num);
      }
      // Invalid Cases:
      List<string> invalidCases = new () { "x", "", "8e9.-3", "8-.7e3", "3.4e4-.3", "3.4e4+.3", "-35.-354e1", "e1", "1e", "1jkse", "1++$6e", "8.", "8ee.", "8e3e9.", "3.4e+", "7e.+", "+-34"};
      foreach (var s in invalidCases) {
         Console.WriteLine ($"{s}    {TryParse(s, out num)}");
         Assert.IsFalse (TryParse (s, out num));
         Check (0, num);
      }
      static void Check (double x, double y) => Assert.AreEqual (x, y);

   }
}