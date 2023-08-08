namespace Training {
   internal class Program {
      static void Main(string[] args) {
         Console.Write("Enter no of terms to be displayed");
         int.TryParse (Console.ReadLine(), out int input);
         int item1 = 0, item2 = 1;
         Console.Write(item1 + " " + item2 + " ");
         for (int i = 2; i < input; i++) {
            int sum = item1 + item2;
            item1 = item2;
            item2 = sum;
            Console.Write (sum + " ");
         }
      }
   }
}