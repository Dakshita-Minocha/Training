namespace Training {
   internal class Program {
      static void Main (string[] args) {
         Console.Write ("Enter no of terms to be displayed: ");
         int.TryParse (Console.ReadLine (), out int input);
         int num1 = 0, num2 = 1;
         Console.Write (num1 + " " + num2 + " ");
         for (int i = 2; i < input; i++) {
            int sum = num1 + num2;
            num1 = num2;
            num2 = sum;
            Console.Write (sum + " ");
         }
      }
   }
}