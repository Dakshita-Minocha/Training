// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on main branch.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training;
#region class Program --------------------------------------------------------------------------
internal class Program {
   #region Method ------------------------------------------------
   static void Main (string[] args) {
      string[] gameResults = File.ReadAllLines ("C:/Work/Dakshita/input.txt");
      int sumOfIDs = 0, maxRed = 12, maxGreen = 13, maxBlue = 14;
      foreach (string gR in gameResults) {
         bool isValid = true;
         string[] gResult = gR.Split (':');
         int gameID = int.Parse (gResult[0].Remove (0, 5));
         foreach (string revealedSet in gResult[1].Replace (';', ',').Split (',')) {
            int num = int.Parse (revealedSet.Trim ().Split (" ")[0]);
            if (revealedSet.Contains ("red") && num > maxRed
               || revealedSet.Contains ("green") && num > maxGreen
               || num > maxBlue) {
               isValid = false;
               break;
            }
         }
         if (isValid) sumOfIDs += gameID;
      }
      WriteLine ("Sum of IDs: " + sumOfIDs);
   }
   #endregion
}
#endregion