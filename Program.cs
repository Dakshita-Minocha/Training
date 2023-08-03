using System;
using System.IO;
using System.Linq;
namespace Training {
   internal class Program {
      /// <summary>
      /// Program to read through a file and find the frequency of letters occurring in it and store it in a dictionary. 
      /// </summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         // Reading all words from file:
         string[] words = File.ReadAllLines ("C:\\Users\\dakshitaminocha\\Downloads\\words.txt");
         FrequencyCalculator (words);
      }
      /// <summary>
      /// Calculates the frequency of the letters occurring in the string[] words and displays the 7 most frequently occuring letters.
      /// </summary>
      /// <param name="words">Contains the words from the dictionary file.</param>
      static void FrequencyCalculator (string[] words) {
         string letters = "";
         var letterFrequency = new Dictionary<char, long> ();
         foreach (var word in words) {
            foreach (var letter in word) {
               if (letterFrequency.ContainsKey (letter))
                  letterFrequency[letter] = ++letterFrequency[letter];
               else letterFrequency.Add (letter, 1);
            }
         }
         foreach (KeyValuePair<char, long> a1 in letterFrequency.OrderByDescending (a => a.Value))
            Console.WriteLine ($"{a1.Key},   {a1.Value}");
         Console.WriteLine ("7 most frequently appearing characters: ");
         for (int i = 0; i < 7; i++)
            letters += letterFrequency.OrderByDescending (a => a.Value).ElementAt (i).Key.ToString ();
         Console.WriteLine (letters);
      }

   }

}

