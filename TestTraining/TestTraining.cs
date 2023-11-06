// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// TestTraining.cs
// Program to test double.Parse implementation.
// ------------------------------------------------------------------------------------------------
using static Training.DoubleParse;
namespace TestTraining;

[TestClass]
public class TestTraining {
   [TestMethod]
   public void TestParse () {
      // Valid cases: 
      Assert.IsTrue (Parse ("0", out double num));
      Assert.AreEqual (0, num);
      Assert.IsTrue (Parse ("7", out num));
      Assert.AreEqual (7, num);
      Assert.IsTrue (Parse ("7.1", out num));
      Assert.AreEqual (7.1, num);
      Assert.IsTrue (Parse ("08.6", out num));
      Assert.AreEqual (08.6, num);
      Assert.IsTrue (Parse ("7897", out num));
      Assert.AreEqual (7897, num);
      Assert.IsTrue (Parse ("00990.009", out num));
      Assert.AreEqual (00990.009, num);
      Assert.IsTrue (Parse ("0.003", out num));
      Assert.AreEqual (0.003, num);
      Assert.IsTrue (Parse ("-7.78", out num));
      Assert.AreEqual (-7.78, num);
      Assert.IsTrue (Parse ("-7.78e1", out num));
      Assert.AreEqual (-77.8, num);
      Assert.IsTrue (Parse ("-7e2", out num));
      Assert.AreEqual (-700, num);
      Assert.IsTrue (Parse ("778e0", out num));
      Assert.AreEqual (778, num);
      Assert.IsTrue (Parse ("8e-3", out num));
      Assert.AreEqual (0.008, num);
      Assert.IsTrue (Parse ("4e2.3", out num));
      Assert.AreEqual (798.1049259875515, num);
      Assert.IsTrue (Parse ("+4e2.3", out num));
      Assert.AreEqual (798.1049259875515, num);
      // Invalid Cases:
      Assert.IsFalse (Parse ("x", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("8e9.-3", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("8-.7e3", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("3.4e4-.3", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("3.4e4+.3", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("-35.-354e1", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("e1", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("1e", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("1jkse", out num));
      Assert.AreEqual (0, num);
      Assert.IsFalse (Parse ("1++$6e", out num));
      Assert.AreEqual (0, num);
   }
}