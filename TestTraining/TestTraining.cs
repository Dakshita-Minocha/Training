// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// TestTraining.cs
// TestProgram for FileParse using state machines.
// ------------------------------------------------------------------------------------------------
using static Training.PathParser;
namespace TestTraining;

[TestClass]
public class TestTraining {
   [TestMethod]
   public void TestParsePath () {
      Dictionary<string, Path> validPaths = new () {
         { "C:\\WorkGIT\\Dakshita\\Training.sln", new Path (("c", "workgit", "workgit/dakshita", "training.sln", ".sln"))},
         { "C:/words/words.txt",  new Path (("c", "words", "words/", "words.txt", ".txt"))}
      };
      string[] invalidPaths = { "suppppp", "Ca:/workgit/hjh.txt", "c:\\Dakshita123.md", "C:\\workgit\\dakshita", "c:/dakshita.txt" };
      foreach (var kvp in validPaths)
         Validate (kvp.Key, kvp.Value);
      var blank = new Path (("", "", "", "", ""));
      foreach (string path in invalidPaths)
         Validate (path, blank);

      static void Validate (string path, Path expOutput) {
         PathParse (path, out (string, string, string, string, string) ActOutput);
         Assert.AreEqual (expOutput, new Path (ActOutput));
      }
   }

   [TestMethod]
   public void TestLazyEval () {
      Training.PathParser path = new ("C:\\WorkGIT\\Dakshita\\Training.sln");
      Assert.AreEqual (0, path.Computations);
      Assert.IsTrue (path.IsValid);
      Assert.AreEqual (1, path.Computations);
      Assert.AreEqual (("c", "workgit", "workgit/dakshita", "training.sln", ".sln"), path.FilePath);
      Assert.AreEqual (1, path.Computations);
      Assert.AreEqual ($"FileName: training.sln{NL}Drive: c{NL}Directory: workgit{NL}File Path: workgit/dakshita{NL}", path.ToString ());
      Assert.AreEqual (1, path.Computations);
      Training.PathParser path1 = new ("C:/words/words.txt");
      Assert.AreEqual (0, path1.Computations);
      Assert.AreEqual (("c", "words", "words/", "words.txt", ".txt"), path1.FilePath);
      Assert.AreEqual (1, path1.Computations);
   }

   #region Private Data ---------------------------------------------
   static readonly string NL = Environment.NewLine;
   struct Path {
      (string, string, string, string, string) filePath;
      public Path ((string drive, string dir, string path, string filename, string ext) fp) =>
         filePath = (fp.drive, fp.dir, fp.path, fp.filename, fp.ext);
   }
   #endregion
}