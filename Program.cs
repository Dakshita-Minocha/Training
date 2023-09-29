namespace Training {
   internal class Program {
      static void Main () => ConvertTo ();

      /// <summary> Converts input number to its verbal and roman representation and displays result. </summary>
      static void ConvertTo () {
         string nWord = "", input;
         int place, count;
         Stack<int> numbers;
         for (; ; ) {
            Console.WriteLine ("Enter number: ");
            input = Console.ReadLine ();
            if (input.ToLower () == "q") return;
            if (int.TryParse (input, out int num)) {
               // In case of negative integers
               if (num < 0) {
                  num = Math.Abs (num);
                  nWord = "Minus ";
               } else if (num == 0) nWord = "Zero";
               (numbers, place) = Digits (num);
               count = numbers.Count;
               // Checking if the number ends in 0s or digit ("and" is added based on this)
               bool[] zeroAt = new bool[count + 1];
               foreach (int digit in numbers)
                  zeroAt[--count] = digit == 0;
               foreach (int digit in numbers)
                  nWord += Words (digit, --place, zeroAt);
               Console.WriteLine ("Words: " + nWord + "\nRoman numerals: " + Roman (num));
               nWord = "";
            }
         }
      }

      /// <summary> Returns digit of a number in stack </summary>
      /// <param name="input"></param>
      /// <returns> Stack of digit </returns>
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
      /// <param name="zeroAt"> Indicates which placevalue is zero: zeroAt[placeValue] </param>
      /// <returns> Place value of digit passed in words </returns>
      static string Words (int digit, int place, bool[] zeroAt) {
         string empty = string.Empty;
         string[] placeValues = { empty, "tens ", "hundred ", "thousand ", "ten-thousand " };
         string[] digitValues = { empty, "one ", "two ", "three ", "four ", "five ", "six ", "seven ", "eight ", "nine " };
         string[] tens = { empty, "ten ", "twenty ", "thirty ", "forty ", "fifty ", "sixty ", "seventy ", "eighty ", "ninety " };
         return place switch {                                                                                 // adds "and" if: 
            0 => (zeroAt[place] ? empty : (zeroAt[place + 1] ? "and " : empty)) + digitValues[digit],          // if 1s digit is not 0 but 10s digit is 0 (109, 405, 1908 etc)
            1 => $"{(zeroAt.Length > 3 && ((zeroAt[place - 1] ||                                               // if 10s place is not 0 (89)
                  zeroAt[place + 1]) && !zeroAt[place] ||                                                      // if 10s place != 0 but 100s place = 0 (8090, 8076 etc)
                  zeroAt.All (x => x == false)) ? "and " : empty)}{tens[digit]}",                              // if distinct digits (6789, 65 etc)
            _ => zeroAt[place] ? empty : $"{(place != 2 && zeroAt[place - 1] ? empty :                         // if second digit is 0 (0, 8098, 708)
                                         (place != 2 && zeroAt[0..place].All (x => x == true) ? empty :        // all except first digit zero (7000)
                                         (place == 2 && zeroAt[0..place].All (x => x == true) && zeroAt.Length > 4 ? "and " :     // Trailing zeros (7800)
                                         empty)))}{digitValues[digit]}{placeValues[place]}"                    // otherwise no "and " is placed
         };
      }

      /// <summary> Returns roman numeral for number. </summary>
      /// <param name="input"> num number </param>
      /// <returns> Returns string containing roman numeral form of num number </returns>
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
