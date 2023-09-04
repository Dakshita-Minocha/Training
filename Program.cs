namespace Training {
   internal class Program {
      /// <summary> Program to display the individual digits of a given number </summary>
      static void Main () {
         List<int> digits = new ();
         for (; ; ) {
            Console.Write ("Enter number, or enter [Q] to exit: ");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            if (input != "" & // not empty
               (char.IsDigit (input[0]) | input[0] == '-') & // Check if input is negative
                input[1..input.Length].All (char.IsDigit)) {
               int.TryParse (input, out int num);
               Digits (Math.Abs (num), digits);
               Console.Write ($"Digits of {num}: ");
               digits.Reverse ();
               foreach (int digit in digits)
                  Console.Write ($"{digit} ");
            }
            digits.Clear ();
            Console.WriteLine ();
         }
      }
      /// <summary> Adds digits of number to list in reverse order </summary>
      /// <param name="num"> User input </param>
      /// <param name="digits"> List of individual digits </param>
      static void Digits (int num, List<int> digits) {
         while (num > 0) {
            digits.Add (num % 10);
            num /= 10;
         }
      }
   }
}