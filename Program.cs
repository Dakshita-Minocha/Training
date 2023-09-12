namespace Training {
   internal class Program {
      /// <summary> Program to swap indices </summary>
      static void Main () => SwapIndices ();

      static void SwapIndices () {
         List<int> list = new () { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         Console.Write ($"Elements: {string.Join (" ", list)}\n" +
                        $"Indices:  {string.Join (" ", list.Select (a => list.IndexOf (a)))} ");
         for (; ; ) {
            Console.WriteLine ("\nEnter 2 indices (from within range) to swap, or [Q] to exit: ");
            string[] input = Console.ReadLine ().Split ();
            if (input.Any (c => c.ToLower () == "q")) Environment.Exit (0);
            if (input.Length == 2 && int.TryParse (input[0], out int i1) && int.TryParse (input[1], out int i2))
               if (i1 >= 0 && i1 < list.Count && i2 >= 0 && i2 < list.Count) { // both inputs are numbers within range
                  SwapIndex (i1, i2);
                  Console.Write ("Elements: ");
                  foreach (var a in list) {
                     if (list[i1] == a || list[i2] == a) PrintGreen (a);
                     else Console.Write ($"{a} ");
                  }
                  Console.Write ($"\nIndices:  ");
                  foreach (var a in list.Select (a => list.IndexOf (a))) {
                     if (i1 == a || i2 == a) PrintGreen (a);
                     else Console.Write ($"{a} ");
                  }
               }
         }

         void SwapIndex (int i1, int i2) => (list[i1], list[i2]) = (list[i2], list[i1]);

         void PrintGreen (object a) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write ($"{a} ");
            Console.ResetColor ();
         }
      }
   }
}
