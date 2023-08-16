using System.Text;

namespace Training {
   internal class Program {
      /// <summary>Program to display Chess Board using Unicode.
      /// The program first prints the grid line (using Printline()), then the line with chess characters as: "| <char> ".
      /// At the end of the character line it adds another " | " to close grid and print the next grid line.
      /// It prints the last grid line separately as PrintLine(9) to close grid.</summary>
      static void Main (string[] args) {
         System.Console.OutputEncoding = new UnicodeEncoding ();
         for (int i = 1; i <= 8; i++) {
            PrintLine (i);
            for (int j = 1; j <= 8; j++) 
                  Console.Write ('\u2502' + $" {ChessItem (i, j)} ");
            Console.Write ('\u2502' + "\n");
         }
         PrintLine (9);
      }
<<<<<<< Updated upstream

      /// <summary>Prints 8x8 Grid line by line between character lines</summary>
      static void PrintLine (int row) {
         if (row == 1) Console.Write ('\u250C');
         else if (row == 9) Console.Write ('\u2514');
         else Console.Write ('\u251C');
         for (int i = 1; i <= 8; i++) {
            Console.Write(new string ('\u2500', 3));
            switch (row) {
               case 1: Console.Write (i == 8 ? '\u2510' : '\u252C'); break;
               case 9: Console.Write (i == 8 ? '\u2518' : '\u2534'); break;
               default: Console.Write (i == 8 ? '\u2524' : '\u253C'); break;
            }
         }
         Console.WriteLine ();
      }

      /// <summary>Returns value of character to be printed based on position in 8x8 grid</summary>
      /// <param name="i">row</param>
      /// <param name="j">column</param>
      static char ChessItem (int i, int j) {
         switch (i) {
            case 1:  // white pieces
               if (j is 1 or 8) return '\u2656';
               else if (j is 3 or 6) return '\u2657';
               else if (j is 2 or 7) return '\u2658';
               return j == 4 ? '\u2655' : '\u2654';
            case 2: return '\u2659'; // white pawns
            case 7: return '\u265F'; // black pawns
            case 8: // black pieces
               if (j is 1 or 8) return '\u265C';
               else if (j is 3 or 6) return '\u265D';
               else if (j is 2 or 7) return '\u265E';
               return j == 4 ? '\u265B' : '\u265A';
         }
         return ' ';
||||||| Stash base
      static bool IsPrime(int input){
      for (int i =2; i < input; i++)
            if (input !=2 && input % i == 0) return false;
      return true;
=======
      static bool IsPrime(int input){
         for (int i = 2; i < input; i++)
            return input == 2 || input % i != 0;
            //return false;
      //return true;
>>>>>>> Stashed changes
      }
   }
}