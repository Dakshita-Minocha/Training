namespace Training {
   internal class Program {
      /// <summary>Program to check is a string is a palindrome</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         for (; ; ) {
            string str = "";
            Console.Write ("Enter word or phrase, press [Q] to exit: ");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            foreach (var ch in input.Where (ch => Char.IsLetter (ch)))
               str += Char.ToLower (ch);
            Console.Write ($"\n\n\"{input}\" is " + (str == String.Join ("", str.Reverse ()) ? "" : "NOT ") + "a palindrome.\n");
         }
      }
   }
}