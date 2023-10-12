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
      static void IsCorrect (char prompt) {
         if (prompt == 'y') {
            Write ("\nYay! We guessed it!\nDo you want to exit(y/n)? \n");
            if (ReadKey (true).Key == ConsoleKey.Y)
               Environment.Exit (0);
            Menu ();
         }
      }

      /// <summary> Using Binary Search algorithm for guessing number. </summary>
      static void GuessNumberBinaryMSB_LSB () {
         int high = 101, low = 1, guess = high / 2;
         do {
            Write ($"\nIs {guess} higher than/lower than/equal to your number (high [H] / low [L] / yes [Y])? ");
            char prompt = char.ToLower (ReadKey (true).KeyChar);
            IsCorrect (prompt);
            if (prompt is 'h') high = guess;
            else if (prompt is 'l') low = guess;
            guess = (low + high) / 2;
         } while (high > low);
      }

      /// <summary> Using Reverse Binary search algorithm to guess number. </summary>
      static void GuessNumberLSB_MSB () {
         double guess = 0;
         for (int i = 1; i <= 7; i++) {
            Write ($"\nIs your number % {Math.Pow (2, i)} < {Math.Pow (2, i - 1)} (y/n)? ");
            if (ReadKey ().Key == ConsoleKey.N) guess += Math.Pow (2, i - 1);
         }
         Write ($"\nYour number is {guess}");
         IsCorrect ('y');
      }
      #endregion
   }
   #endregion
}