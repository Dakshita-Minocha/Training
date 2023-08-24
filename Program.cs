namespace Training {
   internal class Program {
      /// <summary> Program to display Pascal's triangle</summary>
      static void Main (string[] args) {
         for (; ; ) {
            Console.Write ("Enter number of rows or press [Q] to exit: ");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            int.TryParse (input, out int rows);
            if (rows <= 0) Console.WriteLine ("Please enter a positve number.");
            else {
               List<int> row1 = new (); List<int> row2 = new ();
               for (int i = 0; i < rows; i++) {
                  for (int j = 0; j < rows; j++)
                     if (i < j) Console.Write ("   ");
                  switch (i) {
                     case 0: break;
                     case 1: row1.Add (1); break;
                     default:
                        row1.Add (1);
                        int j = 0;
                        while (j < i - 1) {
                           row1.Add (row2[j] + row2[j + 1]);
                           j++;
                        }
                        break;
                  }
                  row1.Add (1); row2.Clear ();
                  foreach (var n in row1) row2.Add (n);
                  foreach (var num in row1) Console.Write ($"{num,5} ");
                  Console.WriteLine ();
                  row1.Clear ();
               }
            }
         }
      }
   }
}