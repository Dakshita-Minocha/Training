// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Evaluator.cs
// Program to implement expression evaluator.
// ------------------------------------------------------------------------------------------------
namespace Training;
#region Class Evaluator ---------------------------------------------------------------------------
/// <summary>Used to define a new instance of an expression evaluator which retuns
/// a calculated result for input expression.</summary>
public class Evaluator {
   #region Method ---------------------------------------------------
   /// <summary>Throws EvalException if unkown input in encountered.</summary>
   public static void Error (string s) => throw new EvalException (s);

   /// <summary>Evaluates string input and returns result.</summary>
   public double Evaluate (string expression) {
      mOperands.Clear ();
      mOperators.Clear ();
      Tokenizer tokenizer = new (this, expression);
      List<Token> tokens = new ();
      for (; ; ) {
         Token t = tokenizer.GetNextToken (tokens);
         if (t is TEnd) break;
         tokens.Add (t);
      }
      if (tokens[^1] is TOperator) Error ("Invalid Expression");

      // Checking for assignment operator
      TVariable var = null!;
      if (tokens.Count > 1 && tokens[0] is TVariable tv && tokens[1] is TBinary { Op: '=' }) {
         var = tv;
         tokens.RemoveRange (0, 2);
      }

      // Processing
      foreach (Token t in tokens) Process (t);
      while (mOperators.Count > 0) ApplyOperator ();

      if (mOperators.Count != 0) Error ("Too many Operators");
      if (mOperands.Count != 1) Error ("Too many Operands");

      double result = Math.Round (mOperands.Pop (), 10);
      if (var != null) mVariables[var.Name] = result;
      return result;
   }

   /// <summary>Returns the value of the entered variable token.</summary>
   /// <param name="name">Variable name</param>
   /// <exception cref="EvalException">Throws Exception if user is
   /// trying to access value of unknown variable.</exception>
   public double GetVariable (string name) {
      if (mVariables.TryGetValue (name, out double val)) return val;
      throw new EvalException ($"Unknown Variable '{name}'");
   }
   readonly Dictionary<string, double> mVariables = new ();
   #endregion

   #region Implementation -------------------------------------------
   /// <summary>Applies Operator off the top of operator stack to required number of
   /// operands and pushes results onto top of operand stack.</summary>
   void ApplyOperator () {
      TOperator op = mOperators.Pop ();
      double a;
      try { a = mOperands.Pop (); } catch (Exception) {
         mOperators.Push (op);
         return;
      }
      switch (op) {
         case TFunc fun:
            mOperands.Push (fun.Apply (a)); break;
         case TBinary bin:
            if (mOperands.Count < 1) Error ("Too few operands");
            double b = mOperands.Pop ();
            mOperands.Push (bin.Apply (b, a)); break;
         case TUnary tun:
            mOperands.Push (tun.Apply (a)); break;
         default: Error ("Operator type not implemented"); break;
      }
   }

   /// <summary>Adds tokens to appropriate stack or applies operator if priority
   /// of current operator >= priority of prev operator</summary>
   void Process (Token token) {
      switch (token) {
         case TNumber num:
            mOperands.Push (num.Value); break;
         case TPunctuation p:
            if (p.Punct == '(') break;
            ApplyOperator ();
            break;
         case TOperator op:
            if (mOperators.Count != 0 && mOperators.Peek ().FinalPriority >= op.FinalPriority)
               ApplyOperator ();
            mOperators.Push (op); break;
         default: Error ("Token not implemented"); break;
      }
   }

   internal int BasePriority { get; set; }
   #endregion

   #region Private Data ---------------------------------------------
   readonly Stack<double> mOperands = new ();
   readonly internal Stack<TOperator> mOperators = new ();
   #endregion
}
#endregion

