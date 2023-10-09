// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to Implement a Stack<T> class using arrays as the underlying data structure.
// The Stack<T> should start with an initial capacity of 4 and double its capacity when needed.
// class TStack<T> {
//    public void Push (T a) { }
//    public T Pop () { }
//    public T Peek () { }
//    public bool IsEmpty { get; }
// }
// ---------------------------------------------------------------------------------------
using static System.Console;
namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main (string[] args) {
         // Test Cases:
         Stack<int> stack = new ();
         Write ("--Pushing to stack: 1 2 3 4");
         stack.Push (1);
         stack.Push (2);
         stack.Push (3);
         stack.Push (4);
         WriteLine ($"\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
         stack.Push (5); stack.Push (6);
         WriteLine ($"--Pushing: 5 6\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
         WriteLine ($"--Popping: {stack.Pop ()}\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
         WriteLine ($"--Popping: {stack.Pop ()}\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
         WriteLine ($"--Peeking: {stack.Peek ()}\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
      }
      #endregion
   }
   #endregion

   #region class Stack --------------------------------------------------------------------------
   class Stack<T> {
      #region Method ----------------------------------------------
      int _count = 0, _capacity = 4;
      T[] array = null;

      /// <summary> Creates a new stack with Capacity = 4. </summary>
      public Stack () => array = new T[_capacity];

      /// <summary> Returns number of elements in Stack. </summary>
      public int Count => _count;

      /// <summary> Returns current Capacity of Stack. </summary>
      public int Capacity => _capacity;

      /// <summary> Returns true if Stack is Empty. </summary>
      public bool IsEmpty => Count == 0;

      /// <summary> Adds elements to top of Stack. </summary>
      public void Push (T value) {
         try {
            array[Count] = value;
            _count++;
         } catch (IndexOutOfRangeException) {
            Resize (2);
            array[_count++] = value;
         }
      }

      /// <summary> Pops top element off of Stack </summary>
      /// <exception cref="InvalidOperationException"> When Stack is Empty. </exception>
      public T Pop () {
         if (IsEmpty) throw new InvalidOperationException ("Stack Empty");
         try {
            return array[--_count];
         } finally {
            array[Count] = default;
         }
      }

      /// <summary> Peeks at top element of Stack without removing it </summary>
      /// <returns> Value of top element on Stack. </returns>
      /// <exception cref="InvalidOperationException"> When Stack is Empty. </exception>
      public T Peek () {
         if (IsEmpty) throw new InvalidOperationException ("Stack Empty");
         return array[Count - 1];
      }

      /// <summary> Resizes Stack to n times current Capacity. </summary>
      void Resize (int n) {
         _capacity *= n;
         Array.Resize (ref array, Capacity);
      }
   }
   #endregion
}
#endregion
