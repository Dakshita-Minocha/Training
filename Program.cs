namespace Training {
   internal class Program {
      /// <summary>Program to generate LCM and HCF of any n numbers</summary>
      static void Main () {
         string input;
         for (; ; ) {
            Console.WriteLine ("How many numbers would you like to enter? Enter [Q] to exit: ");
            input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            int.TryParse (input, out int count);
            if (count > 0) {
               Console.WriteLine ($"Enter {count} numbers: ");
               var num = new List<int> ();
               for (int i = 0; i < count; i++) {
                  int.TryParse (Console.ReadLine (), out int num1);
                  num.Add (Math.Abs (num1));
               }
               num.Sort ();
               Console.Write ($"\nLCM: {Calc (num).lcm}\n");
               Console.Write ($"HCF: {Calc (num).hcf}\n");
            }
         }
      }
      /// <summary> Passes n numbers to LCM () and HCF () functions and returns lcm and hcf values. 
      ///           Sets lcm = hcf = 0 if any of entered values = 0. </summary>
      /// <param name="num">list of 'n' numbers</param>
      /// <returns>(lcm, hcf)</returns>
      static (int lcm, int hcf) Calc (List<int> num) {
         int lcm = num[0], hcf = num[0];
         if (num.Any (d => d == 0)) return (0, 0);
         for (int i = 1; i < num.Count; i++) {
            lcm = LCM (lcm, num[i]);
            hcf = HCF (num[i], hcf);
         }
         return (lcm, hcf);
      }
      static int HCF (int num1, int num2) => (num1 * num2) / LCM (num1, num2);
      static int LCM (int num1, int num2) {
         for (int i = num2; i < num1 * num2; i++)
            if (i % num1 == 0 && i % num2 == 0)
               return i;
         return num1 * num2;
      }
   }
}