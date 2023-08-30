namespace Training {
   internal class Program {
      /// <summary> Program to check if a number is an Armstrong number </summary>
      static void Main () {
         string input;
         int n;
         for (; ; ) {
            Console.WriteLine ("Choose from menu or press [Q] to exit: \n" +
                               "[1]Check if number is Armstrong\n" +
                               "[2]Find nth Armstrong number [n<=25]");
            var ch = Console.ReadKey (true).Key;
            switch (ch) {
               case ConsoleKey.D1:
                  for (; ; ) {
                     Console.Write ("Enter number: ");
                     input = Console.ReadLine ();
                     if (input.All (c => Char.IsAsciiDigit (c))) break;
                  }
                  int.TryParse (input, out int num);
                  Console.WriteLine ($"{num} is " + (Armstrong (num) ? "" : "NOT ") + "an Armstrong number.\n"); break;
               case ConsoleKey.D2:
                  for (; ; ) {
                     Console.WriteLine ("Enter nth number: ");
                     input = Console.ReadLine ();
                     int.TryParse (input, out n);
                     if (n != 0 & n <= 25) break;
                  }
                  Console.WriteLine ($"{n}th Armstrong number = {nArmstrong (n)}\n"); break;
               case ConsoleKey.Q: Environment.Exit (0); break;
            }
         }
      }
      static int nArmstrong (int n) {
         int count = 1, num = 1;
         while (count < n) {
            if (Armstrong (num)) count++;
            num++;
         }
         return num;
      }
      static bool Armstrong (int num) {
         double sum = 0;
         var Arms = new List<int> ();
         var (digits, count) = Digits (num);
         foreach (var digit in digits)
            sum += Math.Pow (digit, count);
         if (sum == num) Arms.Add (num);
         return sum == num;
      }
      static (List<int>, int) Digits (int num) {
         var digits = new List<int> ();
         int count = 0;
         while (num > 0) {
            digits.Add (num % 10);
            num /= 10;
            count++;
         }
         return (digits, count);
      }
   }
}