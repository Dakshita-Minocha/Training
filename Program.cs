namespace Training {
   internal class Program {
      /// <summary> Program to check if a word is an isogram </summary>
      static void Main () {
         for (; ; ) {
            Console.Write ("Enter word or press [Q] to exit: ");
            string input = Console.ReadLine (), str;
            if (input.ToLower () == "q") Environment.Exit (0);
            bool flag = true;
            int i = 0, len = input.Length;
            while (i < len) {
               str = input[(i + 1)..len];
               if (str.Any (c => c == input[i])) {
                  flag = false; break;
               }
               i++;
            }
            Console.WriteLine ($"{input} is " + (flag ? "" : "NOT ") + "an Isogram.");
         }
      }
   }
}