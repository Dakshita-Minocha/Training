// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to swap indices from predefined array.
// User enters two indices to swap and new array with swapped elements is displayed. 
// Swapped elements and their indices are displayed in Green Foreground Color.
// ---------------------------------------------------------------------------------------
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main () => SwapIndices ();

      /// <summary> Prompts user to enter indices from array to swap, performs swap and passes list to PrintNumber for displaying results. </summary>
      static void SwapIndices () {
         List<int> list = new () { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         Console.Write ($"Elements: {string.Join (" ", list)}\n" +
                        $"Indices:  {string.Join (" ", list.Select (a => list.IndexOf (a)))} ");
         for (; ; ) {
            Console.WriteLine ("\nEnter 2 indices (from within range) to swap, or [Q] to exit: ");
            string[] input = Console.ReadLine ().Split ();
            if (input.Any (c => c.ToLower () == "q")) return;
            if (input.Length == 2 && int.TryParse (input[0], out int i1) && int.TryParse (input[1], out int i2))
               if (i1 >= 0 && i1 < list.Count && i2 >= 0 && i2 < list.Count) { // both inputs are numbers within range
                  SwapIndex (i1, i2);
                  PrintNumber (list.Select (a => (a, list.IndexOf (a), a == list[i1] || a == list[i2])).ToList ());
               }
         }

         /// <summary> Performs swap for given index values </summary>
         void SwapIndex (int i1, int i2) => (list[i1], list[i2]) = (list[i2], list[i1]);

         /// <summary> Performs swap for given index values </summary>
         void PrintNumber (List<(int, int, bool)> swapped) {
            Console.Write ("Elements:   \nIndices: ");
            (int x, int y) = Console.GetCursorPosition ();
            Console.SetCursorPosition (x, y - 1);
            foreach (var (element, index, flag) in swapped) {
               int len = $"{element} ".Length;
               Console.Write ($"{element} ", Console.ForegroundColor = flag ? ConsoleColor.Green : ConsoleColor.White);
               (x, y) = Console.GetCursorPosition ();
               Console.SetCursorPosition (x - len, y + 1);
               Console.Write ($"{index} ", Console.ForegroundColor = flag ? ConsoleColor.Green : ConsoleColor.White);
               Console.SetCursorPosition (x, y);
            }
            Console.ResetColor ();
            Console.SetCursorPosition (0, y + 2);
         }
      }
      #endregion
   }
   #endregion
}