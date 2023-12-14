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
      var anagrams = words.GroupBy (word => string.Join ("", word.Order ()))
                          .Where (group => group.Count () > 1)
                          .Select (group => group.Order ().ToArray ()).OrderByDescending (group => group.Length);

      using (var newfile = new StreamWriter ("C:/etc/Anagrams.txt"))
         foreach (var list in anagrams)
            newfile.WriteLine ($"{list.Length} {string.Join (" ", list)}");
   }
   #endregion
}
#endregion
