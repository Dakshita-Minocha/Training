// Program to generate dictionary words with length>4 with letters from an array.
// Each word must contain the first letter from the array, and only the letters from the array, in any order or number.
// We will readfrom the dictionary file and filter words with length>4
// Convert each word to array and compare. 

using System;

int i = 0;
var scoreCard = new List<(int, string)> ();
string letters;
// Finding all possible combinations of letters from dictionary:
string[] words = File.ReadAllLines ("C:/etc/words.txt");

// Prompt to ask for the day's puzzle letters.
for(; ;) {
   Console.WriteLine ("\nEnter 7 letters:");
   letters = Console.ReadLine ().ToUpper ();
   if (letters.Count () == 7) break;
}

// Traversing through string to read characters.
Console.WriteLine ("Your letters:");
for (i = 0; i < letters.Length; i++) Console.Write ($" {letters[i]} ");
Console.WriteLine ();

// Choose method:
for (; ; ) {
   Console.WriteLine ("Display words with score[1]. Press [Q] to exit.");
   var key = Console.ReadKey (true).Key;
   switch (key) {
      case ConsoleKey.D1: FilterWords (); break;
      case ConsoleKey.Q: Environment.Exit (0); break;
      default: Console.WriteLine ("\nEnter [1] or [2]"); break;
   }
}

void Display (List<(int, string)> scoreCard) {
   var ordered = scoreCard.OrderByDescending (a => a.Item1).ThenBy (a => a.Item2);
   foreach (var (j, val) in ordered) 
      Console.Write ($"\n{j,2}. {val,-2}");
   int totalScore = scoreCard.Sum (a => a.Item1);
   Console.WriteLine ("\n----\n" + totalScore + "  total");
}

// Filters through possible combinations with redefined functions like .Contain()
// Adds possible words to a list of tuples in (score, word) format. 
// Uses the ScoreCalculator() function to calculate score based on given rules.
void FilterWords () {
   foreach (var word in words) 
      if (word.Length >= 4
      && word.Contains (letters[0].ToString ())
      && word.All (letters.Contains))
         scoreCard.Add ((ScoreCalculator (word), word));
   Display (scoreCard);
}
// Calculates score based on given rules.
int ScoreCalculator (string word) => (word.Length == 4 ? 1 : word.Length) + (letters.All(word.Contains) ? 7 : 0);


/*  
// Calls defined local functions like CheckFirstChar() to filter through dictionary words.
// Adds possible words to a list of tuples in (score, word) format. 
// Uses the ScoreCalculator() function to calculate score based on given rules.
void FilterWordsManually () {
   foreach (var word in words) {
      if (word.Length > 3
      && CheckFirstChar (letters[0], word) == 1
      && CheckCharacters (word) != 0)
         scoreCard.Add ((ScoreCalculator (word), word));
   }
   Display (scoreCard);
}

// Checks if the given word is a Pangram, i.e., uses all 7 letters.
bool CheckPangram (string word) {
   int count = 0;
   foreach (var letter in letters) 
      foreach (var ch in word) 
         if (letter == ch) {
            count++; break;
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
            count = 1; break;
         } else count = 0;
      }
      if (count == 0) return count;
   }
   return count;
} */


