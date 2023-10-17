// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to declare a winner (with the most number of votes) in a contest, given a string of votes. 
// String may not be null, and the contestant with the first votes is the winner in case of a draw.
// ---------------------------------------------------------------------------------------
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main (string[] args) => CalculateVotes (GetString ());

      /// <summary>Gets non-null input string from user.</summary>
      /// <returns>string of votes.</returns>
      static string GetString () {
         string input;
         for (; ; ) {
            Console.Write ("Enter vote string: ");
            input = Console.ReadLine () ?? "";
            if (input is not "" && input.All (c => char.IsLetter (c))) break;
         }
         return input.ToLower ();
      }

      /// <summary>Calculates votes based on number of occurences of character in string.</summary>
      /// <param name="votes">Input string of votes</param>
      static void CalculateVotes (string votes) {
         List<(char candidate, int votes)> votingRegister = new ();
         foreach (var vote in votes) {
            int ind = votingRegister.IndexOf (votingRegister.Where (x => x.candidate == vote).FirstOrDefault ());
            if (ind == -1) votingRegister.Add ((vote, 1));
            else votingRegister[ind] = (votingRegister[ind].candidate, votingRegister[ind].votes + 1);
         }
         (char candidate, int numofvotes) = Winner (votingRegister);
         Console.WriteLine ($"Winner: {candidate} with {numofvotes} votes.");
      }

      /// <summary>Finds winner based on given conditions: max no of votes or first occurence (if tied)</summary>
      /// <param name="votingRegister"> List with Tuple (candidate, no. of votes)</param>
      static (char, int) Winner (List<(char candidate, int votes)> votingRegister) {
         int max = votingRegister.OrderByDescending (x => x.votes).First ().votes;
         foreach (var tup in votingRegister)
            if (tup.votes == max)
               return tup;
         return (' ', 0);
      }
      #endregion
   }
   #endregion
}