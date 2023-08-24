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
            for (int j = 1; j <= 8; j++) {
               if (i == 7) Console.Write ('│' + $" {ChessItem (i, j)}");  //The font I'm using displays extra space after black pawn.
               else Console.Write ('│' + $" {ChessItem (i, j)} ");
            }
            Console.Write ('│' + "\n");
         }
         PrintLine (9);
      }

      /// <summary>Prints 8x8 Grid line by line between character lines</summary>
      static void PrintLine (int row) {
         if (row == 1) Console.Write ('┌');
         else if (row == 9) Console.Write ('└');
         else Console.Write ('├');
         for (int i = 1; i <= 8; i++) {
            Console.Write (new string ('─', 3));
            switch (row) {
               case 1: Console.Write (i == 8 ? '┐' : '┬'); break;
               case 9: Console.Write (i == 8 ? '┘' : '┴'); break;
               default: Console.Write (i == 8 ? '┤' : '┼'); break;
            }
         }
         Console.WriteLine ();
      }

      /// <summary>Returns value of character to be printed based on position in 8x8 grid</summary>
      /// <param name="i">row</param>
      /// <param name="j">column</param>
      static char ChessItem (int i, int j) {
         var whitepieces = new char[8] { '♖', '♘', '♗', '♕', '♔', '♗', '♘', '♖' };
         var blackpieces = new char[8] { '♜', '♞', '♝', '♛', '♚', '♝', '♞', '♜' };
         switch (i) {
            case 1: return whitepieces[--j];
            case 2: return '♙';
            case 7: return '♟';
            case 8: return blackpieces[--j];
         }
         return ' ';
      }
   }
}