namespace Training {
   internal class Program {
      /// <summary> Program to swap a number </summary>
      static void Main () {
         for (; ; ) {
            Console.WriteLine ("\nEnter 2 numbers (\"a b\") to swap, or [Q] to exit.");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            string[] num = input.Split ();
            if (num.Length < 3) {
               if (int.TryParse (num[0], out int num1) && int.TryParse (num[1], out int num2)) {
                  Console.WriteLine ($"Numbers:\na = {num1}\nb = {num2}");
                  (num1, num2) = Swap (num1, num2);
                  Console.WriteLine ($"Numbers after swapping:\na = {num1}\nb = {num2}");
               }
            }
         }
         static (int, int) Swap (int num1, int num2) => (num2, num1);
      }
   }
}