namespace Training {
   internal class Program {
      static void Main () {
         string nWord = "";
         int place, count;
         bool flag1 = false, flag2 = false;
         Stack<int> numbers;
         Console.WriteLine ("Enter number: ");
         int.TryParse (Console.ReadLine (), out int input);
         // In case of negative integers
         if (input < 0) {
            input = Math.Abs (input);
            nWord = "Minus ";
         } else if (input == 0) nWord = "Zero";
         (numbers, place) = Digits (input);
         count = numbers.Count;
         // Checking if the number ends in 0s or digits ("and" is added based on this)
         switch (count) {
            case 1: flag2 = true; break;
            case 2: flag1 = true; break;
            default:
               foreach (int digits in numbers) {
                  if (!flag1) flag1 = digits == 0 & --count == 1;
                  if (!flag2) flag2 = digits == 0 & count == 2;
               }
               break;
         }
         foreach (int digit in numbers)
            nWord += Words (digit, --place, ref flag1, ref flag2);
         Console.WriteLine ("Words: " + nWord + "\nRoman numerals: " + Roman (input));
      }

      /// <summary>Returns digits of a number in stack</summary>
      /// <param name="input"></param>
      /// <returns>Stack of digits</returns>
      static (Stack<int>, int) Digits (int input) {
         int place = 0;
         Stack<int> numbers = new ();
         while (input >= 1) {
            int digit = input % 10;
            input /= 10;
            numbers.Push (digit);
            place++;
         }
         return (numbers, place);
      }

      /// <summary> Returns value of digit in words </summary>
      /// <param name="digit"></param>
      /// <param name="place"> Place value of digit </param>
      /// <param name="flag1"> Indicates whether place 1 value is 0 </param>
      /// <param name="flag2"> Indicates whether place 2 value is 0 </param>
      /// <returns> Place value of digit passed in words </returns>
      static string Words (int digit, int place, ref bool flag1, ref bool flag2) {
         string[] placeValues = { "", "tens", "hundred", "thousand", "ten-thousand" };
         string[] digitValues = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
         string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
         string str;
         switch (place) {
            case 0:
               str = digit == 0 ? "" : (flag2 | flag1 ? "" : "and ") + digitValues[digit]; break;
            case 1:
               str = $"{(flag1 ? "" : "and ")}{tens[digit]} ";
               flag2 = !flag1; break;
            default:
               str = digit == 0 ? "" : $"{digitValues[digit]} {placeValues[place]} "; break;
         }
         return str;
      }

      /// <summary>Returns roman numeral for number.</summary>
      /// <param name="input">input number</param>
      /// <returns>Returns string containing roman numeral form of input number</returns>
      static string Roman (int input) {
         Dictionary<int, string> romanNumerals = new () { { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" }, { 100, "C"}, { 90, "XC" }, { 50, "L" },
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
