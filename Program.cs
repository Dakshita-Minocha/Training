///This program generates a random number from 1-100 and asks for user input to guess the number. 
///It generates prompts to help the user guess the number. 
///It compares the input to the generated number, and prompts the user accordingly. 
using System;

int n = new Random ().Next (1, 101);
Console.WriteLine ("Guess the number (from 1-100), you have 8 chances: ");
for (int guessnum = 1; ; guessnum++) {
   if (guessnum > 7) Console.WriteLine ("Too slow! You should've guessed it by now.");
   Console.Write ($"Guess {guessnum}: ");
   int.TryParse (Console.ReadLine (), out int cutoff);
   if (n == cutoff) {
      Console.WriteLine ("Congratulations! You've guessed it right!");
      break;
   } 
   else Console.WriteLine($"You're too {(n < cutoff ? "high" : "low")}! Try again");
}