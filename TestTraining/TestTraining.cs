// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// TestTraining.cs
// Test program to test Expression Evaluator.
// ------------------------------------------------------------------------------------------------
using Training;
namespace TestTraining;

[TestClass]
public class TestTraining {
   [TestMethod]
   public void TestParse () {
      Dictionary<string, double> EvalInput = new () { { "-10 ^ 2", 100 }, { "a = 4", 4 }, { "b = 3.5", 3.5 }, { "a + b", 7.5 }, { "asin sin 45", 45 }, { "atan tan 45", 45 }, { "sqrt 25", 5 },
            { "log 1", 0 }, { "-2 -2", -4 }, {"10/2 + 3", 8}, {"(+10 + 3 ) * 2", 26}, {"(a + 2) * a", 24 }, { "3%2", 1}, {"cos 0", 1 }, {"exp 2", 7.3890560989 }, {"cos acos 0", 0} , { "10 -2 -2", 6 } };
      string[] invalidInput = { "10 + 2+", "10 2 -", " 3#4", "a + c", "10 + * 3", "10 3 * 4", "sin", "10 + +" };
      Evaluator eval = new ();
      foreach (var input in EvalInput)
         Assert.AreEqual (input.Value, eval.Evaluate (input.Key));
      foreach (var item in invalidInput)
         Assert.ThrowsException<EvalException> (() => eval.Evaluate (item));
   }
}