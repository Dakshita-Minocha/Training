using System.Text;

namespace Training {
   internal class Program {
      /// <summary>Program to display Chess Board using Unicode</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         System.Console.OutputEncoding = new UnicodeEncoding();
         int c = 1;
         for (int i = 1; i <= 8; i++) {
            PrintLine (i, c); Console.WriteLine (); c++;
            for (int j = 1; j <= 8; j++) {
               if (j != 9) Console.Write ('\u2502');
               DisplayChessItem (i, j);
            }
            Console.Write ('\u2502');
            Console.WriteLine ();
            if (c != 9) Console.Write ('\u251C');
         }
         PrintLine (9, 8);
         Console.WriteLine ();
      }
      static void PrintLine (int row, int column) {
         if (row == 1) Console.Write ('\u250C');
         if (row == 9) Console.Write ('\u2514');
         for (int i = 1; i <= 8; i++) {
            if (row == 1) {
               Console.Write ('\u2500'); Console.Write ('\u2500');
               if (i == 8) Console.Write ('\u2510');
               else Console.Write ('\u252C');
            } else if (row == 9) {
               Console.Write ('\u2500'); Console.Write ('\u2500');
               if (i == 8) Console.Write ('\u2518');
               else Console.Write ('\u2534');
            } else if (i == 8) {
               Console.Write ('\u2500'); Console.Write ('\u2500'); Console.Write ('\u2524');
            } else if (row != 9) {
               if (column == 1) {
                  Console.Write ('\u251C');
               } else Console.Write ('\u2500'); Console.Write ('\u2500'); Console.Write ('\u253C');
            }
         }
      }

      static void DisplayChessItem (int i, int j) {
         // pawns
         if (i == 2) Console.Write (" " + '\u2659');
         else if (i == 7) Console.Write (" " + '\u265F');
         // rooks
         else if (i == 1 && j is 1 or 8)  Console.Write (" " + '\u2656'); 
         else if (i == 8 && j is 1 or 8) Console.Write (" " + '\u265C');
         // bishop 
         else if (i == 1 && j is 3 or 6) Console.Write (" " + '\u2657');
         else if (i == 8 && j is 3 or 6) Console.Write (" " + '\u265D');
         // knight 
         else if (i == 1 && j is 2 or 7) Console.Write (" " + '\u2658');
         else if (i == 8 && j is 2 or 7) Console.Write (" " + '\u265E');
         // queens
         else if (i == 1 && j == 4) Console.Write (" " + '\u2655');
         else if (i == 8 && j == 4) Console.Write (" " + '\u265B');
         // kings
         else if (i == 1 && j == 5) Console.Write (" " + '\u2654');
         else if (i == 8 && j == 5) Console.Write (" " + '\u265A');
         else Console.Write (" " + " ");
      }
   }
}