// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to return the maximum number of chocolates C you can get along with any unused money X and wrapperPrice W
// for given X amount of money along with price P of a chocolate and required wrapperPrice W for a chocolate in exchange.
// ---------------------------------------------------------------------------------------
using static System.Globalization.CultureInfo;
using static System.Console;
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main (string[] args) => Display ();

      /// <summary> Gets proper user input and displays results from BuyChocolatesWith_ functions </summary>
      static void Display () {
         // Setting currency as US Dollars as it is supported in all console fonts.
         CurrentCulture = new System.Globalization.CultureInfo ("en-US");
         int minimum = 1, wrapperPrice, chocolates = 0;
         decimal price, money, wrappers = 0;
         Write ("Welcome to the chocolate shop!\n\n" + "Which chocolate would you like to buy? ");
         // input chocolate price
         while (true) {
            Write ("Enter Price: ");
            if (decimal.TryParse (ReadLine (), out price) && price > minimum) break;
            Write ($"Price must be > {minimum:c2}. ");
         }
         // input money
         while (true) {
            Write ("How much money do you have? ");
            if (decimal.TryParse (ReadLine (), out money) && money > minimum) break;
            Write ($"You must have more than {minimum:c2}. ");
         }
         // input no. of wrapperPrice
         while (true) {
            Write ("Required Wrappers for a chocolate in exchange? ");
            if (int.TryParse (ReadLine (), out wrapperPrice) && wrapperPrice > minimum) break;
            Write ($"Exchange wrapper(s) must be > {minimum}. ");
         }
         if (BuyChocolates (price, ref money, ref chocolates)) {
            Write ($"1 chocolate costs {price:c2} or {wrapperPrice} wrappers.\n\nYou get {chocolates} chocolates with money.\n" +
                   $"Balance: {money:c2}\n\nWould you like to buy with {chocolates} wrappers? Press y/n.");
            if (ReadKey (true).Key == ConsoleKey.Y) {
               wrappers = chocolates;
               BuyChocolates (wrapperPrice, ref wrappers, ref chocolates);
            }
         }
         Write ($"\nYou bought {chocolates} chocolates.\nBalance: {wrappers} wrappers" +
                 "\nThanks for visiting, Come again soon!");
      }

      /// <summary> Calculates number of chocolates user can buy, returns true if buying is possible. </summary>
      /// <returns> True if money >= price, left-over money and wrapperPrice </returns>
      static bool BuyChocolates (decimal price, ref decimal money, ref int chocolates) {
         if (money >= price) {
            chocolates += (int)(money / price);
            money %= price;
            return true;
         }
         return false;
      }
      #endregion
   }
   #endregion
}