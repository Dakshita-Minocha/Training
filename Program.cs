namespace Training {
   internal class Program {
      /// <summary> Program to swap indices </summary>
      static void Main () {
         int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         Console.Write ("Index: Element\n-------------\n");
         foreach (int a in arr) Console.Write ($"  {Array.IndexOf (arr, a),3}: {a,3} \n");
         for (; ; ) {
            Console.WriteLine ("\nEnter indices (from within range) to swap, or [Q] to exit: ");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            else if (input.All (char.IsDigit) & input != "") {
               int.TryParse (input, out int i1);
               if (i1 >= 0 & i1 < arr.Length) {
                  int.TryParse (Console.ReadLine (), out int i2);
                  if (i2 >= 0 & i2 < arr.Length) {
                     Swap (arr, i1, i2);
                     Console.Write ("Swapped indices: \n");
                     foreach (int i in arr) {
                        if (i == arr[i1] | i == arr[i2]) Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write ($"  {Array.IndexOf (arr, i),3}: {i,3} \n");
                        Console.ResetColor ();
                     }
                  }
               }
               Console.WriteLine ();
            }
         }
      }
      static void Swap (int[] arr, int i1, int i2) => (arr[i1], arr[i2]) = (arr[i2], arr[i1]);
   }
}