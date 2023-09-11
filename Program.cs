namespace Training {
   internal class Program {
      /// <summary> Longest abecedarian word in an array </summary>
      static void Main () {
         string[] words = new[] { "Abstemious", "sup", "Bijoux", "never", "ArsENnic", "Chintz", "Facetious", "AeGIlops" };
         Dictionary<string, int> isograms = new ();
         for (int w = 0; w < words.Length; w++) {
            string word = words[w].ToLower ();
            bool flag = true;
            for (int i = 0; i < word.Length - 1; i++)
               if (word[i] > word[i + 1]) {
                  flag = false; break;
               }
            if (flag) {
               word = words[w];
               isograms.TryGetValue (word, out _);
               isograms[word] = word.Length;
            }
         }
         var kvp = isograms.OrderByDescending (a => a.Value).FirstOrDefault ();
         Console.WriteLine ($"Largest abecedarian word is {kvp.Key}");
         isograms.Clear ();
      }
   }
}