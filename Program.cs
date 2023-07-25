using System;

   int n = new Random ().Next (1, 101);
   Console.WriteLine ("Guess the number (from 1-100), you have 8 chances: ");
 
   for (int GuessNum = 1; ; GuessNum++) {
      Console.Write ($"Guess {GuessNum}: ");
      string result = GuessNumber (Console.ReadLine (), n);
   Console.WriteLine (result);
   if (result == "Congratulations! You've guessed it right!") break;
   if (GuessNum > 7) Console.WriteLine ("Too slow! You should've guessed it by now.");      
   }
      string GuessNumber (string Guess, int n) {
         int.TryParse (Guess, out int Cutoff);
         if (n==Cutoff) return "Congratulations! You've guessed it right!";
         else if (n < Cutoff) return "You're too high! Try again";
         else return "You're too low! Try again";
         
      }
   