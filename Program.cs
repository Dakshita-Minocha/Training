using System.Text;

namespace Training {
   internal class Program {
      static void Main (string[] args) {
         string nWord = "";
         int place = 0;
         List<int> numbers = new List<int> ();
         Console.WriteLine ("Enter number: ");
         int.TryParse (Console.ReadLine (), out int input);
         if (input < 0) {
            input = Math.Abs (input);
            nWord = "Minus ";
         } else if (input == 0) nWord = "Zero";
         while (input >= 1) {
            int digit = input % 10;
            input /= 10;
            numbers.Add (digit);
            place++;
         }
         numbers.Reverse ();
         foreach (int digit in numbers) nWord += Words (digit, --place);
         foreach (var word in nWord) Console.Write (word);
      }
      static string Words (int digit, int place) {
         string nWord = "";
         string[] placeValues = { "", "tens", "hundred", "thousand", "ten-thousand" };
         string[] digitValues = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
         string[] tens = { "", "", "twenty", "thrity", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
         if (digit == 0) return nWord += "";
         if (place == 1) return (digit == 1) ? "ten " : ("and " + tens[digit] + " ");
         else return digitValues[digit] + " " + placeValues[place] + " ";
      }
   }
}