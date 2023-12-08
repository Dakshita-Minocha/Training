// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to simulate the wordle game in a console app.
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;
namespace Training;

#region Class Program --------------------------------------------------------------------------
internal class Program {
   #region Method ------------------------------------------------
   static void Main (string[] args) {
      Wordle w = new Wordle ();
      w.Run ();
   }
   #endregion
}
#endregion

#region Class Wordle ---------------------------------------------------------------------------
public class Wordle {
   #region Constructors ------------------------------------------
   /// <summary>Static constructor to read and close dict files.</summary>
   static Wordle () {
      mPuzzleWords = File.ReadAllLines ("C:/etc/Puzzle-5.txt");
      mDict = File.ReadAllLines ("C:/etc/Dict-5.txt");
   }
   static string[] mPuzzleWords, mDict;

   /// <summary>Create new Wordle Console Game</summary>
   public Wordle () {
      mInput = new ConsoleKey[5];
      mSecretWord = mPuzzleWords[randomWord.Next (mPuzzleWords.Length)].ToCharArray ();
      mCursor = 0;
   }
   static Random randomWord = new ();
   ConsoleKey[] mInput;
   char[] mSecretWord;
   #endregion

   #region Method ------------------------------------------------
   /// <summary>Run current instance of game.</summary>
   public void Run () {
      OutputEncoding = new UnicodeEncoding ();
      for (; ; ) {
         Clear ();
         WriteLine ("WORDLE", ForegroundColor = ConsoleColor.White);
         DisplaySkeleton ();
         do {
            GetInput ();
            mGuessNum--;
         } while (mGuessNum > 0 && mCorrectGuess == false);
         NextLine ();
         ResetColor ();
         Message (mCorrectGuess == true ?
                  $"Congrats! You got it right in just {6 - mGuessNum} guess{(mGuessNum == 5 ? "" : "es")}." :
                  $"Oops! The answer was {string.Join ("", mSecretWord)}. Better luck next time!");
      }
   }
   bool? mCorrectGuess;
   int mGuessNum = 6;
   #endregion

   #region Implementation ----------------------------------------
   /// <summary>Checks if input is a valid word from dictionary,
   /// compares input with generated Secret Word, and re-prints coloured input as hints.</summary>
   /// <returns> Null if input is not a valid word.
   /// False if input is a valid wrd but is not the secret word.
   /// True if input is the secret word.</returns>
   bool? CompareAndPrint (char[] input) {
      if (!mDict.Any (x => x.SequenceEqual (string.Join ("", input)))) {
         Message ("Enter valid word.");
         return null;
      }
      ShiftTo (mStartCol, mRow);
      for (int i = 0; i < mCursor; i++) {
         State[input[i]] = ForegroundColor = input[i] == mSecretWord[i] ? ConsoleColor.Green :
                           (mSecretWord.Any (x => x == input[i]) ? ConsoleColor.Blue : ConsoleColor.DarkGray);
         Write ($"{input[i]}   ");
      }
      if (input.SequenceEqual (mSecretWord)) return true;
      (int c, int r) = (mCurrentCol, mRow);
      (mCurrentCol, mRow) = (mStartCol - mMaxWordLen, mAlphaRow);
      ShiftTo (mCurrentCol, mAlphaRow);
      PrintAlphabets ();
      (mCurrentCol, mRow) = (c, r);
      return false;
   }
   Dictionary<char, ConsoleColor> State = new ();

   /// <summary>Displaying basic body of Wordle.</summary>
   void DisplaySkeleton () {
      mCurrentCol = mStartCol = WindowWidth / 2 - mMaxWordLen; mRow = 1;
      ShiftTo (mStartCol, mRow);
      int tries = 6;
      for (int i = 0; i < tries; i++) {
         for (int j = 0; j < mMaxWordLen; j++) Write ($"·   ");
         NextLine ();
      }
      mCurrentCol -= mMaxWordLen;
      NextLine ();
      Write ("---------------------------");
      NextLine ();
      mAlphaRow = mRow;
      PrintAlphabets ();
      mMessageRow = mRow + 1;
      NextLine ();
      NextLine ();
      Write ("Press [Esc] to exit.");
      mRow = 1;
      mCurrentCol = mStartCol;
   }

   /// <summary>Maintains Display state as user inputs and calls UpdateState() after each input.</summary>
   void GetInput () {
      mCorrectGuess = null;
      while (mCursor <= 5 && mCorrectGuess == null) {
         ShiftTo (mCurrentCol, mRow);
         if (mCursor != 5) {
            Write ("◌");
            ShiftTo (mCurrentCol, mRow);
         }
         UpdateState (ReadKey (true).Key);
      }
   }

   /// <summary>Displays disappering messages (2 seconds) for user at the bottom of game console.</summary>
   void Message (string msg) {
      ShiftTo (mStartCol - mMaxWordLen, mMessageRow);
      Write ($"{msg}", ForegroundColor = ConsoleColor.Yellow);
      ReadKey (true);
      ShiftTo (mStartCol - mMaxWordLen, mMessageRow);
      Write (new string (' ', msg.Length));
      ForegroundColor = ConsoleColor.White;
      ShiftTo (mCurrentCol, mRow);
   }

   /// <summary>Sets cursor to next line in same column</summary>
   void NextLine () => SetCursorPosition (mCurrentCol, ++mRow);

   /// <summary>Prints bottom Alphabets for user reference with approriate colours.</summary>
   void PrintAlphabets () {
      int count = 0;
      for (char i = 'A'; i <= 'Z'; i++, count++) {
         if (count == 7) { count = 0; NextLine (); }
         if (State.TryGetValue (i, out var color)) ForegroundColor = color;
         else State[i] = ConsoleColor.White;
         Write ($"{i}   ");
         ResetColor ();
      }
   }

   /// <summary>Shifts cursor to required column position in given row</summary>
   void ShiftTo (int col, int row) => SetCursorPosition (col, row);

   /// <summary>Updates state of wordle game based on user inputs recieved from GetInput().</summary>
   void UpdateState (ConsoleKey input) {
      switch (input) {
         case >= ConsoleKey.A and <= ConsoleKey.Z:
            if (mCursor >= 5) {
               Message ("Press [Enter] key to submit input or [BackSpace] to edit.");
               break;
            }
            // print input, set input array, increment cursor
            mInput[mCursor++] = input;
            Write ($"{mInput[mCursor - 1]}   ");
            mCurrentCol += mStrLen;
            break;
         case ConsoleKey.LeftArrow or ConsoleKey.Backspace:
            if (mCursor <= 0) {
               Message ("Enter word.");
               break;
            }
            // decrement cursor, reprint element at previous position
            if (mCursor != 5) Write ($"·   ");
            mCursor--;
            mCurrentCol -= mStrLen;
            break;
         case ConsoleKey.Enter:
            if (mCursor != 5) {
               Message ("Enter full word before pressing [Enter] key.");
               break;
            }
            // set input array cursor to zero, compare, if valid word: reprint line with colours, go to next line, if correct guess: return true.
            mCurrentCol = mStartCol;
            mCorrectGuess = CompareAndPrint (string.Join ("", mInput).ToCharArray ());
            mCursor = 0;
            if (mCorrectGuess == false) NextLine ();
            break;
         case ConsoleKey.Escape:
            ShiftTo (mStartCol, mMessageRow + 2);
            Environment.Exit (0); break;
      }
   }
   #endregion

   #region Private Data ------------------------------------------
   int mCurrentCol, mRow, mCursor, mStartCol, mMessageRow, mAlphaRow;
   readonly int mStrLen = "....".Length, mMaxWordLen = 5;
   #endregion
}
#endregion