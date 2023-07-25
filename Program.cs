int Guess = new Random ().Next (1, 101), high = 101, low = 1;
bool answer;
//Generating random Guess and asking for initial prompt from user. 
Console.Write ($"Is your number {Guess}?(y/n): ");
string prompt = Console.ReadLine ();
answer = Check (prompt);
GuessNumber (prompt);
bool Check (string prompt) {
   //This function checks if the value guessed is correct and exits program if it is.
   if (prompt is "Yes" or "yes") {
      Console.WriteLine ("Yay! We guessed it!");
      Environment.Exit (0);
   }
   return false;
}
void GuessNumber (string prompt) {
   /// This function does not perform Binary search but it cuts the range for producing the random number by replacing
   /// the highest or lowest values by the number just guessed. 
   while (high > low) {
      if (prompt is "too high") high = Guess;
      else if (prompt is "too low") low = Guess;
      Guess = new Random ().Next (low, high);
      Console.Write ($"Is your number {Guess}?(y/n): ");
      prompt = Console.ReadLine ();
      if (Check (prompt) == false) GuessNumber (prompt);

   }
}

