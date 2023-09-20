// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to swap indices from predefined array.
// User enters two indices to swap and new array with swapped elements is displayed. 
// Swapped elements and their indices are displayed in Green Foreground Color.
// ---------------------------------------------------------------------------------------
using static System.Console;
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main () => SwapIndices ();

      /// <summary> Prompts user to enter indices from array to swap, performs swap and passes list to PrintNumber for displaying results. </summary>
      static void SwapIndices () {
         List<int> list = new () { 128, 3, 4, 5, 4, 8, 8, 9, 2, 18 };
         Write ($"Elements: {string.Join ("  ", list)}\nIndices:  ");
         for (int i = 0; i < list.Count; i++) Write ($"{i,2} ");
         for (; ; ) {
            WriteLine ("\nEnter 2 indices (from within range) to swap, or [Q] to exit: ");
            string[] input = ReadLine ().Split ();
            if (input.Any (c => c.ToLower () == "q")) return;
            if (input.Length == 2 && int.TryParse (input[0], out int i1) && int.TryParse (input[1], out int i2))
               if (i1 >= 0 && i1 < list.Count && i2 >= 0 && i2 < list.Count) { // both inputs are numbers within range
                  SwapIndex (i1, i2);
                  PrintNumber (list, i1, i2);
               }
         }

         /// <summary> Performs swap for given index values </summary>
         void SwapIndex (int i1, int i2) => (list[i1], list[i2]) = (list[i2], list[i1]);

         /// <summary> Performs swap for given index values </summary>
         void PrintNumber (List<int> swapped, int i1, int i2) {
            int index = 0;
            Write ("Elements:   \nIndices: ");
            (int x, int y) = GetCursorPosition ();
            SetCursorPosition (x, y - 1);
            foreach (var element in swapped) {
               int len = $"{element,2} ".Length;
               bool flag = index == i1 || index == i2;
               if (flag) ForegroundColor = ConsoleColor.Green;
               Write ($"{element,2} ");
               (x, y) = GetCursorPosition ();
               SetCursorPosition (x - len, y + 1);
               Write ($"{index,2} ");
               if (flag) ResetColor ();
               index++;
               SetCursorPosition (x, y);
            }
            SetCursorPosition (0, y + 2);
         }
      }
      #endregion
   }
   #endregion
}