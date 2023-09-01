namespace Training {
   internal class Program {
      /// <summary> Program to check if a number is an Armstrong number </summary>
      static void Main (string[] args) {
         string input;
         if (args.Length == 0) {
            Console.Write ("Enter number: ");
            input = Console.ReadLine ();
            if (input.All (c => Char.IsAsciiDigit (c))) {
               int.TryParse (input, out int num);
               Console.WriteLine ($"{num} is " + (Armstrong (num) ? "" : "NOT ") + "an Armstrong number.");
            }
         } else {
            input = args[0];
            int.TryParse (input, out int n);
            if (n != 0 & n <= 25) Console.WriteLine ($"{n}th Armstrong number = {nArmstrong (n)}");
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