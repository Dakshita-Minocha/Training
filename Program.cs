// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ---------------------------------------------------------------------------
// Program.cs
// Program to find and display general and fundamental sSolutions of the Eight Queen problem.
// ---------------------------------------------------------------------------------------
using System.Text;
using static System.Console;
namespace Training;

#region class Program ------------------------------------------------------------------------
internal class Program {
   #region Method ----------------------------------------------
   static void Main (string[] args) => Menu ();

   static void Menu () {
      WriteLine ("Eight Queens solutions:\nChoose from menu below:\n1. All solutions\n2.Fundamental Solutions\nE. Exit");
      switch (ReadKey (true).Key) {
         case ConsoleKey.D1: EightQ (); break;
         case ConsoleKey.D2: EightQ (true); break;
         case ConsoleKey.E: Environment.Exit (0); break;
         default: Menu (); break;
      }
   }

   /// <summary>Prints 8queen solution</summary>
   /// <param name="sol">Indicates the kind of sSolutions user wants (All/Fundamental)</param>
   static void EightQ (bool unique = false) {
      OutputEncoding = new UnicodeEncoding ();
      FindSol (0, unique);
      int count = 0, numOfSol = sSolutions.Count, x, y;
      (x, y) = GetCursorPosition ();
      while (count != numOfSol) {
         CursorTop = y; CursorLeft = x;
         WriteLine ($"Solution {count + 1} of {numOfSol}");
         for (int i = 0; i < sSize; i++) {
            PrintLine (i);
            for (int j = 0; j < sSize; j++)
               Write ("│ " + (sSolutions[count][j] == i ? "♕ " : "  "));
            WriteLine ("│");
         }
         PrintLine (8);
         Write (count == numOfSol - 1 ? "\r\n" : "Press [space] to view next solution, [Esc] to exit.");
         switch (ReadKey (true).Key) {
            case ConsoleKey.Spacebar:
               count++;
               continue;
            case ConsoleKey.Escape:
               return;
            default:
               break;
         }
      }
   }

   /// <summary>Finds solution to the 8queen problem and returns a list with sPositions.
   /// Column no. = constant : we go through each row to see if there's a position that
   /// satisfies the condition.</summary>
   /// <param name="col">Column number, starts with column 0.</param>
   /// <param name="positions">List of possible safe sPositions (row numbers for
   /// consecutive columns) for the 8queens.</param>
   /// <param name="solutions">List of all possible sSolutions for the 8queens problem.</param>
   static void FindSol (int col, bool unique) {
      for (sPositions[col] = 0; sPositions[col] < sSize; sPositions[col]++) {
         if (!IsValidPos ()) continue;
         if (col == sSize - 1) {
            if (unique == true && Exists (sPositions.ToArray ())) return;
            sSolutions.Add (sPositions.ToArray ());
         } else FindSol (col + 1, unique);
      }

      // Checks whether it is safe to place a queen in a given position.
      // Returns true/false based on whether current position is safe.
      bool IsValidPos () {
         for (int x = 0; x < col; x++) {
            int dx = col - x, dy = Math.Abs (sPositions[col] - sPositions[x]);
            if (dy == 0 || dy == dx) return false;
         }
         return true;
      }
   }

   /// <summary>Checks if the current solution, 90, 180 or 270 degree rotated version or mirrors
   /// of any of them exist in the solution list.</summary>
   /// <param name="positions">Current solution for 8queen problem.</param>
   /// <returns>Returns true if solution already exists.</returns>
   static bool Exists (int[] positions) {
      for (int x = 0; x < 4; x++) {
         positions = Rotate (positions);
         if (sSolutions.Any (sol => sol.SequenceEqual (positions) || sol.SequenceEqual (Mirror (positions)))) return true;
      }
      return false;
   }

   /// <summary>Rotates solution by 90 degrees.</summary>
   /// <param name="positions">Current solution list to be rotated.</param>
   /// <returns>Rotated solution (by 90 degrees)</returns>
   static int[] Rotate (int[] positions) {
      int[] temp = new int[sSize];
      for (int i = 0; i < sSize; i++)
         temp[positions[i]] = sSize - 1 - i;
      return temp;
   }

   /// <summary>Mirrors current solution.</summary>
   /// <param name="positions">Current solution for 8queen problem.</param>
   /// <returns>Mirrored solution.</returns>
   static int[] Mirror (int[] positions) => positions.Select (x => sSize - 1 - x).ToArray ();

   /// <summary>Prints box grid using UNICODE characters.</summary>
   /// <param name="row">row number</param>
   static void PrintLine (int row) {
      Write (row == 0 ? '┌' : (row == sSize ? '└' : '├'));
      for (int i = 0; i < sSize; i++)
         Write ("───" + (i == sSize - 1 ? (row == 0 ? '┐' : (row == sSize ? '┘' : '┤')) :
                                          (row == 0 ? '┬' : (row == sSize ? '┴' : '┼'))));
      WriteLine ();
   }
   #endregion

   #region Private Data ------------------------------------------
   static int sSize = 8;
   static List<int[]> sSolutions = new ();
   static int[] sPositions = new int[sSize];
   #endregion
}
#endregion