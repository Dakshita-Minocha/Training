namespace Training {
   internal class Program {
      /// <summary> Program to reduce a string of lowercase characters by deleting a pair of adjacent letters that match. </summary>
      static void Main () {
         for (; ; ) {
            Console.WriteLine ("Enter String or press [Q] to exit: ");
            string input = Console.ReadLine ().ToLower ();
            if (input == "q") Environment.Exit (0);
            if (input.All (c => Char.IsLetter (c))) {
               int i = 0;
               while (i < input.Length - 1) {
                  if (input[i] == input[i + 1]) input = input.Remove (i, 2);
                  else i++;
               }
               Console.WriteLine ($"Reduced string: {input}");
            }
         }
      }
   }
}