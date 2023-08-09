using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
namespace Training {
   internal class Program {
      /// <summary> Program to read through a file and find the frequency of letters occurring in it and store it in a dictionary. </summary>
      static void Main (string[] args) {
         string letters = "";
         string[] words = File.ReadAllLines ("C:/etc/words.txt");
         var letterFrequency = new Dictionary<char, int> ();
         letterFrequency = FrequencyCalculator (words);
         Console.Write ("Frequency Table:\n" + "Keys  Values\n");
         foreach (var a1 in letterFrequency.OrderByDescending (a => a.Value))
            Console.WriteLine ($"{a1.Key,4} : {a1.Value,5}");
         Console.Write ("7 most frequently appearing characters: ");
         foreach (var key in letterFrequency.OrderByDescending (a => a.Value).Take (7))
            Console.Write (key.Key + " ");

         //for (int i = 0; i < 7; i++)
         //   letters += letterFrequency.OrderByDescending (a => a.Value).ElementAt (i).Key.ToString () + " ";
         //Console.Write (letters);
      }
      /// <summary>Calculates the frequency of the letters occurring in the string[] words and displays the 7 most frequently occuring letters.</summary>
      /// <param name="words">Contains the words from the dictionary file.</param>
      static Dictionary<char, int> FrequencyCalculator (string[] words) {
         var letterFrequency = new Dictionary<char, int> ();
         foreach (var word in words)
            foreach (var letter in word
                                  .Where (letter => Char.ToUpper (letter) is >= 'A' and <= 'Z')) {
               if (letterFrequency.ContainsKey (letter))
                  letterFrequency[letter] = ++letterFrequency[letter];
               else letterFrequency.Add (letter, 1);
            }
         return letterFrequency;
            
      }
   }
}



