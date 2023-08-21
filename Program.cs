namespace Training {
   internal class Program {
      static void Main (string[] args) {
         for (; ; ) {
            Console.Write ("Enter number, press [Q] to exit: ");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            int.TryParse (input, out int number);
            if (number == 0) Console.Write (" 0 * any number is Zero.");
            else {
               for (int i = 1; i <= 10; i++)
                  Console.Write ($"{number} * {i,2} = {number * i} \n");
            }
         }
      }
   }
}