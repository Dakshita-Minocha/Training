// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to return the maximum number of chocolates C you can get along with any unused money X and wrappers W
// for given X amount of money along with price P of a chocolate and required wrappers W for a chocolate in exchange.
// ---------------------------------------------------------------------------------------
using static System.Globalization.CultureInfo;
using static System.Console;
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main (string[] args) => Display ();

      /// <summary> Gets proper user input and displays results from Buy Chocolates function </summary>
      static void Display () {
         CurrentCulture = new System.Globalization.CultureInfo ("en-US");   // Setting currency as US Dollars as it is supported in all console fonts.
         int minimum = 1, wrappers;
         decimal price, money;
         Write ("Welcome to the chocolate shop!\n" + "Which chocolate would you like to buy? ");
         while (true) {   // input chocolate price
            Write ("Enter Price: ");
            if (decimal.TryParse (ReadLine (), out price) && price > minimum) break;
            Write ($"Price must be > {minimum:c2}. ");
         }
         while (true) {   // input money
            Write ("How much money do you have? ");
            if (decimal.TryParse (ReadLine (), out money) && money > minimum) break;
            Write ($"You must have more than {minimum:c2}. ");
         }
         while (true) {   // input no. of wrappers
            Write ("How many wrappers do you have? ");
            if (int.TryParse (ReadLine (), out wrappers) && wrappers > minimum) break;
            Write ($"You must have wrapper(s) > {minimum}. ");
         }
         if (BuyChocolates (price, ref money, ref wrappers, out int chocolates))
            Write ($"1 chocolate costs {price:c2} or 2 wrappers.\nYou get {chocolates} chocolates.\n" +
                   $"You have {money:c2} and {wrappers} wrappers left\n");
         else Write ("You don't have enough money/wrappers for a chocolate. Sorry :(\nCome again soon!\n");
      }

      /// <summary> Calculates number of chocolates user can buy, returns true if buying is possible. </summary>
      /// <returns> True if we have enough money to buy and left-over money and wrappers </returns>
      static bool BuyChocolates (decimal price, ref decimal money, ref int wrappers, out int chocolates) {
         chocolates = 0;
         if (money >= price && wrappers >= 2) {
            chocolates = (int)(money / price + wrappers / 2);
            wrappers %= 2;
            money %= price;
            return true;
         }
         return false;
      }
      #endregion
   }
   #endregion
}