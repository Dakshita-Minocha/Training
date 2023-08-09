namespace Training {
   internal class Program {
   /// <summary>Program to check if a number is prime</summary>
   /// <param name="args"></param>
      static void Main(string[] args) {
      for(; ;){
            Console.Write ("Enter number: ");
            int.TryParse (Console.ReadLine (), out var input);
            Console.WriteLine ($"\n{IsPrime (input)}");
            Console.Write ("\nDo you want to continue (y/n)?\n");
            if (Console.ReadKey(true).Key==ConsoleKey.N) Environment.Exit (0);
         }
      }
      static bool IsPrime(int input){
      for (int i =2; i < input; i++)
            if (input !=2 && input % i == 0) return false;
      return true;
      }
   }
}