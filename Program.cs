using System.Runtime.CompilerServices;

namespace Training {
   internal class Program {
      /// <summary> Program to reverse a number</summary>
      static void Main () {
         string input;
         var reverse = new List<int> ();
         for (; ; ) {
            for (; ; ) {
               Console.Write ("Enter number or press [Q] to exit: ");
               input = Console.ReadLine ();
               if (input.ToLower () == "q") Environment.Exit (0);
               if (input.All (c => Char.IsDigit (c))) break;
            }
            int.TryParse (input, out int num);
            int len = input.Length, rev = 0, i = 0;
            if (num < 0) len--; // to remove '-' from string
            // storing digits in array in reverse order
            while (i < len) {
               reverse.Add (num % 10);
               num /= 10;
               i++;
            }
            // Finding equivalent reversed number
            foreach (var digit in reverse)
               rev += digit * (int)Math.Pow (10, --i);
            Console.Write ($"Reversed number: {rev:D3}\n"
                                            + $"{input} is "
                                            + (input == rev.ToString () ? "" : "NOT ")
                                            + "a palindrome.\n\n");

            reverse.Clear ();
         }
      }
   }
}