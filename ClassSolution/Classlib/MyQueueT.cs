// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ------------------------------------------------------------------
// MyQueueT.cs                                                                     
// Class library to implement a Queue<T> using arrays as the underlying data structure.
// The mArray should grow the mArray when needed (like the TStack above does).
// If the mArray does not have to be grown, both Enqueue and Dequeue should be
// constant time (O(1)) operations.Throw exceptions as needed. 
// class MyQueue<T> {
//    public void Enqueue (T a) { }
//    public T Dequeue () { }
//    public T Peek () { }
//    public bool IsEmpty { get; }
// }
// InvalidOperationException: This exception should be thrown when attempting to dequeue or peek an empty mArray. 
// ------------------------------------------------------------------------------------------------
namespace Classlib;

#region class MyQueueT -----------------------------------------------------------------------------
public class MyQueue<T> {
   #region Constructor ----------------------------------------------
   public MyQueue () => mArray = new T[Capacity];
   #endregion

   #region Public Properties ----------------------------------------
   /// <summary>Returns current Capacity of Queue (minimum 4).</summary>
   public int Capacity => _capacity;
   int _capacity = 4;

   /// <summary>Returns Count of elements Enqueued</summary>
   public int Count { get; private set; }

   /// <summary>Returns true if Queue is Empty, false otherwise.</summary>
   public bool IsEmpty => Count == 0;
   #endregion

   #region Method ---------------------------------------------------
   /// <summary>Returns First element from Queue.</summary>
   /// <exception cref="InvalidOperationException">If Queue is Empty.</exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ("Cannot Dequeue: Empty Queue");
      T temp = mArray[0];
      mArray = mArray[1..(Count-- + 1)];
      return temp;
   }

   /// <summary>Add item to Queue</summary>
   public void Enqueue (T item) {
      if (Count == Capacity) Resize (2);
      mArray[Count++] = item;
   }

   /// <summary>Peeks at the first element in Queue without removing it.</summary>
   /// <returns>First element from Queue.</returns>
   /// <exception cref="InvalidOperationException">If Queue is Empty</exception>
   public T Peek () {
      if (IsEmpty) throw new InvalidOperationException ("Nothing to Peek at! Empty Queue");
      return mArray[0];
   }

   /// <summary>Overrides ToString() to display all elements of Queue</summary>
   /// <returns>String containing all members of Queue</returns>
   public override string ToString () {
      string s = "";
      for (int i = 0; i < Count; i++)
         s += mArray[i] + " ";
      return s;
   }
   #endregion

   #region Implementation -------------------------------------------
   /// <summary>Resizes Queue to n times current Capacity.</summary>
   void Resize (int n) {
      _capacity *= n;
      Array.Resize (ref mArray, Capacity);
   }
   #endregion

   #region Private Data ---------------------------------------------
   T[] mArray;
   #endregion
}
#endregion