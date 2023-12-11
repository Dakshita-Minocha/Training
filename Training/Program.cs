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
      Wordle w = new ();
      for (; ; )
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
      CursorVisible = false;
   }
   static string[] mPuzzleWords, mDict;

   /// <summary>Create new Wordle Console Game</summary>
   public Wordle () => mInput = new ConsoleKey[5];
   ConsoleKey[] mInput;
   #endregion

   #region Method ------------------------------------------------
   /// <summary>Run current instance of game.</summary>
   public void Run () {
      OutputEncoding = new UnicodeEncoding ();
      mCursor = 0; mGuessNum = 6; mCorrectGuess = null;
      mSecretWord = mPuzzleWords[mRandomWord.Next (mPuzzleWords.Length)].ToCharArray ();
      Clear ();
      WriteLine ("WORDLE");
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
      mState.Clear ();
   }
   static Random mRandomWord = new ();
   char[] mSecretWord;
   bool? mCorrectGuess;
   int mGuessNum;
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
         mState[input[i]] = ForegroundColor = input[i] == mSecretWord[i] ? ConsoleColor.Green :
                           (mSecretWord.Any (x => x == input[i]) ? ConsoleColor.Blue : ConsoleColor.DarkGray);
         Write ($"{input[i]}   ");
      }
      (int c, int r) = (mCurrentCol, mRow);
      (mCurrentCol, mRow) = (mStartCol - mMaxWordLen, mAlphaRow);
      ShiftTo (mCurrentCol, mAlphaRow);
      PrintAlphabets ();
      (mCurrentCol, mRow) = (c, r);
      if (input.SequenceEqual (mSecretWord)) return true;
      return false;
   }
   Dictionary<char, ConsoleColor> mState = new ();

   /// <summary>Displaying basic body of Wordle.</summary>
   void DisplaySkeleton () {
      mCurrentCol = mStartCol = WindowWidth / 2 - mMaxWordLen; mRow = 1;
      ShiftTo (mStartCol, mRow);
      for (int i = 0; i < mGuessNum; i++) {
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
      NextLine (); NextLine ();
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

   /// <summary>Displays disappering messages for user at the bottom of game console.</summary>
   void Message (string msg) {
      ForegroundColor = ConsoleColor.Yellow;
      Print ();
      ReadKey (true);
      Print (true);
      ForegroundColor = ConsoleColor.White;
      ShiftTo (mCurrentCol, mRow);

      void Print (bool blank = false) {
         ShiftTo (mStartCol - mMaxWordLen, mMessageRow);
         Write (blank ? new string (' ', msg.Length) : $"{msg}");
      }
   }

   /// <summary>Sets cursor to next line in same column</summary>
   void NextLine () => SetCursorPosition (mCurrentCol, ++mRow);

   /// <summary>Prints bottom Alphabets for user reference with approriate colours.</summary>
   void PrintAlphabets () {
      int count = 0;
      for (char i = 'A'; i <= 'Z'; i++) {
         if (mState.TryGetValue (i, out var color)) ForegroundColor = color;
         else mState[i] = ConsoleColor.White;
         Write ($"{i}   ");
         if (count == 6) NextLine ();
         count = (count + 1) % 7; // displaying 7 letters in a single line
      }
      ResetColor ();
   }

   /// <summary>Shifts cursor to required column position in given row</summary>
   void ShiftTo (int col, int row) => SetCursorPosition (col, row);

   /// <summary>Updates state of wordle game based on user inputs recieved from GetInput().</summary>
   void UpdateState (ConsoleKey input) {
      switch (input) {
         case >= ConsoleKey.A and <= ConsoleKey.Z:
            if (Error (mCursor >= 5, "Press [Enter] key to submit input or [BackSpace] to edit.")) break;
            // print input, set input array, increment cursor
            mInput[mCursor++] = input;
            Write ($"{mInput[mCursor - 1]}   ");
            mCurrentCol += mStrLen;
            break;
         case ConsoleKey.LeftArrow or ConsoleKey.Backspace:
            if (Error (mCursor <= 0, "Enter word.")) break;
            // decrement cursor, reprint element at previous position
            if (mCursor != 5) Write ($"·   ");
            mCursor--;
            mCurrentCol -= mStrLen;
            break;
         case ConsoleKey.Enter:
            if (Error (mCursor != 5, "Enter full word before pressing [Enter] key.")) break;
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

      // Calls Message() if Error condition is met
      bool Error (bool condition, string msg) {
         if (condition) Message (msg);
         return condition;
      }
   }
   #endregion

   #region Private Data ------------------------------------------
   int mCurrentCol, mRow, mCursor, mStartCol, mMessageRow, mAlphaRow;
   readonly int mStrLen = "....".Length, mMaxWordLen = 5;
   #endregion
}
#endregion
//if (mCursor >= 5) {
//   Message ("Press [Enter] key to submit input or [BackSpace] to edit.");
//   break;
//}

//if (mCursor <= 0) {
//   Message ("Enter word.");
//   break;
//}

//if (mCursor != 5) {
//   Message ("Enter full word before pressing [Enter] key.");
//   break;
//}