namespace Training {
   internal class Program {
      /// <summary> Program to read through a file and find the frequency of letters occurring in it and store it in a dictionary. </summary>
      static void Main () {
         string[] words = File.ReadAllLines ("C:/etc/words.txt");
         var list = new List<string> ();
         var letterFrequency = new Dictionary<char, int> ();
         foreach (var word in words) {
            foreach (var letter in word.Where (letter => Char.ToUpper (letter) is >= 'A' and <= 'Z')) {
               letterFrequency.TryGetValue (letter, out int freq);
               letterFrequency[letter] = freq + 1;
            }
         }
         var ordered = letterFrequency.OrderByDescending (a => a.Value);
         Console.Write ("Frequency Table:\n\nLetter  Freq\n------  ----\n");
         foreach (var a1 in ordered)
            Console.WriteLine ($"{a1.Key,4} : {a1.Value,5}");
         Console.Write ("7 most frequently appearing characters: ");
         foreach (var kvp in ordered.Take (7))
            Console.Write (kvp.Key + " ");

      }
   }
}



