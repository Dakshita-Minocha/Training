namespace Training {
   internal class Program {
      /// <summary> Longest abecedarian word in an array </summary>
      static void Main () {
         string[] words = new[] { "Abstemious", "sup", "Bijoux", "never", "ArENnic", "Chintz", "Facetious", "AeGIlops" };
         var wcopy = words.ToArray ();
         int i;
         Dictionary<string, int> isograms = new ();
         foreach (var word in wcopy.Select (w => w.ToLower ())) {
            bool flag = true;
            for (i = 0; i < word.Length - 1; i++)
               if (word[i] > word[i + 1]) {
                  flag = false; break;
               }
            if (flag) {
               isograms.TryGetValue (new string (words[i]), out int len);
               isograms[words[i]] = words[i].Length;
            }
         }
         var kvp = isograms.OrderByDescending (a => a.Value).FirstOrDefault ();
         Console.WriteLine ($"Largest abecedarian word is {kvp.Key}");
         isograms.Clear ();
      }
   }
}