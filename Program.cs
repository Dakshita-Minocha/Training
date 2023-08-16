namespace Training {
   internal class Program {
      static void Main(string[] args) {
      for(; ;){
            Console.Write ("Enter number: ");
            int.TryParse (Console.ReadLine (), out int number);
            if (number == 0) Console.Write (" 0 * any number is Zero.");
            else{
               for (int i = 1; i <= 10; i++)
                  Console.Write ($"{number} * {i,2} = {number * i} \n");
            }
            Console.Write ("\nPress 'q' to exit, any other key to continue\n");
            if (Console.ReadKey(true).Key == ConsoleKey.Q) Environment.Exit (0);
            Console.WriteLine ();
         }
      }
   }
}