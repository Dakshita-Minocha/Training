// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to simulate the wordle game in a console app.
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;
namespace Training {
   #region class Program --------------------------------------------------------------------------
   internal class Program {
      #region Constructors ------------------------------------------
      #endregion

      #region Method ------------------------------------------------
      static void Main (string[] args) {
         Wordle w = new Wordle ();
         w.Run ();
      }
      #endregion

      #region Operators ---------------------------------------------
      #endregion

      #region Implementation ----------------------------------------
      #endregion

      #region Nested Types ------------------------------------------
      #endregion

      #region Private Data ------------------------------------------
      #endregion 
   }
   #endregion

   #region class Wordle ---------------------------------------------------------------------------
   public class Wordle {
      static Wordle () {
         // read files here, operation only done once in a program.
         mPuzzleWords = File.ReadAllLines ("C:/etc/Puzzle5.txt");
         mDict = File.ReadAllLines ("C:/etc/Dict5.txt");

      }
      public Wordle () {
         // operations done everytime a new wordle game is started.
         mInput = new ConsoleKey[5];
         mSecretWord = mPuzzleWords[randomWord.Next (mPuzzleWords.Length)].ToCharArray ();
         mCursor = 0;
      }
      #region Method ------------------------------------------------
      public void Run () {
         OutputEncoding = new UnicodeEncoding ();
         Clear ();
         WriteLine ("WORDLE");
         Display ();
         do {
            GetInput ();
            //Display (); // update display color
            mGuessNum++;
         } while (!CorrectGuess);
         NextLine ();
         Write ($"Congrats! You got it in {mGuessNum} guess{(mGuessNum == 1 ? "" : "es")}.");
      }
      #endregion

      #region Implementation ----------------------------------------
      void GetInput () {
         while (mCursor <= 5) {
            ShiftTo (mCurrentCol, mRow);
            if (mCursor != 5) {
               Write ("◌");
               ShiftTo (mCurrentCol, mRow);
            }
            var input = ReadKey (true).Key;
            switch (input) {
               case >= ConsoleKey.A and <= ConsoleKey.Z:
                  // set input array, increment cursor, reprint current line
                  if (mCursor >= 5) {
                     Message ("Press [Enter] key to submit input or [BackSpace] to edit.");
                     break;
                  }
                  mCurrentCol += mStrLen;
                  mInput[mCursor++] = input;
                  Write ($"{mInput[mCursor - 1]}   ");
                  break;
               case ConsoleKey.LeftArrow:
               case ConsoleKey.Backspace:
                  // decrement cursor, reprint element at previous position
                  if (mCursor <= 0) {
                     Message ("Enter word.");
                     break;
                  }
                  mCursor--;
                  mCurrentCol -= mStrLen;
                  Write ($"·   ");
                  break;
               case ConsoleKey.Enter:
                  // set input array, set cursor to zero, compare, reprint line with colours, go to next line
                  if (mCursor != 5) {
                     Message ("Enter full word before pressing [Enter] key.");
                     break;
                  }
                  CompareAndPrint (string.Join ("", mInput).ToCharArray ());
                  mCurrentCol = mStartCol;
                  mCursor = 0;
                  NextLine ();
                  break;
            }
         }
      }

      void Message (string msg, bool win = false) {
         ShiftTo (mStartCol, mBottomRow);
         ForegroundColor = win ? ConsoleColor.Green : ConsoleColor.Red;
         Write (msg);
         ResetColor ();
      }

      void CompareAndPrint (char[] input) {
         ShiftTo (mStartCol, mRow);
         for (int i = 0; i < mCursor; i++) {
            State[input[i]] = ForegroundColor = input[i] == mSecretWord[i] ? ConsoleColor.Green : (mSecretWord.Any (x => x == input[i]) ? ConsoleColor.Blue : ConsoleColor.Gray);
            Write ($"{input[i]}   ");
         }
         if (input.SequenceEqual (mSecretWord)) {
            CorrectGuess = true;
            Message ("Yay! You guessed it right!", true);
         }
         int c = mCurrentCol, r = mRow;
         mStartCol = -mMaxWordLen;
         mCurrentCol = mStartCol;
         mRow = mAlphaRow;
         ShiftTo (mStartCol, mAlphaRow);
         PrintAlphabets ();
         mCurrentCol = mStartCol = c; mAlphaRow = r;
         NextLine ();
      }
      Dictionary<char, ConsoleColor> State = new ();

      /// <summary>Displaying basic body of Wordle.</summary>
      void Display () {
         ResetColor ();
         mCurrentCol = mStartCol = WindowWidth / 2 - mMaxWordLen; mRow = 1;
         ShiftTo (mStartCol, mRow);
         for (int i = 0; mRow <= 5; i++) {
            for (int j = 0; j < mMaxWordLen; j++) Write ($"·   ");
            NextLine ();
         }
         mCurrentCol -= mMaxWordLen;
         NextLine ();
         Write ("---------------------------");
         NextLine ();
         mAlphaRow = mRow;
         PrintAlphabets ();
         mBottomRow = mRow + 1;
         mRow = 1;
         mCurrentCol = mStartCol;
      }

      void PrintAlphabets () {
         ResetColor ();
         for (char i = 'A', count = '0'; i <= 'Z'; i++, count++) {
            if (count != '7') {
               if (State.TryGetValue (i, out var color)) {
                  ForegroundColor = color;
               }
               State[i] = ConsoleColor.White; // dont need to do this for the first go, see if we can reduce this computation
               Write ($"{i}   ");
               continue;
            }
            NextLine ();
            count = '0';
         }
      }

      void ShiftTo (int col, int row) => SetCursorPosition (col, row);
      void NextLine () => SetCursorPosition (mCurrentCol, ++mRow);
      #endregion

      #region Private Data ------------------------------------------
      bool CorrectGuess = false;
      int mGuessNum, mMaxWordLen = 5, mCurrentCol, mRow, mCursor, mStartCol, mBottomRow, mAlphaRow, mStrLen = "....".Length;
      ConsoleKey[] mInput;
      char[] mSecretWord;
      static string[] mPuzzleWords, mDict;
      static Random randomWord = new ();

      #endregion
   }
   #endregion
}