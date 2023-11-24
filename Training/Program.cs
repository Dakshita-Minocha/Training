// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement Double Ended Queue.
// ------------------------------------------------------------------------------------------------
using System.Text;
using static System.Console;
namespace Training;

#region Class Program -----------------------------------------------------------------------------
internal class Program {
   static void Main (string[] args) {
      DoubleQueue<int> q = new ();
      Random random = new ();
      for (int i = 0; i < 50; i++) {
         int r = random.Next (0, 4);
         try {
            switch (r) {
               case 0: WriteLine ($"Back EnQ: {i}"); q.BackEnqueue (i); break;
               case 1: WriteLine ($"Fron EnQ: {i}"); q.FrontEnqueue (i); break;
               case 2: WriteLine ($"Fron DeQ: {q.FrontDequeue ()}"); break;
               case 3: WriteLine ($"Back DeQ: {q.BackDequeue ()}"); break;
            }
         } catch (Exception e) { WriteLine (e.Message); }
         WriteLine (q);
      }
   }
}
#endregion

#region Class DoubleQueue<T> ----------------------------------------------------------------------
public class DoubleQueue<T> {
   #region Constructors ---------------------------------------------
   public DoubleQueue () => mArray = new T[Capacity];
   #endregion

   #region Properties -----------------------------------------------
   /// <summary>Number of elements queue can store without resizing.</summary>
   public int Capacity { get; private set; } = 4;

   /// <summary>Number of elements in queue.</summary>
   public int Count { get; private set; }

   /// <summary>Whether queue is empty.</summary>
   public bool IsEmpty => Count == 0;
   #endregion

   #region Method ---------------------------------------------------
   /// <summary>Dequeues element from back-end of queue.</summary>
   /// <returns>T element</returns>
   /// <exception cref="InvalidOperationException">If queue is Empty.</exception>
   public T BackDequeue () {
      if (IsEmpty) throw new InvalidOperationException ("Empty Queue.");
      mEnd = (Capacity + mEnd - 1) % Capacity;
      Count--;
      return mArray[mEnd];
   }

   /// <summary>Enqueues element at back-end of queue.</summary>
   /// <param name="value">Value to be enqueued.</param>
   public void BackEnqueue (T value) {
      if (Count == Capacity) Resize (2);
      mArray[mEnd] = value;
      mEnd = (mEnd + 1) % Capacity;
      Count++;
   }

   /// <summary>Dequeues element from Front-end of queue.</summary>
   /// <returns>Dequeued element</returns>
   /// <exception cref="InvalidOperationException">If queue is empty.</exception>
   public T FrontDequeue () {
      if (IsEmpty) throw new InvalidOperationException ("Empty Queue.");
      T ele = mArray[mStart];
      mStart = (mStart + 1) % Capacity;
      Count--;
      return ele;
   }

   /// <summary>Enqueues element to start of queue.</summary>
   /// <param name="value">Value to be enqueued.</param>
   public void FrontEnqueue (T value) {
      if (Count == Capacity) Resize (2);
      mStart = (Capacity + mStart - 1) % Capacity;
      mArray[mStart] = value;
      Count++;
   }

   /// <summary>Returns string of all elements in queue separated by ' '.</summary>
   public override string ToString () {
      StringBuilder s = new ();
      int start = mStart;
      for (int i = 0; i < Count; i++) {
         s.Append (mArray[start] + " ");
         start = (start + 1) % Capacity;
      }
      return s.ToString ();
   }
   #endregion

   #region Implementation -------------------------------------------
   /// <summary>Resizes array to n times size.
   /// Elements are copied into new array from index Capacity/4 to index Capacity - Capacity/4
   /// to leave space for enqueue operations. Queue is resized every time either front of queue
   /// or back of queue runs out of space.</summary>
   void Resize (int n) {
      T[] temp = new T[Capacity * n];
      int i = 0, tIn = Capacity / n;
      Capacity *= n;
      while (i < Count) {
         temp[tIn] = mArray[(mStart + i++) % Count];
         tIn = (tIn + 1) % Capacity;
      }
      (mArray, mStart, mEnd) = (temp, Capacity / 4, Capacity - Capacity / 4);
   }
   #endregion

   #region Private Data ---------------------------------------------
   T[] mArray;
   int mStart, mEnd;
   #endregion
}
#endregion