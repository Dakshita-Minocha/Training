namespace Eval;

class Program {
   static void Main (string[] args) {
      var eval = new Evaluator ();
      for (; ; ) {
         Console.Write ("> ");
         string text = Console.ReadLine () ?? "";
         if (text == "exit") break;
         try {
            double result = eval.Evaluate (text);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine (result);
         } catch (Exception e) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine (e.Message);
            LogException (e.Message);
         }
         Console.ResetColor ();
      }

      void LogException (string message) {
         string dir = "..\\Log";
         if (!Directory.Exists (dir)) Directory.CreateDirectory (dir);
         using (var logFile = new StreamWriter ($"../Log/{DateTime.Now.Day}_{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.txt", true)) {
            logFile.WriteLine (DateTime.Now);
            logFile.WriteLine (">" + Evaluator.mText + "\n" + message + "\n");
            logFile.Flush ();
         }
      }
   }
}
