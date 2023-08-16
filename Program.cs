// Program to generate dictionary words with length>4 with letters from an array.
// Each word must contain the first letter from the array, and only the letters from the array, in any order or number.
// We will read from the dictionary file and filter words with length>4
// Convert each word to array and compare. 

using System;

int i = 0;
var scoreCard = new List<(int, string)> ();
string letters;
// Finding all possible combinations of letters from dictionary:
string[] words = File.ReadAllLines ("C:/etc/words.txt");

// Prompt to ask for the day's puzzle letters, checking if first 7 letters are all alphabets and displaying them, then calling function FilterWords();
for (; ; ) {
   for (; ; ) {
      bool flag = true;
      Console.WriteLine ("Enter letters:");
      letters = Console.ReadLine ().ToUpper ();
      letters = letters[0..7];
      foreach (var ch in letters) if (!char.IsLetter (ch)) flag = false;
      if (flag) break;
   }
   Console.WriteLine ("Your letters:");
   for (i = 0; i < letters.Length; i++) Console.Write ($" {letters[i]} ");
   Console.WriteLine ();
   FilterWords ();
   Console.Write ("Do you want to continue(y/n)?\n");
   if (Console.ReadKey (true).Key == ConsoleKey.N) Environment.Exit (0);
}

// Output Display: 
void Display (List<(int score, string word)> scoreCard) {
   var ordered = scoreCard.OrderByDescending (a => a.score).ThenBy (a => a.word);
   foreach (var (j, val) in ordered)
      Console.Write ($"\n{j,2}. {val,-2}");
   int totalScore = scoreCard.Sum (a => a.score);
   Console.WriteLine ("\n----\n" + totalScore + "  total");
   scoreCard.Clear ();
}

// Filters through possible combinations with redefined functions like .Contain()
// Adds possible words to a list of tuples in (score, word) format. 
// Uses the ScoreCalculator() function to calculate score based on given rules.
void FilterWords () {
   foreach (var word in words)
      if (word.Length >= 4
      && word.Contains (letters[0])
      && word.All (letters.Contains))
         scoreCard.Add ((ScoreCalculator (word), word));
   Display (scoreCard);
}

// Calculates score based on given rules.
int ScoreCalculator (string word) => (word.Length == 4 ? 1 : word.Length) + (letters.All (word.Contains) ? 7 : 0);