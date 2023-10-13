// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to print the sorted array by keeping the elements matching S to the last of the array.
// Given a character array A, along with special character S and sort order O (default order is Ascending).
// ---------------------------------------------------------------------------------------
using static System.Console;
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main (string[] args) => Display ();

      /// <summary> Gets user input as unsorted string and special character, converts input to 
      /// character array and passes to Sort() function, then displays sorted result with special 
      /// characters appended at the end. </summary>
      static void Display () {
         WriteLine ("Enter Characters in [] brackets followed by special character and sorting " +
                    "order as shown in example below:\n" + "Sample Input:\n([a, b, c, a, c, b, d], a, \"descending\")" +
                    "\n([z, y, x], a) -- Ascending order: default\n" + "Enter \"exit\" to exit\n");
         for (; ; ) {
            char specialchar;
            Write ("Enter String: ");
            string input = ReadLine ().Trim ().ToLower () ?? "";
            if (input == "") continue;
            if (input.ToLower () == "exit") break;
            Write ("Enter special character: ");
            specialchar = ReadLine ().FirstOrDefault ();
            string spc = string.Join (", ", input.Where (x => x == specialchar).Select (x => x));
            char[] sort = input.Where (x => char.IsLetter (x) && x != specialchar).Select (x => x).ToArray ();
            Write ("Enter sorting order: ");
            WriteLine ($"Sorted string: {Sort (sort, ReadLine ().ToLower () == "d")}{(spc == "" ? "" : ", ")}{spc}\n");
         }

         /// Sorts character sequence based on input order
         string Sort (char[] charArray, bool orderdesc = false)
               => string.Join (", ", orderdesc ? charArray.OrderByDescending (x => x) : charArray.Order ());
      }
      #endregion
   }
   #endregion
}