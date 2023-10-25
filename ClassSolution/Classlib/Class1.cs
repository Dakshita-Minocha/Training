// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ------------------------------------------------------------------
// Class1.cs                                                                     
// Classlib to implement a Stack<T> class using arrays as the underlying data structure.
// The Stack<T> should start with an initial capacity of 4 and double its capacity when needed.
// class TStack<T> {
//    public void Push (T a) { }
//    public T Pop () { }
//    public T Peek () { }
//    public bool IsEmpty { get; }
// }
// ------------------------------------------------------------------------------------------------
namespace Classlib;

#region class Stack -------------------------------------------------------------------------------
public class MyStack<T> {
   #region Constructor ----------------------------------------------
   /// <summary>Creates a new stack with Capacity = 4.</summary>
   public MyStack () => array = new T[Capacity];
   #endregion

   #region Properties -----------------------------------------------
   /// <summary>Returns current Capacity of Stack.</summary>
   public int Capacity => mCapacity;
   int mCapacity = 4;

   /// <summary>Returns number of elements in Stack.</summary>
   public int Count { get; private set; }

   /// <summary>Returns true if Stack is Empty.</summary>
   public bool IsEmpty => Count == 0;
   #endregion

   #region Method ---------------------------------------------------
   /// <summary>Peeks at top element of Stack without removing it</summary>
   /// <returns>Value of top element on Stack.</returns>
   /// <exception cref="InvalidOperationException">When Stack is Empty.</exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ("Stack Empty");
      return array[Count - 1];
   }

   /// <summary>Pops top element off of Stack</summary>
   /// <exception cref="InvalidOperationException">When Stack is Empty.</exception>
   public T Pop () {
      if (IsEmpty) throw new InvalidOperationException ("Stack Empty");
      return array[--Count];
   }

   /// <summary>Adds elements to top of Stack.</summary>
   public void Push (T value) {
      if (Count == Capacity) Resize (2);
      array[Count] = value;
      Count++;
   }
   #endregion

   #region Implementation -------------------------------------------
   /// <summary>Resizes Stack to n times current Capacity.</summary>
   void Resize (int n) {
      mCapacity *= n;
      Array.Resize (ref array, Capacity);
   }
   #endregion

   #region Private Data ---------------------------------------------
   T[] array;
   #endregion
}
#endregion