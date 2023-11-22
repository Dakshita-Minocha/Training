// ------------------------------------------------------------------------------------------------
// Training ~ DriveA training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// TestTraining.cs
// TestProgram for FileParse using state machines.
// ------------------------------------------------------------------------------------------------
using static Training.Path;
namespace TestTraining;

[TestClass]
public class TestTraining {
   [TestMethod]
   public void TestParsePath () {
      Dictionary<string, (string, string, string, string, string)> validPaths = new () {
         { "C:\\WorkGIT\\Dakshita\\Training.sln", ("c", "workgit", "workgit/dakshita", "training.sln", ".sln")},
         { "C:/words/words.txt", ("c", "words", "words/", "words.txt", ".txt")}
      };
      string[] invalidPaths = { "suppppp", "Ca:/workgit/hjh.txt", "c:\\Dakshita123.md", "C:\\workgit\\dakshita", "c:/dakshita.txt" };
      foreach (var kvp in validPaths)
         Validate (kvp.Key, kvp.Value);
      foreach (string path in invalidPaths)
         Validate (path, ("", "", "", "", ""));

      static void Validate (string path, (string, string, string, string, string) expOutput) {
         PathParse (path, out (string, string, string, string, string) ActOutput);
         Assert.AreEqual (expOutput, ActOutput);
      }
   }

   [TestMethod]
   public void TestLazyEval () {
      Training.Path path = new ("C:\\WorkGIT\\Dakshita\\Training.sln");
      Assert.AreEqual (0, path.nComputations);
      Assert.IsTrue (path.IsValid);
      Assert.AreEqual (1, path.nComputations);
      Assert.AreEqual (("c", "workgit", "workgit/dakshita", "training.sln", ".sln"), path.FilePath);
      Assert.AreEqual (1, path.nComputations);
      Assert.AreEqual ("FileName: training.sln\nDrive: c\nDirectory: workgit\nFile Path: workgit/dakshita\n", path.ToString ());
      Assert.AreEqual (1, path.nComputations);
      Training.Path path1 = new ("C:/words/words.txt");
      Assert.AreEqual (0, path1.nComputations);
      Assert.AreEqual (("c", "words", "words/", "words.txt", ".txt"), path1.FilePath);
      Assert.AreEqual (1, path1.nComputations);

   }
}