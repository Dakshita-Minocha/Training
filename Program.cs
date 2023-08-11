using System.Runtime;

namespace Training {
   internal class Program {
      /// <summary>Program to generate LCM and HCF of any n numbers</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter no of parameters: ");
         int.TryParse (Console.ReadLine (), out int count);
         Console.WriteLine ($"Enter {count} numbers: ");
         int num1;
         var num = new List <int>();
         for (int i = 0;i < count; i++) {
            int.TryParse (Console.ReadLine (), out num1);
            num.Add (Math.Abs(num1));
            }
         num.Sort ();
         Console.Write ($"\nLCM: { Calc(num).Item1}\n");
         Console.Write ($"HCF: {Calc (num).Item2}\n");
      }
      static (int, int) Calc(List<int> num){
         int lcm = num[0], hcf =num[num.Count()-1];
         for (int i=1; i<num.Count(); i++) {
           lcm = LCM(num[i], lcm);
           hcf = HCF(num[i], hcf);
         }
         return (lcm, hcf);
      }
      static int LCM (int num1, int num2) {
         for (int i = num2; i < num1 * num2; i++)
            if (i % num1 == 0 && i % num2 == 0)
               return i;
         return num1 * num2;
      }
      static int HCF (int num1, int num2) {
         for (int i = num1; i > 0; i--)
            if (num1 % i == 0 && num2 % i == 0)
               return i;
         return 1;
      }
   }
}