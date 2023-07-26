int rGuess = new Random ().Next (1, 101), high = 101, low = 1;
int bGuess = high / 2;
Menu ();
void Menu () {
   Console.Write ("Would you like to guess with Binary Method(b), Randomly (r),or in Reverse Order(o): ");
   var key = Console.ReadKey (true).Key; Console.WriteLine ();
   switch (key) {
      case ConsoleKey.B: GuessNumberBinary (); break;
      case ConsoleKey.R: GuessNumberRandom ();break;
      case ConsoleKey.O: GuessNumberReverse (); break;
      default: Menu (); break;
   }
}

bool Check (string prompt) {
   //Check if the value guessed is correct and exit program if it is.
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

void GuessNumberReverse() {
   int  bit = 1, bit_=0 ;
   double result = 0, comparator = 0;
   Console.Write ($"Is your number%{Math.Pow (2, bit)} = {comparator}?(y/n): ");
   Console.WriteLine ();
   //y corresponds to 1, n corresponds to 0. 
   if (Console.ReadKey ().Key == ConsoleKey.N){
      //Number is Odd. 
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
      //Console.WriteLine ();
   } while (bit <= 7);
   Console.WriteLine ($"Your number is: {result.ToString ()}");
}
void GuessNumberBinary () {
///Using Binary Search algorithm for guessing number: takes lesser no. of attempts- more efficient
   do {
      Console.WriteLine ($"Is your number {bGuess}?(yes/too high/too low): ");
      string prompt = Console.ReadLine (); Console.WriteLine ();
      Check (prompt);
      if (prompt is "too high") high = bGuess;
      else low = bGuess;
      bGuess = (low + high) / 2;
      GuessNumberBinary ();
   } while (high > low);
}
void GuessNumberRandom () {
   /// Produce random number from within range [low, high) and adjust range depending on user prompt.
   do {
      Console.Write ($"Is your number {rGuess}?(yes/too high/too low): ");
      string prompt = Console.ReadLine (); Console.WriteLine ();
      Check (prompt);
      if (prompt is "too high") high = rGuess;
      else low = rGuess;
      rGuess = new Random ().Next (low, high);
      GuessNumberRandom ();

   } while (high > low);
}

