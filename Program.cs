namespace Training {
   internal class Program {
      /// <summary> Program to swap indices </summary>
      static void Main () => SwapIndices ();

      static void SwapIndices () {
         List<int> arr = new () { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         Console.Write ($"Elements: {string.Join (" ", arr)}\n" +
                        $"Indices:  {string.Join (" ", arr.Select (a => arr.IndexOf (a)))} ");
         for (; ; ) {
            Console.WriteLine ("\nEnter 2 indices (from within range) to swap, or [Q] to exit: ");
            string[] input = Console.ReadLine ().Split ();
            if (input.Any (c => c.ToLower () == "q")) Environment.Exit (0);
            if (input.Length == 2 && int.TryParse (input[0], out int i1) && int.TryParse (input[1], out int i2))
               if (i1 >= 0 && i1 < arr.Count && i2 >= 0 && i2 < arr.Count) { // both inputs are numbers within range
                  Swap (i1, i2);
                  Console.Write ($"Elements: {string.Join (" ", arr)}\nIndices:  ");
                  foreach (var a in string.Join ("", arr.Select (a => arr.IndexOf (a)))) {
                     if (input.Any (x => x == a.ToString ())) PrintGreen (a);
                     else Console.Write ($"{a} ");
                  }
               }
         }
         void Swap (int i1, int i2) => (arr[i1], arr[i2]) = (arr[i2], arr[i1]);
         void PrintGreen (char a) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write ($"{a} ");
            Console.ResetColor ();
         }
      }
   }
}
