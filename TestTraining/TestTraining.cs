using static Training.Path;
namespace TestTraining;

[TestClass]
public class TestTraining {
   [TestMethod]
   public void TestParsePath () {
      Dictionary<string, (string, string, string, string, string)> validPaths = new () {
         { "C:\\WorkGIT\\Dakshita\\Training.sln", ("c", "workgit", "dakshita", "training.sln", ".sln")},
         { "C:/words/words.txt", ("c", "words", "", "words.txt", ".txt")}
      };
      string[] invalidPaths = { "suppppp", "Ca:/workgit/hjh.txt", "c:\\Dakshita123.md", "C:\\workgit\\dakshita", "c:/dakshita.txt" };
      foreach (var kvp in validPaths)
         Validate (kvp.Key, kvp.Value);
      foreach (string path in invalidPaths)
         Validate (path, ("", "", "", "", ""));
   }
   void Validate (string path, (string, string, string, string, string) expOutput) {
      PathParse (path, out (string, string, string, string, string) ActOutput);
      Assert.AreEqual (expOutput, ActOutput);
   }
}