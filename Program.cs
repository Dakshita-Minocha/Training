namespace Training {
   internal class Program {
      /// <summary> Program to display the individual digits of a given number </summary>
      static void Main () {
         CallDigits ();
      }
      static void CallDigits () {
         for (; ; ) {
            Console.Write ("Enter number, or enter [Q] to exit: ");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            var strArray = input.Split (".");
            if (double.TryParse (input, out double n)) {
               Console.WriteLine ($"Digits of {input}: ");
               foreach (string item in strArray) {
                  int.TryParse (item, out int num);
                  var listDigits = GetDigits (Math.Abs (num)).ToList ();
                  Console.WriteLine ((Array.IndexOf (strArray, item) == 0 ? "Integer part: " : "Decimal Part: ") +
                                      string.Join (" ", listDigits));
               }
            }
         }
      }
      /// <summary> Adds digits of number to list in reverse order </summary>
      /// <param name="num"> User input </param>
      /// <param name="digits"> List of individual digits </param>
      /// <returns> List of digits </returns>
      static List<int> GetDigits (int num) {
         List<int> digits = new ();
         while (num > 0) {
            digits.Add (num % 10);
            num /= 10;
         }
         digits.Reverse ();
         return digits;
      }
   }
}