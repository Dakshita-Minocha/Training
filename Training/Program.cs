// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement double.Parse.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training;

#region class Program -----------------------------------------------------------------------------
internal class Program {
   #region Method ---------------------------------------------------
   static void Main (string[] args) {
      Write ("input:");
      string input = ReadLine ().Trim ().ToLower () ?? "";
      bool isValid = DoubleParse.Parse (input, out double num);
      WriteLine ("output: " + num + $"\n{(isValid ? "" : "invalid input")}");
   }
   #endregion
}
#endregion

#region Class DoubleParse -------------------------------------------------------------------------
public class DoubleParse {
   #region Method ---------------------------------------------------
   /// <summary>Converts string to double.</summary>
   /// <param name="input">string input</param>
   /// <param name="num">double number</param>
   /// <returns>If False is input number is invalid, true otherwise.</returns>
   public static bool Parse (string input, out double num) {
      num = 0;
      if (input != "") {
         string[] number = input.Split ('e');
         if (number.Length > 2) return false;
         if (Validate (number[0] ?? "", out bool isNegative)) {
            num = Digits (number[0], isNegative);
            if (number.Length == 2)
               if (Validate (number[1], out isNegative)) {
                  double exponent = Digits (number[1], isNegative);
                  num *= Math.Pow (10, exponent);
               } else {
                  num = 0;
                  return false;
               }
            return true;
         }
      }
      return false;
   }
   #endregion

   #region Implementation -------------------------------------------
   /// <summary>Returns double of input string. Removes sign from number and splits it into integer
   /// and fractional parts which are converted to double after matching from a dictionary <char, int></summary>
   static double Digits (string input, bool isNegative = false) {
      Dictionary<char, int> numbers = new () { { '0', 0 }, { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4},
                                               { '5', 5 }, { '6', 6 }, {'7', 7 }, {'8', 8 }, {'9', 9 } };
      string[] parts = (input[0] is '-' or '+' ? input[1..input.Length] : input).Split ('.');
      (double num, int intLength) = (0, parts[0].Length - 1);
      foreach (char c in parts.Length == 1 ? parts[0] : parts[0] + parts[1])
         num += numbers[c] * Math.Pow (10, intLength--);
      return (isNegative ? -1 : 1) * num;
   }

   /// <summary>Returns true if input is a valid number, out variable indicates sign.</summary>
   static bool Validate (string input, out bool negative) {
      int dotCount = 0; negative = false;
      if (input == "") return false;
      foreach (var ch in input)
         if (!char.IsDigit (ch))
            switch (ch) {
               case '.': dotCount++; break;
               case '-' or '+': break;
               default: return false;
            }
      negative = input[0] == '-';
      return dotCount <= 1 && input[^1] != '.' && !input[1..input.Length].Any (x => x is '+' or '-');
   }
   #endregion
}
#endregion