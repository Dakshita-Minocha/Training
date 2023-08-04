int rGuess = new Random ().Next (1, 101), high = 101, low = 1;
int bGuess = high / 2;
Menu ();
void Menu () {
   Console.WriteLine ("Would you like to guess with Binary Method from MSB-LSB(M), Randomly (R), or in Reverse Order from LSB-MSB(L).\nPress (Q) to quit.");
   var key = Console.ReadKey (true).Key; 
   switch (key) {
      case ConsoleKey.M: GuessNumberBinaryMSB_LSB (); break;
      case ConsoleKey.R: GuessNumberRandom (); break;
      case ConsoleKey.L: GuessNumberLSB_MSB (); break;
      case ConsoleKey.Q: Environment.Exit (0); break;
      default:
         Menu (); break;
   }
}
bool Check (string prompt) {
   // Check if the value guessed is correct and exit program if it is.
   if (prompt is "Yes" or "yes") {
      Console.Write ("\nYay! We guessed it!");
      Console.Write ("\nDo you want to exit?(y/n): ");
      if (Console.ReadKey (true).Key == ConsoleKey.Y)
         Environment.Exit (0);
      Menu ();
   }
   return false;
}

void GuessNumberBinaryMSB_LSB () {
   /// Using Binary Search algorithm for guessing number: takes lesser no. of attempts- more efficient
   do {
      Console.WriteLine ($"\nIs {bGuess} higher than/lower than/equal to your number(yes/high/low)? ");
      string prompt = Console.ReadLine (); 
      Check (prompt);
      if (prompt is "high") high = bGuess;
      else low = bGuess;
      bGuess = (low + high) / 2;
      GuessNumberBinaryMSB_LSB ();
   } while (high > low);
}
void GuessNumberRandom () {
   /// To produce random number from within range [low, high) and adjust range depending on user prompt.
   do {
      Console.Write ($"\nIs {rGuess} higher than/lower than/equal to your number(yes/high/low)? ");
      string prompt = Console.ReadLine ();
      Check (prompt);
      if (prompt is "high") high = rGuess;
      else low = rGuess;
      rGuess = new Random ().Next (low, high);
      GuessNumberRandom ();
   } while (high > low);
}
void GuessNumberLSB_MSB () {
   double comparator = 0;
   for (int i = 1; i <= 7; i++) {
      int flag = 0;
      Console.Write ($"\nIs your number % {Math.Pow (2, i)} = {comparator}?(y/n): ");
      switch (Console.ReadKey ().Key) {
         case ConsoleKey.Y: flag = 1; break;
         case ConsoleKey.N: flag = 1; comparator += Math.Pow (2, i-1); break;
         default: Console.Write ("\nEnter yes or no (y/n)"); break;
      }
      if (flag == 0) i -= 1;
   }
   Console.Write($"\nResult: {comparator}");
}





