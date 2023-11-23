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
      DoubleQueue<int> q = new ();
      Random random = new ();
      for (int i = 0; i < 50; i++) {
         int r = random.Next (0, 3);
         try {
            switch (r) {
               case 0: WriteLine ($"Back EnQ: {i}"); q.BackEnqueue (i); break;
               case 1: WriteLine ($"Fron EnQ: {i}"); q.FrontEnqueue (i); break;
               case 2: WriteLine ($"Fron DeQ: {i}"); q.FrontDequeue (); break;
               case 3: WriteLine ($"Back DeQ: {i}"); q.BackDequeue (); break;
            }
         } catch (Exception e) { WriteLine (e.Message); }
         WriteLine (q);
      }
      //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      //DoubleQueue<int> q = new ();
      //WriteLine (q.IsEmpty);
      //foreach (var num in nums[0..4]) {
      //   q.BackEnqueue (num);
      //   WriteLine ($"Back Enqueue: {num}");
      //}
      //WriteLine (q);
      //WriteLine ($"FrontDeQ:{q.FrontDequeue ()}");
      //WriteLine ($"FrontEnQ: -1");
      //q.FrontEnqueue (-1);
      //WriteLine (q);
      //WriteLine ($"Back Enqueue: {nums[4]}");
      //q.BackEnqueue (nums[4]);
      //WriteLine (q);
      //WriteLine ($"Back Enqueue: {nums[5]}");
      //q.BackEnqueue (nums[5]);
      //WriteLine (q);
      //WriteLine ($"FrontEnQ: -2");
      //q.FrontEnqueue (-2);
      //WriteLine (q);
      //WriteLine ($"FrontEnQ: -3");
      //q.FrontEnqueue (-3);
      //WriteLine (q);
      //WriteLine ($"Back Enqueue: {nums[6]}");
      //q.BackEnqueue (nums[6]);
      //WriteLine (q);
      //WriteLine ($"BackDeQ: {q.BackDequeue ()}");
      //WriteLine (q);
      //WriteLine ($"BackDeQ: {q.BackDequeue ()}");
      //WriteLine (q);
      //WriteLine ($"Count: {q.Count}");
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
      mEnd = mEnd == 0 ? Capacity - 1 : (mEnd - 1) % Capacity;
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

   public void FrontEnqueue (T value) {
      if (Count == Capacity) Resize (2);
      mStart = mStart == 0 ? Capacity - 1: (mStart - 1) % Capacity;
      mArray[mStart] = value;
      Count++;
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
   /// <summary>Resizes array to n times size.
   /// Elements are copied into new array from index Capacity/4 to index Capacity - Capacity/4 
   /// to leave space for enqueue operations. Queue is resized everytime either front of queue
   /// or back of queue runs out of space.</summary>
   void Resize (double n) {
      T[] temp = new T[Capacity * 2];
      int i = 0, tIn = Capacity / 2;
      Capacity *= 2;
      // 
      while (i < Count) {
         temp[tIn] = mArray[(mStart + i++) % Count];
         tIn = (tIn + 1) % Capacity;
      }
      mArray = temp;
      mStart = Capacity / 4;
      mEnd = Capacity - Capacity / 4;
   }
   #endregion

   #region Private Data ---------------------------------------------
   T[] mArray;
   int mStart, mEnd;
   #endregion
}
#endregion