namespace Training {
   internal class Program {
      /// <summary> Program to display all permutations of a string </summary>
      static void Main () {
         int k = 0, l = k + 1;
         var perm = new List<string> ();
         string input;
         for (; ; ) {
            for (; ; ) {
               Console.Write ("Enter word, or enter [Q] to exit: ");
               input = Console.ReadLine ().ToLower ();
               if (input == "q") Environment.Exit (0);
               if (input.Length > 1 && input.All (c => Char.IsAsciiLetter (c))) break;
            }
            perm.Clear ();
            perm = Permutations (input.ToList (), perm, k, l);
            Console.WriteLine ($"Distinct permutations of the letters in {input.ToUpper ()}:\n");
            foreach (var str in perm)
               Console.WriteLine ($"{str}");
            Console.WriteLine ("\n");
         }
      }

      /// <summary> Return all permutations of a word in a list: adds word to list, swaps letters in input then adds letters 
      /// till max permutations have been reached. </summary>
      /// <param name="input"> Input char list </param>
      /// <param name="perm"> List of possible permutations </param>
      /// <param name="k"> Index for swapping </param>
      /// <param name="l"> Index for swapping </param>
      /// <returns> List of all distinct permutations </returns>
      static List<string> Permutations (List<char> input, List<string> perm, int k, int l) {
         int len = input.Count;
         string str = string.Join ("", input);
         perm.Add (str);
         (input[l], input[k]) = (input[k++], input[l++]);
         if (l == len) l = 0;
         if (k == len) k = 0;
         if (perm.Count < NumofPermutations (len)) Permutations (input, perm, k, l);
         return perm.Distinct ().ToList ();
      }

      /// <summary> Returns number of possible permutations as N! where: N = length of input string </summary>
      static int NumofPermutations (int len) => len == 1 ? 1 : len * NumofPermutations (len - 1);
   }
}
