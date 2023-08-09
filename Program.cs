using System.Reflection.Metadata.Ecma335;

namespace Training {
   internal class Program {
   /// <summary>Program to check is a string is a palindrome</summary>
   /// <param name="args"></param>
      static void Main(string[] args) {
         for(; ; ){
            Console.Write ("Enter string to check for palindrome: ");
            string input = Console.ReadLine ().Replace (" ", "").ToLower();
            Console.Write ($"\n{input} is palindrome? {input == String.Join ("", input.Reverse ())}");
            Console.WriteLine ("\nDo you want to try again (y/n)?");
            if (Console.ReadKey (true).Key == ConsoleKey.N) Environment.Exit (0);
         }
      }
   }
}