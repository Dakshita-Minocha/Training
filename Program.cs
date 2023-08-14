using System.Text.RegularExpressions;
namespace Training {
   internal class Program {
      /// <summary>Program to check is a string is a palindrome</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         for (; ; ) {
            Console.Write ("Enter string to check for palindrome: ");
            string input = Console.ReadLine ();
            string str = Regex.Replace (input, @"[^a-zA-Z]+", "").ToLower ();
            Console.Write (str == String.Join ("", str.Reverse ()) ? $"\n\"{input}\" is a palindrome\n" : $"\n\"{input}\" is not a palindrome\n");
            for (; ; ) {
               Console.WriteLine ("\nDo you want to try again (y/n)?");
               var key = Console.ReadKey (true).Key;
               if (key == ConsoleKey.N) Environment.Exit (0);
               else if (key == ConsoleKey.Y) break;
               else Console.WriteLine ("Enter [y] or [n].");
            }
         }
      }
   }
}