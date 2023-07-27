/// This program generates a random number from 1-100 and asks for user input to guess the number. 
/// It generates prompts to help the user guess the number. 
/// It compares the input to the generated number, and prompts the user accordingly. 
using System;

int random = new Random ().Next (1, 101);
Console.WriteLine ("Guess the number (from 1-100).");
Console.WriteLine ("You should be able to guess it in 7 tries, but don't worry if you can't! You can take your time.");
Console.WriteLine ("You can press 'Q' or 'q' to quit anytime.");
for (int count = 1; ; count++) {
   if (count > 7) Console.WriteLine ("You should've guessed it by now. ");
   Console.Write ($"Guess {count}: ");
   string input= Console.ReadLine();
   if (input is "q" or "Q") Environment.Exit (0);
   int.TryParse (input, out int guess);
   if (guess == 0) {
      Console.WriteLine ("Enter integer from 1-100.");
      count -= 1;
   } else if (random == guess) {
      Console.WriteLine ("Congratulations! You've guessed it right!");
      break;
   } else Console.WriteLine ($"You're too {(random < guess ? "high" : "low")}! Try again");
}