// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on main branch.
// ------------------------------------------------------------------------------------------------
using System;
using static System.Console;
namespace Training;
#region class Program --------------------------------------------------------------------------
internal class Program {
   #region Constructors ------------------------------------------
   #endregion

   #region Method ------------------------------------------------
   static void Main (string[] args) => Start ();
   static void Start () {
      Dictionary<int, int> gameState = new ();
      ConsoleKey enterKey;
      WriteLine ("\nPress the indicated number keys to play game.\nPlayer1: X   Player2: O\n");
      (int xi, int yi) = GetCursorPosition ();
      yi++;
      DisplayInitial ();
      int xf, yf;
      while (true) {
         for (int pNum = 1; pNum <= 2; pNum++) {
            (xf, yf) = GetCursorPosition ();
            WriteLine ($"Player{pNum}: Your Turn");
            enterKey = ReadKey (true).Key;
            switch (enterKey) {
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
         }
      }

      bool Check (int currentPlayer, int key) {
         gameState.TryGetValue (key, out var value);
         if (value == currentPlayer) {
            return Check (currentPlayer, key + 3);
         } else return false;
      }

      void UpdateState (int pNum, int i, int j) {
         SetCursorPosition (xi + (j * 4) + 1, yi + (i * 2) - 1);
         Write ($"{(pNum == 1 ? "X" : "O")}");
         SetCursorPosition (xf, yf);
         if (Check (pNum, (int)enterKey)) Environment.Exit (0);
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
   enum Player {
      X = 1
   }
}
#endregion