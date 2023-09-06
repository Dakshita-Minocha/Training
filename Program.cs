namespace Training {
   internal class Program {
      /// <summary> Program to display the individual digits of a given number </summary>
      static void Main () => GetDigits ();

      static void GetDigits () {
         for (; ; ) {
            Console.Write ("Enter number, or enter [Q] to exit: ");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            if (double.TryParse (input, out double _)) {
               var strArray = input.Split (".");
               Console.WriteLine ($"Digits of {input}: ");
               for (int i = 0; i < strArray.Length; i++)
                  Console.WriteLine ((i == 0 ? "Integer part: " : "Decimal Part: ") +
                                     string.Join (" ", strArray[i].ToCharArray ()));
            }
         }
      }
   }
}