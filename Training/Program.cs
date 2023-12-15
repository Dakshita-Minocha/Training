// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to simulate the wordle game in a console app.
// ------------------------------------------------------------------------------------------------
using System.Runtime.CompilerServices;
using System.Text;
using static System.Console;

[assembly: InternalsVisibleTo ("TestTraining")]
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
      mDictionaryWords = File.ReadAllLines ("C:/etc/Dict-5.txt");
   }
   static string[] mPuzzleWords, mDictionaryWords;

   /// <summary>Create new Wordle Console Game</summary>
   public Wordle () { mInput = new ConsoleKey[5]; }
   ConsoleKey[] mInput;
   #endregion

   #region Properties ------------------------------------------
   internal string SecretWord {
      get => mSecretWord;
      set => mSecretWord = value;
   }
   string mSecretWord;
   #endregion

   #region Method ------------------------------------------------
   /// <summary>Run current instance of game.</summary>
   public void Run (bool save = false, string saveToFile = null) {
      OutputEncoding = new UnicodeEncoding ();
      mCursor = 0; mGuessNum = 6;
      SecretWord ??= mPuzzleWords[mRandomWord.Next (mPuzzleWords.Length)];
      mFileName ??= saveToFile;
      Clear ();
      WriteLine ("WORDLE");
      DisplaySkeleton ();
      do {
         GetInput ();
         if (save) Save ();
      } while (mGuessNum > 0 && !mCorrectGuess);
      ResetColor ();
      Message (mCorrectGuess ?
               $"Congrats! You got it right in just {6 - mGuessNum} guess{(mGuessNum == 5 ? "" : "es")}." :
               $"Oops! The answer was {SecretWord}. Better luck next time!");
      if (save) Save (-1);
      mState.Clear ();
      SecretWord = null;
   }
   static Random mRandomWord = new ();
   bool mCorrectGuess;
   int mGuessNum = 6;
   #endregion

   #region Implementation ----------------------------------------
   /// <summary>Checks if input is a valid word from dictionary,
   /// compares input with generated Secret Word, and re-prints coloured input as hints.</summary>
   /// <returns> True if input is Secret word else false.</returns>
   void Compare (string input) {
      if (!mDictionaryWords.Contains (input)) {
         Message ("Enter valid word.");
         mCursor = 0;
         mCorrectGuess = false;
         return;
      }
      for (int i = 0; i < mCursor; i++) {
         mState[input[i]] = input[i] == SecretWord[i] ? ConsoleColor.Green :
                                        (SecretWord.Contains (input[i]) &&
                                        input[..i].Count (a => a == input[i]) < SecretWord.Count (x => x == input[i]) ? ConsoleColor.Blue : ConsoleColor.DarkGray);
      }
      mGuessNum--;
      mCorrectGuess = input == SecretWord;
   }
   internal Dictionary<char, ConsoleColor> mState = new ();

   /// <summary>Updates console to display current state of game.</summary>
   void DisplayUpdate (string input) {
      ShiftTo (mStartCol, mRow);
      for (int i = 0; i < mCursor - 1; i++) {
         ForegroundColor = mState[input[i]];
         Write ($"{input[i]}   ");
      }
      (int c, int r) = (mCurrentCol, mRow);
      (mCurrentCol, mRow) = (mStartCol - mMaxWordLen, mAlphaRow);
      ShiftTo (mCurrentCol, mAlphaRow);
      PrintAlphabets ();
      (mCurrentCol, mRow) = (c, r);
   }

   /// <summary>Displaying basic body of Wordle.</summary>
   void DisplaySkeleton () {
      CursorVisible = false;
      mCurrentCol = mStartCol = WindowWidth / 2 - mMaxWordLen; mRow = 1;
      ShiftTo (mStartCol, mRow);
      for (int i = 0; i < mGuessNum; i++) {
         for (int j = 0; j < mMaxWordLen; j++) Write ($"·   ");
         NextLine ();
      }
      mCurrentCol -= mMaxWordLen;
      NextLine ();
      Write ("---------------------------"); NextLine ();
      mAlphaRow = mRow;
      PrintAlphabets ();
      mMessageRow = mRow + 1;
      NextLine (); NextLine ();
      Write ("Press [Esc] to exit.");
      (mCurrentCol, mRow) = (mStartCol, 1);
   }

   /// <summary>Maintains Display state as user inputs and calls UpdateState() after each input.</summary>
   void GetInput () {
      while (mCursor <= 5) {
         ShiftTo (mCurrentCol, mRow);
         if (mCursor != 5) {
            Write ("◌");
            ShiftTo (mCurrentCol, mRow);
         }
         UpdateState (ReadKey (true).Key);
      }
      if (mCursor == 6) {
         DisplayUpdate (string.Join ("", mInput));
         mCursor = 0;
         mRow++;
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

   /// <summary>Saves current state of game to file, i = -1 for saving final result.</summary>
   internal void Save (int i = 0) {
      if (i != -1) {
         File.AppendAllLines (mFileName, new string[] { string.Join ("", mInput) });
         File.AppendAllLines (mFileName, mState.Select (kvp => $"{kvp.Key}: {kvp.Value}"));
      } else {
         string[] temp = File.ReadAllLines (mFileName);
         File.WriteAllLines (mFileName, new string[] { SecretWord, $"{mCorrectGuess}", $"{6 - mGuessNum}" });
         File.AppendAllLines (mFileName, temp);
      }
   }
   internal string mFileName;

   /// <summary>Shifts cursor to required column position in given row</summary>
   void ShiftTo (int col, int row) => SetCursorPosition (col, row);

   /// <summary>Updates state of wordle game based on user inputs recieved from GetInput().</summary>
   internal void UpdateState (ConsoleKey input) {
      switch (input) {
         case >= ConsoleKey.A and <= ConsoleKey.Z:
            if (Error (mCursor >= 5, "Press [Enter] key to submit input or [BackSpace] to edit.")) break;
            // print input, set input array, increment cursor
            mInput[mCursor++] = input;
            Write ($"{mInput[mCursor - 1]}   ");
            mCurrentCol += 4;
            break;
         case ConsoleKey.LeftArrow or ConsoleKey.Backspace:
            if (Error (mCursor <= 0, "Enter word.")) break;
            // decrement cursor, reprint element at previous position
            if (mCursor != 5) Write ($"·   ");
            mCursor--;
            mCurrentCol -= 4;
            break;
         case ConsoleKey.Enter:
            if (Error (mCursor != 5, "Enter full word before pressing [Enter] key.")) break;
            // compare input with secretword, set col back to start.
            Compare (string.Join ("", mInput));
            mCurrentCol = mStartCol;
            if (mCursor == 0) break;
            mCursor = 6;
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
   int mCurrentCol, mRow, mStartCol, mMessageRow, mAlphaRow;
   readonly int mMaxWordLen = 5;
   internal int mCursor;
   #endregion
}
#endregion