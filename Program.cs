namespace Training {
   internal class Program {
      static void Main () {
         string nWord = "";
         int place;
         Stack<int> numbers;
         Console.WriteLine ("Enter number: ");
         int.TryParse (Console.ReadLine (), out int input);
         if (input < 0) {
            input = Math.Abs (input);
            nWord = "Minus ";
         } else if (input == 0) nWord = "Zero";
         (numbers, place) = Digits (input);
         bool flag = place > 2;
         foreach (int digit in numbers) nWord += Words (digit, --place, flag);
         Console.WriteLine ("Words: " + nWord + "\nRoman numerals: " + Roman (input));
      }
      /// <summary>Returns digits of a number in stack</summary>
      /// <param name="input"></param>
      /// <returns>Stack of digits</returns>
      static (Stack<int>, int) Digits (int input) {
         int place = 0;
         var numbers = new Stack<int> ();
         while (input >= 1) {
            int digit = input % 10;
            input /= 10;
            numbers.Push (digit);
            place++;
         }
         return (numbers, place);
      }

      /// <summary>Returns value of digit in words</summary>
      /// <param name="digit"></param>
      /// <param name="place">Place value of digit</param>
      /// <returns>Place value of digit passed in words</returns>
      static string Words (int digit, int place, bool flag) {
         string[] placeValues = { "", "tens", "hundred", "thousand", "ten-thousand" };
         string[] digitValues = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
         string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
         return place switch {
            0 => digitValues[digit],
            1 => (flag ? "and " : "") + ((digit == 1) ? "ten " : (tens[digit] + " ")),
            2 => digitValues[digit] + " " + placeValues[place] + " ",
            _ => ""
         };
      }

      /// <summary>Returns roman numeral for number.</summary>
      /// <param name="input">input number</param>
      /// <returns>Returns string containing roman numeral form of input number</returns>
      static string Roman (int input) {
         var romanNumerals = new Dictionary<int, string> () { { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" }, { 100, "C"}, { 90, "XC" }, { 50, "L" },
                                                              { 40, "XL" }, { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" }};
         string roman = "";
         foreach (var key in romanNumerals.Keys)
            while (input >= key) {
               roman += romanNumerals[key];
               input -= key;
            }
         return roman;
      }
   }
}
