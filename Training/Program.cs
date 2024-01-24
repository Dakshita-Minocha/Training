// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program on main branch.
// ------------------------------------------------------------------------------------------------
namespace Training;
#region class ComplexNumber --------------------------------------------------------------------------
internal class ComplexNumber {
   #region Constructors ------------------------------------------
   public ComplexNumber (int real, int imag)
      => (mReal, mImag, mNorm) = (real, imag, Math.Sqrt (Math.Pow (Real, 2) + Math.Pow (Imag, 2)));

   public ComplexNumber (double real, double imag)
      => (mReal, mImag, mNorm) = (real, imag, Math.Sqrt (Math.Pow (Real, 2) + Math.Pow (Imag, 2)));
   #endregion

   #region Properties --------------------------------------------
   public double Real { get => mReal; set => mReal = value; }
   double mReal;

   public double Imag { get => mImag; set => mImag = value; }
   double mImag;

   public double Norm => mNorm;
   double mNorm;
   #endregion

   #region Method ------------------------------------------------
   public static ComplexNumber Add (ComplexNumber a, ComplexNumber b)
      => new ComplexNumber (a.Real + b.Real, a.Imag + b.Imag);

   public static ComplexNumber Subtract (ComplexNumber a, ComplexNumber b)
      => new ComplexNumber (a.Real - b.Real, b.Imag - a.Imag);

   public override string ToString () => $"{Real} {(Imag > 0 ? "+" : "")}{Imag}i";
   #endregion

   #region Operators ---------------------------------------------
   public static ComplexNumber operator + (ComplexNumber left, ComplexNumber right)
      => Add (left, right);

   public static ComplexNumber operator - (ComplexNumber left, ComplexNumber right)
      => Subtract (left, right);
   #endregion
}
#endregion