// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ------------------------------------------------------------------
// Class1.cs                                                                     
// Class Library to implement a custom MyList<T> class using arrays as the underlying data structure.
// The MyList<T> should start with an initial capacity of 4 and double its capacity when needed. 
// ------------------------------------------------------------------------------------------------
using static System.Console;

namespace Classlib;
#region class MyList ---------------------------------------------------------------------------
public class MyList<T> {
   #region Constructor -------------------------------------------
   public MyList () => array = new T[Capacity];
   #endregion

   #region Properties --------------------------------------------
   /// <summary>Current max capacity of list</summary>
   public int Capacity => mCapacity;
   int mCapacity = 4;

   /// <summary>Number of non-null elements in list</summary>
   public int Count { get; private set; }
   #endregion

   #region Method ------------------------------------------------
   /// <summary>Adds {value} to end of current list</summary>
   public void Add (T value) {
      if (Count == Capacity) Resize (2);
      array[Count++] = value;
   }

   /// <summary>Clears all elements of list</summary>
   public void Clear () {
      Count = 0;
      array = new T[Capacity];
   }

   /// <summary>Inserts element in array at specified index.</summary>
   /// <param name="index">Index value at which element is to be inserted.</param>
   /// <param name="value">Values of element</param>
   /// <exception cref="Exception">If specified Index is out of range [0, Count)</exception>
   public void Insert (int index, T value) {
      CheckIndex (index);
      T[] temp = array.ToArray ();
      for (int count = 0, i = 0; count < Count + 1; count++)
         if (count != index) {
            if (count == Capacity) Resize (2);
            array[count] = temp[i++];
         }
      array[index] = value;
      Count++;
   }

   /// <summary>Removes first instance of given value</summary>
   /// <param name="value">Value to be removed from list</param>
   /// <returns>true if Value has been removed</returns>
   /// <exception cref="InvalidOperationException">If value does not exist in list</exception>
   public bool Remove (T value) {
      if (!array.Any (x => x.Equals (value)))
         throw new InvalidOperationException (nameof (value) + " does not exist in list.");
      int index = Array.IndexOf (array, value);
      for (int i = 0, count = 0; i < Capacity; i++)
         if (i != index) array[count++] = array[i];
      if (--Count <= Capacity / 2) Resize (0.5);
      return true;
   }

   /// <summary>Remove element at specified index</summary>
   /// <param name="index">Specified index</param>
   /// <exception cref="IndexOutOfRangeException">If specified index is out of range [0, Count)</exception>
   public void RemoveAt (int index) {
      CheckIndex (index);
      for (int i = 0, count = 0; i < Count; i++)
         if (i != index) array[count++] = array[i];
      if (--Count <= Capacity / 2) Resize (0.5);
   }

   /// <summary>Allows user to access elements by specifying index within index specifiers[]: list[index]</summary>
   /// <returns>Value of element in list at index</returns>
   /// <exception cref="IndexOutOfRangeException">If specified Index is out of range [0, Count)</exception>
   public T this[int index] {
      get {
         CheckIndex (index);
         return array[index];
      }
      set {
         CheckIndex (index);
         array[index] = value;
      }
   }
   #endregion

   #region Implementation ----------------------------------------
   /// <summary> Resizes Array to double current capacity </summary>
   void Resize (double multiplier) {
      mCapacity = (int)(mCapacity * multiplier);
      Array.Resize (ref array, Capacity);
   }

   /// <summary>Checks value of index and throws exception if necessary</summary>
   /// <exception cref="IndexOutOfRangeException">If index > Count or index < 0</exception>
   void CheckIndex (int index) {
      if (index >= Count || index < 0)
         throw new IndexOutOfRangeException (nameof (index) + (index >= Count ? " >= Count" : " < 0"));
   }
   #endregion

   #region Private Data ------------------------------------------
   T[] array;
   #endregion
}
#endregion
