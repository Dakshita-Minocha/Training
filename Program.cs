using System.Globalization;

namespace Training {
   internal class Program {
      /// <summary>Program to print a diamond</summary>
      static void Main (string[] args) {
         for (; ; )
            {
            Console.Write ("Enter rows (half the height), press [q] to exit: ");
            string row = Console.ReadLine ();
            if (row.ToLower () == "q") Environment.Exit (0);
            int.TryParse (row, out int rows);
            // Printing upper half of diamond: j ' ' followed by scount '*'.
            int i, j, scount = 1;
            for (i = 0; i <= rows; i++, scount += 2) {
               for (j = 0; j <= rows; j++)
                  Console.Write (i < j ? " " : "");
               Console.Write (new string ('*', scount) + '\n');
            }
            // Printing lower half of diamond: i ' ' followed by scount '*'.
            for (i = 1, scount = rows * 2 - 1; i <= rows; i++, scount -= 2)
               Console.Write (new string (' ', i) + new string ('*', scount) + '\n');
         }
      }
   }
}
