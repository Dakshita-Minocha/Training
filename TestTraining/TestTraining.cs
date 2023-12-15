// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// TestTraining.cs
// TestProgram on main branch.
// ------------------------------------------------------------------------------------------------
using Training;
namespace TestTraining;

[TestClass]
public class TestTraining {
   [TestMethod]
   public void TestWordleInput () {
      int FilePtr = 0;
      string[] input = { "../TestData/wREFRight.txt", "../TestData/wREFWrong.txt" }, saveToFile = { "../TestData/wTestRight.txt", "../TestData/wTestWrong.txt" };
      foreach (var file in input) {
         int count = 0;
         string[] refLines = File.ReadAllLines (file);
         Wordle w = new () {
            mFileName = saveToFile[FilePtr],
            SecretWord = refLines[count++]
         };
         string win = refLines[count++];
         int tries = int.Parse (refLines[count++]);
         for (char i = 'A'; i <= 'Z'; i++)
            w.mState[i] = ConsoleColor.White;
         for (int j = 0; j < tries; j++) {
            string word = refLines[count++];
            foreach (var c in word)
               w.UpdateState ((ConsoleKey)c);
            w.UpdateState (ConsoleKey.Enter);
            w.Save ();
            w.mCursor = 0;
            count += 26;
         }
         w.Save (-1);

         string[] testLines = File.ReadAllLines (saveToFile[FilePtr++]);
         Assert.IsTrue (testLines.SequenceEqual (refLines));
         Assert.AreEqual (win, testLines[1]);
      }
   }
}