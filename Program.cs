using System.Linq.Expressions;

namespace Training {
   internal class Program {
      static void Main (string[] args) {
         for (; ; ) {
            Console.Write ("Enter number or press [Q] to exit: ");
            string input = Console.ReadLine ();
            if (int.TryParse (input, out int number))
               Console.WriteLine ($"Input: {number}\nHEX: {number:X} \nBinary: {Convert.ToString (number, 8)}");
            if (input.ToLower() == "q") Environment.Exit (0);
         }
      }
   }
}