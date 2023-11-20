// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to test Expression Evaluator.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training;

#region class Program --------------------------------------------------------------------------
class Program {
   #region Method ------------------------------------------------
   static void Main () {
      Evaluator eval = new ();
      string input; double result;
      for (; ; ) {
         Write (">");
         input = ReadLine () ?? "".Trim ().ToLower ();
         if (input == "exit") return;
         try {
            result = eval.Evaluate (input);
            ForegroundColor = ConsoleColor.Green;
            WriteLine (result);
         } catch (EvalException e) {
            ForegroundColor = ConsoleColor.Red;
            WriteLine (e.Message);
         }
         ResetColor ();
      }
   }
   #endregion
}
#endregion