using System.Text;

namespace Training {
   internal class Program {
      /// <summary>Program to display Chess Board using Unicode</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         System.Console.OutputEncoding = new UnicodeEncoding();
         for (int i = 1; i <= 8; i++) {
            PrintLine (i);
            Console.WriteLine ();
            for (int j = 1; j <= 8; j++) {
               if (j != 9) Console.Write ('\u2502');
               DisplayChessItem (i, j);
               Console.Write (" ");
            }
            Console.Write ('\u2502' + "\n");
            if (i != 8) Console.Write ('\u251C');
         }
         PrintLine (9);
      }
      static void PrintLine (int row) {
         if (row == 1) Console.Write ('\u250C');
         if (row == 9) Console.Write ('\u2514');
         for (int i = 1; i <= 8; i++) {
            switch (row) {
               case 1:
                  Console.Write ('\u2500'); Console.Write ('\u2500'); Console.Write ('\u2500');
                  Console.Write (i == 8 ? '\u2510' : '\u252C'); break;
               case 9:
                  Console.Write ('\u2500'); Console.Write ('\u2500'); Console.Write ('\u2500');
                  Console.Write (i == 8 ? '\u2518' : '\u2534'); break;
               default:
                  Console.Write ('\u2500'); Console.Write ('\u2500'); Console.Write ('\u2500');
                  Console.Write (i == 8 ? '\u2524' : '\u253C'); break;
            }
         }
      }

      static void DisplayChessItem (int i, int j) {
         switch (i) {
            case 1:
               if (j is 1 or 8) Console.Write (" " + '\u2656');
               else if (j is 3 or 6) Console.Write (" " + '\u2657');
               else if (j is 2 or 7) Console.Write (" " + '\u2658');
               else if (j == 4) Console.Write (" " + '\u2655');
               else if (j == 5) Console.Write (" " + '\u2654');
               break;
            case 2: Console.Write (" " + '\u2659'); break;
            case 7: Console.Write (" " + '\u265F'); break;
            case 8:
               if (j is 1 or 8) Console.Write (" " + '\u265C');
               else if (j is 3 or 6) Console.Write (" " + '\u265D');
               else if (j is 2 or 7) Console.Write (" " + '\u265E');
               else if (j == 4) Console.Write (" " + '\u265B');
               else if (j == 5) Console.Write (" " + '\u265A');
               break;
            default: Console.Write (" " + " "); break;
         }
      }
   }
}