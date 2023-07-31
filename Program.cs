// Program to generate dictionary words with length>4 with letters from an array.
// Each word must contain the first letter from the array, and only the letters from the array, in any order or number.
// We will readfrom the dictionary file and filter words with length>4
// Convert each word to array and compare. 

using System;
using System.Collections.Immutable;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;

var possiblewords = new List<string> ();
int i = 0, score = 0, totalScore=0;
var scoreCard = new List<(int, string)> ();
var letters = new List<char> { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };

// --- uncomment this section to input letters---
//var letters = new List<char> ();

// Prompt to ask for the day's puzzle letters.
/*Console.WriteLine ("Enter 7 letters:");
for (i = 0; i < 7; i++) {
   char.TryParse (Console.ReadLine().ToUpper(), out char letter);
   letters.Add (letter);
}*/

// Traversing through array to read characters.
Console.WriteLine ("Your letters:");
for (i = 0; i < letters.Count; i++) Console.Write ($"{letters[i]} ");
Console.WriteLine ();

// Finding all possible combinations of letters from dictionary:
string[] words = File.ReadAllLines ("C:\\Users\\dakshitaminocha\\Downloads\\words.txt");

// Choose method:
Console.WriteLine ("Display using Function1 [1] (uses existing methods) or Function2 [2]");
var key = Console.ReadKey (true).Key;
Console.WriteLine ();
switch (key) {
   case ConsoleKey.D1: scoreCard = DisplayScore (); break;
   case ConsoleKey.D2: scoreCard = DisplayScoreManually (); break;
   default: Console.WriteLine ("Enter [1] or [2]"); break;
}
var ordered = scoreCard.OrderByDescending (a => a.Item1).ThenBy (a => a.Item2);
foreach (var (j, val) in ordered){
   Console.WriteLine ($"{j,2}. {val,-2}");
   totalScore += j;
}   
Console.WriteLine ("----");
Console.WriteLine (totalScore);


// Filters through possible combinations with redefined functions like .Contain()
// Adds possible words to a list of tuples in (score, word) format. 
// Uses the ScoreCalculator() function to calculate score based on given rules.
List<(int, string)> DisplayScore () {
   foreach (var word in words) {
      if (word.Length >= 4) {
         if (word.All (letters.Contains)) {
            if (word.Contains (letters[0].ToString ()) == true) {
               possiblewords.Add (string.Join ("", word));
               scoreCard.Add ((ScoreCalculator (word), word));
            }
         }
      }
   }
   return scoreCard;
}

// Calls defined local functions like CheckFirstChar() to filter through dictionary words.
// Adds possible words to a list of tuples in (score, word) format. 
// Uses the ScoreCalculator() function to calculate score based on given rules.
List<(int, string)> DisplayScoreManually () {
   foreach (var word in words) {
      if (word.Length > 3) {
         if (CheckCharacters (word) != 0) {
            if (CheckFirstChar (letters[0], word) == 1) {
               possiblewords.Add (string.Join ("", word));
               scoreCard.Add ((ScoreCalculator (word), word));
            }
         }
      }
   }
   return scoreCard;
}

// Calculates score based on given rules.
int ScoreCalculator (string word) {
   score = (word.Length == 4) ? 1 : word.Length;
   if (CheckPangram (word) == true) score += 7;
   return score;
}

// Checks if the given word is a Pangram, i.e., uses all 7 letters.
bool CheckPangram (string word) {
   int count = 0;
   foreach (var letter in letters) {
      foreach (var ch in word) {
         if (letter == ch) {
            count++;
            break;
         }
      }
   }
   if (count == 7) return true;
   return false;
}

// Checks if the word contains the first (mandatory) character from the array.
int CheckFirstChar (char letter, string word) {
   foreach (var ch in word) if (ch == letter) return 1;
   return 0;
}

// Checks if all letters in the word are from the givenn array.
int CheckCharacters (string word) {
   int count = 0;
   foreach (var ch in word) {
      foreach (var letter in letters) {
         if (letter == ch) {
            count = 1;
            break;
         } else count = 0;
      }
      if (count == 0) return count;
   }
   return count;
}


