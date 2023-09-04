namespace Training {
   internal class Program {
      /// <summary> Program to swap a number </summary>
      static void Main () {
         int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
         foreach (int e in arr) Console.Write ($"{e} ");
         for (; ; ) {
            Console.WriteLine ("\nEnter 2 numbers from given numbers to swap or [Q] to exit.");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            int.TryParse (input, out int num1);
            input = Console.ReadLine ();
            int.TryParse (input, out int num2);
            if (arr.Contains (num1) & arr.Contains (num2)) {
               Swap (arr, Array.IndexOf (arr, num1), Array.IndexOf (arr, num2));
               Console.WriteLine ("Numbers after swapping: ");
               foreach (int e in arr) {
                  if (e == num1 | e == num2) Console.ForegroundColor = ConsoleColor.Yellow;
                  Console.Write ($"{e} ");
                  Console.ResetColor ();
               }
            }
            Console.WriteLine ();
         }
      }
      static void Swap (int[] arr, int i1, int i2) => (arr[i1], arr[i2]) = (arr[i2], arr[i1]);
   }
}