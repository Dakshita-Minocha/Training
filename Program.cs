// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to print the sorted array by keeping the elements matching S to the last of the array.
// Given a character array A, along with special character S and sort order O (default order is Ascending).
// ---------------------------------------------------------------------------------------
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Console;
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main (string[] args) => Display ();

      /// <summary> Gets user input as unsorted string in given pattern, converts input to 
      /// character array and passes to Sort() function, then displays sorted result. </summary>
      static void Display () {
         string input, specialchar;
         WriteLine ("Enter Characters in [] brackets along with sorting order as shown in example below:\n" +
                    "Sample Input:\n([a, b, c, a, c, b, d], a, \"descending\")\n([z, y, x], a) -- Ascending order: default\n" +
                    "Enter \"exit\" to exit\n");
         for (; ; ) {
            bool orderdesc = false;
            Write ("Enter String: ");
            input = ReadLine ().Trim ().ToLower ();
            if (input == "" || input == null) continue;
            if (input == "exit") return;
            if (input.Contains ('[') && input.Contains (']') && input.Any (x => !char.IsLetter (x) || !char.IsSymbol (x))) {
               if (input.Contains ("\"descending\"")) orderdesc = true;
               char[] charArray = input[(input.IndexOf ('[') + 1)..input.IndexOf (']')]
                                       .Where (x => char.IsLetter (x)).Select (x => x).ToArray ();
               specialchar = string.Join (", ", input.Where (x => char.IsSymbol (x)).Select (x => x));
               Sort (charArray, orderdesc, out string sorted);
               WriteLine ($"Sorted string: \"{sorted}\"{(specialchar.Length > 0 ? ", " : "")}{specialchar}");
            }
         }
      }

      /// <summary> Returns sorted string from input character array. </summary>
      /// <param name="charArray"> Input array of characters </param>
      /// <param name="order"> Default: ascending </param>
      static string Sort (char[] charArray, bool orderdesc, out string sorted) =>
                         sorted = string.Join (", ", orderdesc ? charArray.OrderByDescending (x => x) : charArray.Order ());
      #endregion
   }
   #endregion
}