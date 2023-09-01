namespace Training {
   internal class Program {
      /// <summary> Program to determine whether entered assword is strong </summary>
      static void Main () {
         Console.WriteLine ("The password must have length > 6,\nand contain at least one upper case character,\n" +
                            "one lower case character,\none digit,\nand one special character[!@#$%^&*()-+].\n");
         for (; ; ) {
            Console.Write ("Enter password or [q] to exit: ");
            string input = Console.ReadLine ();
            if (input.ToLower () == "q") Environment.Exit (0);
            string reason = CheckPassword (input);
            Console.WriteLine ((reason == "" ? "C" : "Inc") + "orrect Password\n" + reason);
         }
      }
      static string CheckPassword (string password) {
         string reason = "", special = "!@#$%^&*()-+", str = "Password needs to have atleast one ";
         if (password.Length < 6) reason += "Password length needs to be greater than 6.\n";
         if (!password.Any (c => char.IsUpper (c))) reason += str + "upper case character.\n";
         if (!password.Any (c => char.IsLower (c))) reason += str + "lower case character.\n";
         if (!password.Any (c => char.IsDigit (c))) reason += str + "digit.\n";
         if (!password.Any (c => special.Contains (c))) reason += str + "special character [!@#$%^&*()-+].\n";
         return reason;
      }
   }
}