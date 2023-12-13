// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to find anagrams of all words in words.txt and store them in file in given format.
// ------------------------------------------------------------------------------------------------
namespace Training;

#region class Program --------------------------------------------------------------------------
internal class Program {
   #region Method ------------------------------------------------
   static void Main (string[] args) => Anagrams ();

   static void Anagrams () {
      string[] words = File.ReadAllLines ("C:/etc/words.txt");
      var anagrams = words.GroupBy (word => string.Join ("", word.OrderBy (c => c)))
                          .Where (group => group.Count () > 1)
                          .Select (group => group.OrderBy (word => word).ToArray ());

      var anaFile = File.Create ("C:/etc/Anagrams.txt");
      using (var newfile = new StreamWriter (anaFile))
         foreach (var list in anagrams.OrderByDescending (list => list.Length))
            newfile.WriteLine ($"{list.Length} {string.Join (" ", list)}");
      anaFile.Close ();
   }
   #endregion
}
#endregion
