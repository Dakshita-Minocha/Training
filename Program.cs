namespace Training {
   internal class Program {
      /// <summary> Longest abecedarian word in an array </summary>
      static void Main () {
         string[] words = new[] { "Abstemious", "sup", "Bijoux", "never", "Arsenic", "Chintz", "Facetious", "Aegilops" };
         Dictionary<string, int> isograms = new ();
         foreach (var word in words) {
            bool flag = true;
            for (int i = 0; i < word.Length - 1; i++)
               if (word[i] > word[i + 1]) {
                  flag = false; break;
               }
            if (flag) isograms.Add (new string (word), word.Length);
         }
         var kvp = isograms.OrderByDescending (a => a.Value).FirstOrDefault ();
         Console.WriteLine ($"Largest abecedarian word is {kvp.Key}");
      }
   }
}