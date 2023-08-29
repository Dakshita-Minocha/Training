namespace Training {
   internal class Program {
      /// <summary> Program to check if a number is prime </summary>
      static void Main (string[] args) {
         string input;
         for (; ; ) {
            for (; ; ) {
               Console.Write ("Enter number, press [Q] to exit: ");
               input = Console.ReadLine ();
               if (input.ToLower () == "q") Environment.Exit (0);
               if (input.All (c => Char.IsDigit (c))) break;
            }
            int.TryParse (input, out int num);
            if (num == 0) Console.WriteLine ("0 is NOT prime");
            else Console.WriteLine ($"\"{num}\" is " + (IsPrime (num) ? "" : "NOT ") + "prime\n");
         }
      }
      static bool IsPrime (int input) {
         for (int i = 2; i <= Math.Sqrt (input); i++)
            if (input != 2 && input % i == 0) return false;
         return true;
      }
   }
}