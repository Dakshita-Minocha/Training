// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Tokenizer.cs
// Class Tokenizer used to break (tokenize) input expression into constituent parts (tokens).
// ------------------------------------------------------------------------------------------------
namespace Training;

#region Class Tokenizer ---------------------------------------------------------------------------
class Tokenizer {
   #region Tokenizer ------------------------------------------------
   internal Tokenizer (Evaluator eval, string expression) { mText = expression; mEval = eval; }
   #endregion

   #region Method ---------------------------------------------------
   /// <returns>The next token in the expression</returns>
   internal Token GetNextToken (List<Token> tokens) {
      while (mIndex < mText.Length) {
         char ch = mText[mIndex++];
         switch (ch) {
            case ' ': continue;
            case '+' or '-':
               if (tokens.Count == 0 || tokens[^1] is TBinary || tokens[^1] is TPunctuation { Punct: '(' })
                  return new TUnary (mEval, ch);
               return new TBinary (mEval, ch);
            case '/' or '*' or '%' or '^' or '=': return new TBinary (mEval, ch);
            case >= '0' and <= '9': return GetLiteral ();
            case >= 'a' and <= 'z': return GetIdentifier ();
            case '(' or ')': return new TPunctuation (ch);
            default: throw new EvalException ("Invalid Token");
         };
      }
      return new TEnd ();
   }
   #endregion

   #region Implementation -------------------------------------------
   Token GetIdentifier () {
      string identifier = "";
      int start = mIndex - 1;
      while (start < mText.Length) {
         char ch = mText[start++];
         if (char.IsLetter (ch) || char.IsDigit (ch)) {
            identifier += ch;
            continue;
         }
         mIndex = start - 1;
         break;
      }
      if (TFunc.funcs.Any (x => x == identifier))
         return new TFunc (mEval, identifier);
      return new TVariable (mEval, identifier);
   }

   TLiteral GetLiteral () {
      int start = mIndex - 1;
      while (mIndex < mText.Length) {
         char c = mText[mIndex++];
         if (char.IsDigit (c) || c == '.') continue;
         mIndex--;
         break;
      }
      return new TLiteral (mEval, mText[start..mIndex]);
   }
   #endregion

   #region Private Data ---------------------------------------------
   readonly string mText;
   int mIndex;
   readonly Evaluator mEval;
   #endregion
}
#endregion