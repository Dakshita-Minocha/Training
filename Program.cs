using System.Runtime;

namespace Training {
   internal class Program {
      /// <summary>Program to generate LCM and HCF of 2 numbers</summary>
      /// <param name="args"></param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter two numbers: ");
         int.TryParse (Console.ReadLine (), out int num1);
         int.TryParse (Console.ReadLine (), out int num2);
         if (num1 > num2) (num1, num2) = (num2, num1);
         Console.Write ($"\nLCM: {LCM (num1, num2)}\n");
         Console.Write ($"HCF: {HCF (num1, num2)}\n");
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