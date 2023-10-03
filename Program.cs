// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to find and display general and fundamental solutions of the Eight Queen problem.
// ---------------------------------------------------------------------------------------

using System.Text;
using static System.Console;

namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static int size = 8;
      static List<List<(int, int)>> solutions = new ();

      static void Main (string[] args) => Menu ();

      static void Menu () {
         WriteLine ("Eight Queens solutions:\nChoose from menu below:\n1. All solutions\n2.Fundamental Solutions");
         switch (ReadKey (true).Key) {
            case ConsoleKey.D1: EightQ (); break;
            case ConsoleKey.D2: EightQ ("unique"); break;
            default: Menu (); break;
         }
      }

      /// <summary> Prints 8queen solution </summary>
      /// <param name="sol"> Inducates the kind of solutions user wants (All/Fundamental) </param>
      static void EightQ (string sol = "All") {
         OutputEncoding = new UnicodeEncoding ();
         List<(int row, int col)> positions = new ();
         FindSol (0, positions, sol);
         for (int count = 0; count < solutions.Count; count++) {
            WriteLine (count + 1);
            for (int i = 0; i < size; i++) {
               PrintLine (i);
               for (int j = 0; j < size; j++)
                  Write ("\u2502 " + (solutions[count].Contains ((i, j)) ? "♕ " : "  "));
               Write ('\u2502' + "\n");
            }
            PrintLine (8);
         }
      }

      /// <summary> Finds solution to the 8queen problem and returns a list with positions. 
      /// Column no. = constant : we go through each row to see if there's a position that 
      /// satisfies the condition. </summary>
      /// <param name="col"> Column number, starts with column 0. </param>
      /// <param name="positions"> List of possible safe positions for the 8 queens. </param>
      static void FindSol (int col, List<(int row, int column)> positions, string sol) {
         if (positions.Count == 8) {
            if (sol == "unique") if (RotatedMirror (positions)) return;
            solutions.Add (positions.ToList ());
            return;
         }
         for (int i = 0; i < size; i++)
            if (Check (i, col, positions)) {
               positions.Add ((i, col));
               FindSol (col + 1, positions, sol);
               positions.Remove ((i, col));
            }
      }

      /// <summary> Checks whether it is safe to place a queen in a given position. </summary>
      /// <param name="row"> Current row </param>
      /// <param name="col"> Current column </param>
      /// <param name="positions"> List of valid positions according to rules </param>
      /// <returns> Returns true/false based on whether current position is safe. </returns>
      static bool Check (int row, int col, List<(int row, int column)> positions) {
         // same row
         for (int x = 0; x < size; x++)
            if (positions.Any (c => c.row == row && c.column == x)) return false;
         // upper left diagonal
         for (int x = row, y = col; x >= 0 && y >= 0; x--, y--)
            if (positions.Any (c => c.row == x && c.column == y)) return false;
         // lower left diagonal
         for (int x = row, y = col; x < size && y >= 0; x++, y--)
            if (positions.Any (c => c.row == x && c.column == y)) return false;
         // if it is safe to place a queen
         return true;
      }

      /// <summary> Checks if the 90, 180 or 270 degree rotated version or mirrors of any of them 
      /// including current solution exist in the solution list. </summary>
      /// <param name="positions"> Current solution for 8queen problem. </param>
      /// <returns> Returns true if solution already exists. </returns>
      static bool RotatedMirror (List<(int row, int column)> positions) {
         List<(int row, int column)> rotate90 = new ();
         List<(int row, int column)> rotate180 = new ();
         List<(int row, int column)> rotate270 = new ();
         // 90 degree check
         foreach (var pos in positions)
            rotate90.Add ((pos.column, size - 1 - pos.row));
         // 180 degree check
         foreach (var pos in rotate90)
            rotate180.Add ((pos.column, size - 1 - pos.row));
         // 270 degree check
         foreach (var pos in rotate180)
            rotate270.Add ((pos.column, size - 1 - pos.row));
         // return true if solutions already contains rotated solution, or mirrors of rotated solutions
         return solutions.Any (sol => rotate90.All (sol.Contains) || rotate180.All (sol.Contains) || rotate270.All (sol.Contains) ||
                                      Mirror (positions) || Mirror (rotate90) || Mirror (rotate180) || Mirror (rotate270));
      }

      /// <summary> Checks if the current solution (stored in positions list) has an existing mirror already in list of solutions. </summary>
      /// <param name="positions"> Current solution for 8queen problem. </param>
      /// <returns> Returns true, if mirror exists. </returns>
      static bool Mirror (List<(int row, int column)> positions) {
         List<(int, int)> hmirror = new ();
         List<(int, int)> vmirror = new ();
         foreach (var (row, column) in positions) {
            hmirror.Add ((row, size - 1 - column)); // Horizontal mirror check
            vmirror.Add ((size - 1 - row, column)); // Vertical mirror check
         }
         return solutions.Any (sol => hmirror.All (sol.Contains) || vmirror.All (sol.Contains));
      }

      /// <summary> Prints box grid using UNICODE characters. </summary>
      /// <param name="row"> row number </param>
      static void PrintLine (int row) {
         Write (row == 0 ? '┌' : (row == size ? '└' : '├'));
         for (int i = 0; i < size; i++)
            Write (new string ('─', 3) + (i == size - 1 ? (row == 0 ? '┐' : (row == size ? '┘' : '┤')) :
                                                                  (row == 0 ? '┬' : (row == size ? '┴' : '┼'))));
         WriteLine ();
      }
      #endregion
   }
   #endregion
}