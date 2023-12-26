namespace Eval;

public class EvalException : Exception {
   public EvalException (string message) : base (message) => LogException ();

   void LogException () {
      using (var logFile = new StreamWriter ($"C:/etc/LogFile.txt", true)) {
         logFile.WriteLine (DateTime.Now);
         logFile.WriteLine (">" + Evaluator.mText + "\n" + Message + "\n");
         logFile.Flush ();
      }
   }
}

public class Evaluator {
   public double Evaluate (string text) {
      mText = text;
      mOperands.Clear ();
      mOperators.Clear ();
      List<Token> tokens = new ();
      Token lastToken = null!;
      var tokenizer = new Tokenizer (this, text);
      for (; ; ) {
         var token = tokenizer.Next (lastToken);
         if (token is TEnd) break;
         if (token is TError err) throw new EvalException (err.Message);
         tokens.Add (token);
         lastToken = token;
      }
      if (tokens[^1] is TOperator) throw new EvalException ("Invalid Expression");
      // Check if this is a variable assignment
      TVariable? tVariable = null;
      if (tokens.Count > 2 && tokens[0] is TVariable tvar && tokens[1] is TOpArithmetic { Op: '=' }) {
         tVariable = tvar;
         tokens.RemoveRange (0, 2);
      }
      foreach (var t in tokens) Process (t);
      while (mOperators.Count > 0) ApplyOperator ();
      if (mOperators.Count > 0 || mOperands.Count == 0) throw new EvalException ("Too few operands");
      if (mOperands.Count > 1) throw new EvalException ("Too many operands");
      if (BasePriority != 0) { BasePriority = 0; throw new EvalException ("Invalid Expression"); }
      double f = mOperands.Pop ();
      if (tVariable != null) mVars[tVariable.Name] = f;
      return f;
   }
   static public string mText = "";
   internal int BasePriority { get; set; }

   public double GetVariable (string name) {
      if (mVars.TryGetValue (name, out double f)) return f;
      throw new EvalException ($"Unknown variable: {name}");
   }
   readonly Dictionary<string, double> mVars = new ();

   void Process (Token token) {
      switch (token) {
         case TNumber num:
            mOperands.Push (num.Value);
            break;
         case TOperator op:
            while (mOperators.Count != 0 && mOperands.Count != 0 && mOperators.Peek ().Priority >= op.Priority) ApplyOperator ();
            mOperators.Push (op);
            break;
         case TPunctuation p when p.Punct is '(':
            break;
         case TPunctuation p when p.Punct is ')':
            ApplyOperator (); break;
      }
   }
   readonly Stack<double> mOperands = new ();
   readonly Stack<TOperator> mOperators = new ();

   void ApplyOperator () {
      var op = mOperators.Pop ();
      double f1 = mOperands.Pop (), f2;
      if (op is TOpArithmetic arith) {
         try {
            f2 = mOperands.Pop ();
         } catch (Exception) { throw new EvalException ("Too few operands"); }
         mOperands.Push (arith.Evaluate (f2, f1));
      } else mOperands.Push (op is TOpUnary un ? un.Evaluate (f1) : ((TOpFunction)op).Evaluate (f1));
   }
}