// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to find the number thought of by the user with two methods: MSB-LSB or LSB-MSB
// ---------------------------------------------------------------------------------------

using static System.Console;

namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static int high = 101, low = 1, bGuess = high / 2;
      static void Main (string[] args) => Menu ();

      static void Menu () {
         WriteLine ("Would you like to guess with Binary Method from MSB-LSB(M) or in Reverse Order from LSB-MSB(L)?\nPress (Q) to quit.");
         var key = ReadKey (true).Key;
         switch (key) {
            case ConsoleKey.M: GuessNumberBinaryMSB_LSB (); break;
            case ConsoleKey.L: GuessNumberLSB_MSB (); break;
            case ConsoleKey.Q: Environment.Exit (0); break;
            default:
               Menu (); break;
         }
      }

      /// <summary> Exit program if value guessed is correct. </summary>
      /// <param name="prompt"> User Input </param>
      static void IsCorrect (string prompt) {
         if (prompt.ToLower () == "yes") {
            Write ("\nYay! We guessed it!\nDo you want to exit(y/n)? \n");
            if (ReadKey (true).Key == ConsoleKey.Y)
               Environment.Exit (0);
            Menu ();
         }
      }

      ///<summary> Using Binary Search algorithm for guessing number. </summary>
      static void GuessNumberBinaryMSB_LSB () {
         do {
            Write ($"\nIs {bGuess} higher than/lower than/equal to your number (yes/high/low)? ");
            string prompt = ReadLine ();
            IsCorrect (prompt);
            if (prompt is "high") high = bGuess;
            else low = bGuess;
            bGuess = (low + high) / 2;
         } while (high > low);
      }

      /// <summary> Using Reverse Binary search algorithm to guess number. </summary>
      static void GuessNumberLSB_MSB () {
         double sum = 0;
         for (int i = 1; i <= 7; i++) {
            Write ($"\nIs your number % {Math.Pow (2, i)} < {Math.Pow (2, i - 1)} (y/n)? ");
            if (ReadKey ().Key == ConsoleKey.N) sum += Math.Pow (2, i - 1);
         }
         Write ($"\nYour number is {sum}");
         IsCorrect ("yes");
      }
      #endregion
   }
   #endregion
}