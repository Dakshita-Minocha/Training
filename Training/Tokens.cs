// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Tokens.cs
// Tokens used to implement expression evaluator.
// ------------------------------------------------------------------------------------------------
namespace Training;

#region abstract Class Token ----------------------------------------------------------------------
abstract class Token {
}
#endregion

#region Class TOperator ---------------------------------------------------------------------------
class TOperator : Token {
   internal TOperator (Evaluator eval) => mEval = eval;
   internal virtual int Priority { get; }
   internal virtual int FinalPriority { get; }
   readonly protected Evaluator mEval;
}
#endregion

#region Class TNumber -----------------------------------------------------------------------------
class TNumber : Token {
   public TNumber (Evaluator eval) => mEval = eval;
   public virtual double Value { get; }
   protected Evaluator mEval { get; }
}
#endregion

#region Class TPunctuation ------------------------------------------------------------------------
class TPunctuation : Token {
   public TPunctuation (char ch) => mPunct = ch;
   public char Punct => mPunct;
   readonly char mPunct;
}
#endregion

#region Class TEnd --------------------------------------------------------------------------------
class TEnd : Token { }
#endregion

#region Class EvalException -----------------------------------------------------------------------
public class EvalException : Exception {
   public EvalException (string msg) : base (msg) { }
}
#endregion

#region Class TUnary ------------------------------------------------------------------------------
class TUnary : TOperator {
   public TUnary (Evaluator eval, char op) : base (eval) {
      Op = op;
      mFinalP = Priority + mEval.BasePriority;
   }
   internal override int Priority => 9;
   public double Apply (double a) =>
      Op switch {
         '+' => a,
         '-' => -a,
         _ => throw new EvalException ("Unary Operator not Implemented")
      };
   internal override int FinalPriority => mFinalP;
   int mFinalP;

   public override string ToString () => $"TUnary {Op}";
   internal char Op { get; private set; }
}
#endregion

#region Class TFunc -------------------------------------------------------------------------------
class TFunc : TOperator {
   internal TFunc (Evaluator eval, string func) : base (eval) {
      Op = func;
      mFinalP = Priority + mEval.BasePriority;
   }
   internal override int Priority => 6;
   internal override int FinalPriority => mFinalP;
   int mFinalP;

   public double Apply (double a) =>
      Op switch {
         "sin" => Math.Sin (D2R (a)),
         "cos" => Math.Cos (D2R (a)),
         "tan" => Math.Tan (D2R (a)),
         "acos" => R2D (Math.Acos (a)),
         "asin" => R2D (Math.Asin (a)),
         "atan" => R2D (Math.Atan (a)),
         "log" => Math.Log (a),
         "exp" => Math.Exp (a),
         "sqrt" => Math.Sqrt (a),
         _ => throw new EvalException ("Function not Implemented")
      };

   public override string ToString () => $"TFunc {Op}";

   internal static readonly string[] funcs = { "sin", "cos", "tan", "asin", "acos", "atan", "log", "exp", "sqrt" };
   internal string Op { get; private set; }

   #region Implementation -------------------------------------------
   static double D2R (double d) => d * Math.PI / 180;
   static double R2D (double r) => r * 180 / Math.PI;
   #endregion
}
#endregion

#region Class TBinary -----------------------------------------------------------------------------
class TBinary : TOperator {
   public TBinary (Evaluator eval, char ch) : base (eval) {
      Op = ch;
      mFinalP = Priority + mEval.BasePriority;
   }
   internal override int Priority => Op switch {
      '=' => 0,
      '+' or '-' => 1,
      '*' or '/' => 2,
      '%' => 3,
      '^' => 4,
      _ => throw new EvalException ("Operator not implemented")
   };
   internal override int FinalPriority => mFinalP;
   int mFinalP;

   public double Apply (double a, double b) =>
      Op switch {
         '-' => a - b,
         '+' => a + b,
         '*' => a * b,
         '/' => a / b,
         '%' => a % b,
         '^' => Math.Pow (a, b),
         _ => 0
      };

   public override string ToString () => $"TBinary {Op}";
   public char Op { get; private set; }
}
#endregion

#region Class TLiteral ----------------------------------------------------------------------------
class TLiteral : TNumber {
   public TLiteral (Evaluator eval, string num) : base (eval) => mValue = double.Parse (num);
   public override double Value => mValue;
   public override string ToString () => $"TLiteral {Value}";
   readonly double mValue;
}
#endregion

#region Class TVariable ---------------------------------------------------------------------------
class TVariable : TNumber {
   public TVariable (Evaluator eval, string name) : base (eval) => Name = name;
   public string Name { get; }
   public override double Value => mEval.GetVariable (Name);
   public override string ToString () => $"TVariable {Name} = {Value}";
}
#endregion