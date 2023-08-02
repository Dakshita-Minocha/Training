int rGuess = new Random ().Next (1, 101), high = 101, low = 1;
int bGuess = high / 2;
Menu ();
void Menu () {
   Console.WriteLine ("Would you like to guess with Binary Method from MSB-LSB(M), Randomly (R), or in Reverse Order from LSB-MSB(L)");
   Console.WriteLine ("Press (Q) to quit.");
   var key = Console.ReadKey (true).Key; Console.WriteLine ();
   switch (key) {
      case ConsoleKey.M: GuessNumberBinaryMSB_LSB (); break;
      case ConsoleKey.R: GuessNumberRandom ();break;
      case ConsoleKey.L: GuessNumberLSB_MSB (); break;
      case ConsoleKey.Q: Environment.Exit (0); break;
      default: Menu (); break;
   }
}

bool Check (string prompt) {
   // Check if the value guessed is correct and exit program if it is.
   if (prompt is "Yes" or "yes") {
      Console.WriteLine ("Yay! We guessed it!");
      Console.WriteLine ();
      Console.Write ("Do you want to exit?(y/n): ");
      if (Console.ReadKey (true).Key == ConsoleKey.Y)
         Environment.Exit (0);
      Console.WriteLine ();
      Menu ();
   }
   return false;
}

void GuessNumberBinaryMSB_LSB () {
   /// Using Binary Search algorithm for guessing number: takes lesser no. of attempts- more efficient
   do {
      Console.WriteLine ($"Is {bGuess} higher than/lower than/equal to your number(yes/high/low)? ");
      string prompt = Console.ReadLine (); Console.WriteLine ();
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
      Console.Write ($"Is {rGuess} higher than/lower than/equal to your number(yes/high/low)? ");
      string prompt = Console.ReadLine (); Console.WriteLine ();
      Check (prompt);
      if (prompt is "high") high = rGuess;
      else low = rGuess;
      rGuess = new Random ().Next (low, high);
      GuessNumberRandom ();

   } while (high > low);
}
void GuessNumberLSB_MSB () {
   int  bit = 1, bit_=0 ;
   double result = 0, comparator = 0;
   Console.Write ($"Is your number%{Math.Pow (2, bit)} = {comparator}?(y/n): ");
   Console.WriteLine ();
   // y corresponds to 1, n corresponds to 0. 
   if (Console.ReadKey ().Key == ConsoleKey.N){
      // Number is Odd. 
      result = 1;
      comparator = 1;
   }
   bit++;
   bit_++;
   result += Math.Pow (2, bit_);
   do {
      Console.WriteLine ();
      Console.Write ($"Is your number % {Math.Pow (2, bit)} = {comparator} or number % {Math.Pow (2, bit)} = {comparator + Math.Pow (2, bit_)}?(y/n): ");
      comparator += Math.Pow (2, bit_);
      if (Console.ReadKey ().Key == ConsoleKey.Y) {
         bit++;
         bit_++;
         result += Math.Pow (2, bit_);
         
      } else {
         bit++;
         bit_++;
         result += 0;
         
      }
   } while (bit <= 7);
   Console.WriteLine ($"Your number is: {result}");
}


