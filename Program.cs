namespace Training {
   internal class Program {
      /// <summary> Program to find digital root of a number. 
      /// Digital root = sum of digits calculated iteratively till there's a single digit left.</summary>
      static void Main () {
         string input;
         for (; ; ) {
            for (; ; ) {
               Console.Write ("Enter number or press [Q] to exit: ");
               input = Console.ReadLine ();
               if (input.ToLower () == "q") Environment.Exit (0);
               if (input.All (c => Char.IsDigit (c))) break;
            }
            int.TryParse (input, out int num);
            int i = input.Length, sum;
            if (num == 0)
               Console.WriteLine ("\nError: Digital root is only defined for natural numbers. Try again.\n");
            else {
               while (num > 9) {
                  sum = 0;
                  while (i >= 1) {
                     sum += num % 10;
                     num /= 10;
                     i--;
                  }
                  num = sum;
                  i = num.ToString ().Length;
               }
               Console.Write ($"Digital root of {input} = {num}\n\n");
            }
         }
      }
   }
}