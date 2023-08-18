namespace Training {
   internal class Program {
   /// <summary>Program to check if a number is prime</summary>
      static void Main(string[] args) {
      for(; ;){
            Console.Write ("Enter number, press [Q] to exit: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "q") Environment.Exit(0);
            int.TryParse (input, out int num);
            Console.WriteLine (IsPrime(num) ? $"{num} is prime" : $"{num} is NOT prime");
         }
      }
      static bool IsPrime(int input){
      for (int i =2; i <= Math.Sqrt(input); i++)
            if (input !=2 && input % i == 0) return false;
      return true;
      }
   }
}