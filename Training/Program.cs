// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on main branch.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training;
#region class Program --------------------------------------------------------------------------
internal class Program {
   #region Method ------------------------------------------------
   static void Main (string[] args) => Start ();
   static void Start () {
      Dictionary<int, int> gameState = new ();
      ConsoleKeyInfo input;
      WriteLine ("\nPress the indicated number keys to play game.\nPlayer1: X   Player2: O\n");
      (int xi, int yi) = GetCursorPosition ();
      yi++;
      DisplayInitial ();
      int xf, yf;
      while (gameState.Count <= 9) {
         for (int pNum = 1; pNum <= 2; pNum++) {
            (xf, yf) = GetCursorPosition ();
            WriteLine ($"Player{pNum}: Your Turn");
            while (true) {
               input = ReadKey (true);
               gameState.TryGetValue (input.KeyChar - '0', out int value);
               if (value == 0) {
                  switch (input.Key) {
                     case ConsoleKey.D1: gameState[1] = pNum; UpdateState (pNum, 0, 0); break;
                     case ConsoleKey.D2: gameState[2] = pNum; UpdateState (pNum, 0, 1); break;
                     case ConsoleKey.D3: gameState[3] = pNum; UpdateState (pNum, 0, 2); break;
                     case ConsoleKey.D4: gameState[4] = pNum; UpdateState (pNum, 1, 0); break;
                     case ConsoleKey.D5: gameState[5] = pNum; UpdateState (pNum, 1, 1); break;
                     case ConsoleKey.D6: gameState[6] = pNum; UpdateState (pNum, 1, 2); break;
                     case ConsoleKey.D7: gameState[7] = pNum; UpdateState (pNum, 2, 0); break;
                     case ConsoleKey.D8: gameState[8] = pNum; UpdateState (pNum, 2, 1); break;
                     case ConsoleKey.D9: gameState[9] = pNum; UpdateState (pNum, 2, 2); break;
                     default: continue;
                  }
                  break;
               }
            }
         }
      }

      void UpdateState (int pNum, int i, int j) {
         SetCursorPosition (xi + (j * 4) + 1, yi + (i * 2) - 1);
         Write ($"{(pNum == 1 ? "X" : "O")}");
         SetCursorPosition (xf, yf);
         if (CheckForWin (pNum, input.KeyChar - '0')) {
            WriteLine ($"Player{pNum} wins!     ");
            Environment.Exit (0);
         }
      }

      bool CheckForWin (int currentPlayer, int key) {
         int horizontalKey = key switch {
            1 or 2 or 3 => 1, 4 or 5 or 6 => 4,
            _ => 7
         }, verticalKey = key switch {
            1 or 4 or 7 => 1, 2 or 5 or 8 => 2,
            _ => 3
         }, count = 0;
         if (Compare (horizontalKey, 1)) return true;
         count = 0;
         if (Compare (verticalKey, 3)) return true;
         count = 0;
         if (key is 1 or 5 or 9 && Compare (1, 4)) return true;
         count = 0;
         if (key is 3 or 5 or 7 && Compare (3, 2)) return true;

         return false;

         // ---------------------------------------------------------
         bool Compare (int startwith, int addNum) {
            gameState.TryGetValue (startwith, out var value);
            if (count == 3) return true;
            if (value != 0 && value == currentPlayer) {
               count++;
               return Compare (startwith + addNum, addNum);
            } else return false;
         }
      }

      static void DisplayInitial () {
         for (int i = 1, count = 1; i <= 3; i++) {
            for (int j = 1; j <= 3; j++)
               Write ($" {count++} " + $"{(j == 3 ? "\n" : "│")}");
            if (i == 3) break;
            for (int j = 1; j <= 3; j++)
               Write ("───" + $"{(j == 3 ? "\n" : "┼")}");
         }
         WriteLine ();
      }
      #endregion
   }
}
#endregion