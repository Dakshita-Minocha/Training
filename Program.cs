namespace Training {
   internal class Program {
      static void Main (string[] args) {
         Console.Write ("Multiplication tables from 1-10:\n\n");
         for (int number = 1; number <= 10; number += 2) {
            for (int i = 1; i <= 10; i++)
               Console.Write ($"{number} * {i,2} = {number * i} \t {number + 1} * {i,2} = {(number + 1) * i} \n");
            Console.WriteLine ();
         }
      }
   }
}
