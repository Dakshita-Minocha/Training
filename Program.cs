using System.Runtime.CompilerServices;

namespace Training {
   internal class Program {
      /// <summary> Program to reverse a number</summary>
      static void Main (string[] args) {
         for (; ; ) {
            Console.Write ("Enter number or press [Q] to exit: ");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            int.TryParse (input, out int num);
            int len = input.Length, rev = 0, i = 0;
            int[] reverse = new int[len];
            Array.Clear (reverse);
            if (num < 0) len--; // to remove '-' from string
            // storing digits in array in reverse order
            while (i < len) {
               reverse[i] = num % 10;
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
         }
      }
   }
}