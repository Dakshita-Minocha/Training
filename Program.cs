namespace Training {
   internal class Program {
      /// <summary> Program to determine whether entered assword is strong </summary>
      static void Main () {
         Console.WriteLine ("Enter password: ");
         string input = Console.ReadLine ();
         string reason = CheckPassword (input);
         Console.WriteLine ((reason == "" ? "C" : "Inc") + "orrect Password\n" + reason);
      }
      static string CheckPassword (string password) {
         string reason = "", special = "!@#$%^&*()-+", str = "Password needs to have atleast one ";
         if (password.Length < 6) reason += "Password length needs to be greater than 6.\n";
         if (password.All (c => !char.IsUpper (c))) reason += str + "upper case character.\n";
         if (password.All (c => !char.IsLower (c))) reason += str + "lower case character.\n";
         if (password.All (c => !char.IsDigit (c))) reason += str + "digit.\n";
         if (password.All (c => !special.Contains (c))) reason += str + "special character [!@#$%^&*()-+].\n";
         return reason;
      }
   }
}