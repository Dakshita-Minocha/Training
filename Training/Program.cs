// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement Double Ended Queue.
// ------------------------------------------------------------------------------------------------
using static System.Console;
namespace Training;

#region Class Program -----------------------------------------------------------------------------
internal class Program {
   static void Main (string[] args) {
      int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      DoubleQueue<int> q = new ();
      WriteLine (q.IsEmpty);
      foreach (var num in nums[0..4]) {
         q.BackEnqueue (num);
         WriteLine ($"Back Enqueue: {num}");
      }
      WriteLine (q);
      WriteLine ($"FrontDeQ:{q.FrontDequeue ()}");
      WriteLine ($"Back Enqueue: {nums[4]}");
      q.BackEnqueue (nums[4]);
      WriteLine (q);
      WriteLine ($"Back Enqueue: {nums[5]}");
      q.BackEnqueue (nums[5]);
      WriteLine (q);
      WriteLine ($"BackDeQ: {q.BackDequeue ()}");
      WriteLine (q);
      WriteLine ($"BackDeQ: {q.BackDequeue ()}");
      WriteLine (q);
      WriteLine ($"Count: {q.Count}");
   }
}
#endregion
#region class DoubleQueue<T> ----------------------------------------------------------------------
public class DoubleQueue<T> {
   #region Constructors ---------------------------------------------
   public DoubleQueue () => mArray = new T[Capacity];
   #endregion

   #region Properties -----------------------------------------------
   public int Capacity { get; private set; } = 4;

   public int Count { get; private set; }

   public bool IsEmpty => Count == 0;
   #endregion

   #region Method ---------------------------------------------------
   /// <summary>Dequeues element from back-end of queue.</summary>
   /// <returns>T element</returns>
   /// <exception cref="InvalidOperationException">If queue is Empty.</exception>
   public T BackDequeue () {
      if (IsEmpty) throw new InvalidOperationException ("Empty Queue.");
      mEnd = (mEnd - 1) % Capacity;
      T ele = mArray[mEnd];
      Count--;
      return ele;
   }

   /// <summary>Enqueues element at back-end of queue.</summary>
   /// <param name="value">T value to be enqueued.</param>
   public void BackEnqueue (T value) {
      if (Count == Capacity) Resize (2);
      mArray[mEnd] = value;
      mEnd = (mEnd + 1) % Capacity;
      Count++;
   }

   /// <summary>Dequeues element from Front-end of queue.</summary>
   /// <returns>T element</returns>
   /// <exception cref="InvalidOperationException">If queue is empty.</exception>
   public T FrontDequeue () {
      if (IsEmpty) throw new InvalidOperationException ("Empty Queue.");
      T ele = mArray[mStart];
      mStart = (mStart + 1) % Capacity;
      Count--;
      return ele;
   }

   /// <summary>Enqueues element to start of queue.</summary>
   /// <param name="value">T value to be enqueued.</param>

   // use mStart to find start of array and insert element at mStart - 1.
   public void FrontEnqueue (T value) {
      //if (Count == Capacity) Resize (2);
      //mArray[mWriteS] = value;
      //mWriteS = (mWriteS + 1) % Capacity;
      //Count++;
   }

   public override string ToString () {
      string s = "";
      int start = mStart;
      for (int i = 0; i < Count; i++) {
         s += mArray[start] + " ";
         start = (start + 1) % Capacity;
      }
      return s;
   }
   #endregion

   #region Implementation -------------------------------------------
   /// <summary>Resizes array to n times size.</summary>
   void Resize (double n) {
      T[] temp = new T[Capacity * 2];
      for (int i = 0; i < Capacity; i++)
         temp[i] = mArray[(mStart + i) % Capacity];
      mArray = temp;
      Capacity *= 2;
      mStart = 0;
      mEnd = Count;
   }
   #endregion

   #region Private Data ---------------------------------------------
   T[] mArray;
   int mStart, mEnd;
   #endregion
}
#endregion