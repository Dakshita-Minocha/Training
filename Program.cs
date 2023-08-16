using System.Globalization;

namespace Training {
   internal class Program {
      /// <summary>Program to print a diamond</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.Write ("Enter rows (half the height): ");
         int.TryParse (Console.ReadLine (), out int rows);
         int i, j, count = 1;
         for (i = 0; i < rows; i++) {
            for (j = rows; j > 0; j--)
               if (i < j) Console.Write ("-");
            for (j = count; j > 0; j--)
               Console.Write ("*");
            count += 2;
            Console.WriteLine ();
         }
         count = 1;
         for (i = 1; i <= rows; i++) {
            for (j = 1; j <= count; j++)
               Console.Write (" ");
            count++;
            for (j = 1; j <= 2 * (rows - i) - 1; j++)
               Console.Write ("*");
            Console.WriteLine ();
         }
         Console.WriteLine ();
      }
   }
}
