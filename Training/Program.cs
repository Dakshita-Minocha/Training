// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement double.TryParse.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training;

#region class Program -----------------------------------------------------------------------------
internal class Program {
   #region Method ---------------------------------------------------
   static void Main () {
      Dictionary<string, double> validCases = new () { { "0", 0 }, { "7", 7 }, { "7.1", 7.1 }, { "08.6", 08.6 }, { "7897", 7897 }, { "00990.009", 00990.009 },
         { "0.003", 0.003 }, { "-7.78", -7.78 }, { "-7.78e1", -77.8 }, {"778e0", 778 }, {"-7e2",-700 }, { "8e-3", 0.008 }, {"4e2.3",798.1049259875515 }, {"+4e2.3", 798.1049259875515 } };
      double num;
      foreach (var kvp in validCases)
         WriteLine ($"{kvp}    {DoubleTryParse.TryParse (kvp.Key, out num)}     {num}");
      List<string> invalidCases = new () { "x", "", "8e9.-3", "8-.7e3", "3.4e4-.3", "3.4e4+.3", "-35.-354e1", "e1", "1e", "1jkse", "1++$6e", "8.", "8ee.", "8e3e9.", "7e.+", "+-34" };
      foreach (var s in invalidCases)
         WriteLine ($"{s}    {DoubleTryParse.TryParse (s, out num)}     {num}");
   }
   #endregion
}
#endregion

#region Class DoubleParse -------------------------------------------------------------------------
public class DoubleTryParse {
   #region Method ---------------------------------------------------
   /// <summary>Converts string to double.</summary>
   /// <param name="input">string input</param>
   /// <param name="num">double number</param>
   /// <returns>If input is a valid number.</returns>
   public static bool TryParse (string input, out double num) {
      // Split number into base (number[0]) and exponent (number[1]).
      // Return false when: Number has more than one 'e' or exponent is invalid.
      // Return true when: base exists and exponent (if exists) are valid.
      num = 0;
      if (input == "") return false;
      string[] number = input.Split ('e');
      if (number.Length > 2) return false;
      if (!Validate (number[0], out bool isNegative)) return false;
      num = Digits (number[0], isNegative);
      if (number.Length != 2) return true;
      if (!Validate (number[1], out isNegative)) {
         num = 0;
         return false;
      }
      double exponent = Digits (number[1], isNegative);
      num *= Math.Pow (10, exponent);
      return true;
   }
   #endregion

   #region Implementation -------------------------------------------
   /// <summary>Returns double of input string. Removes sign from number and splits it into integer
   /// and fractional parts which are converted to double after matching from a dictionary <char, int></summary>
   static double Digits (string input, bool isNegative = false) {
      // Removing sign from string (+/-) if present and dividing input into integer (parts[0]) and fraction (parts[1]).
      string[] parts = (input[0] is '-' or '+' ? input[1..input.Length] : input).Split ('.');
      (double num, int placeValue) = (0, parts[0].Length - 1);
      string number = parts.Length == 1 ? parts[0] : parts[0] + parts[1];
      foreach (char c in number)
         num += (c - '0') * Math.Pow (10, placeValue--);
      return (isNegative ? -1 : 1) * num;
   }

   /// <summary>Returns true if input is a valid number, out variable indicates sign.</summary>
   static bool Validate (string input, out bool negative) {
      // Returns true if:
      // Number is not empty, contains only digits or one +/-/.
      // Number should not end with (./+/-).
      negative = false;
      if (input == "") return false;
      int dotCount = 0;
      foreach (var ch in input)
         if (!char.IsDigit (ch))
            switch (ch) {
               case '.': dotCount++; break;
               case '-' or '+': break;
               default: return false;
            }
      negative = input[0] == '-';
      return dotCount <= 1 && input[^1] is not ('+' or '-' or '.') && !input.Skip (1).Any (x => x is '+' or '-');
   }
   #endregion
}
#endregion