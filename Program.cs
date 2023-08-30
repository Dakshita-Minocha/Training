namespace Training {
   internal class Program {
      /// <summary> Program to calculate factorial of a number </summary>
      static void Main () {
         string input;
         for (; ; ) {
            Console.Write ("Enter number [n<32] or press [Q] to exit: ");
            input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            if (input.All (c => Char.IsDigit (c))) {
               int.TryParse (input, out int num);
               Console.WriteLine ($"Factorial of {num} = " + (num > 0 & num < 32 ? $"{Factorial (num)}" : "0"));
            }
         }
         static int Factorial (int num) => num == 1 ? 1 : num * Factorial (num - 1);
      }
   }
}