/// This program generates a random number from 1-maximum value and asks for user input to guess the number. 
/// It has 3 modes, Easy, Medium, Hard based on which the mx value varies(10,100,1000 respectively)
/// Compares the input to the generated number, and prompts the user accordingly. 
using System;

do {
   Console.WriteLine ("Enter mode: (E)asy, (M)edium, (H)ard");
   int max = GetMax ();
   int random = new Random ().Next (1, max);
   double maxguesses = Math.Round (Math.Log (max, 2));
   Console.WriteLine ($"Guess the number from 1-{max}.");
   Console.WriteLine ($"You should be able to guess it in {maxguesses} tries, but don't worry if you can't! You can take your time.");
   Console.WriteLine ("You can press 'Q' or 'q' to quit anytime.");
   for (int count = 1; ; count++) {
      if (count > maxguesses) Console.WriteLine ("You should've guessed it by now. ");
      Console.Write ($"Guess {count}: ");
      string input = Console.ReadLine ();
      if (input is "q" or "Q") Environment.Exit (0);
      int.TryParse (input, out int guess);
      if (guess < 1 || guess > max) {
         Console.WriteLine ("Enter number from 1-100.");
         count -= 1;
      } else if (random == guess) {
         Console.WriteLine ("Congratulations! You've guessed it right!");
         break;
      } else Console.WriteLine ($"You're too {(random < guess ? "high" : "low")}! Try again");

   }
   Console.WriteLine ("Would you like to play again (y/n)?");
   if (Console.ReadKey ().Key == ConsoleKey.N) Environment.Exit (0);
} while (true);


int GetMax () {
   // Returns max value according to mode entered.
   switch (GetMode ()) {
      case Mode.Easy: return 10;
      case Mode.Medium: return 100;
      default: return 1000;
   }
}
Mode GetMode () {
   // Returns Game Mode as entered by user. 
   var input = Console.ReadKey (true).Key;
   for (; ; ) {
      switch (input) {
         case ConsoleKey.E: return Mode.Easy;
         case ConsoleKey.M: return Mode.Medium;
         case ConsoleKey.H: return Mode.Hard;
         case ConsoleKey.Q: Environment.Exit (0); break;
         default: Console.WriteLine ("Incorrect Value given"); Environment.Exit (0); break;
      }
   }

}
enum Mode { Easy, Medium, Hard };

