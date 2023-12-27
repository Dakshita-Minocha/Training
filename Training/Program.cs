// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement a PriorityQueue<T>.
// ------------------------------------------------------------------------------------------------
using System.Collections;
using static System.Console;
namespace Training;

internal class Program {
   /// <summary>Demo using PriorityQueue</summary>
   static void Main (string[] args) {
      PriorityQueue<int> q = new () { 4, 3, 2, 1 };
      PriorityQueue<int> p = new ();
      p.Enqueue (80);
      p.Enqueue (36);
      p.Enqueue (19);
      p.Enqueue (88);
      p.Enqueue (15);
      p.Enqueue (86);
      p.Enqueue (53);
      WriteLine (p.Dequeue ());
      WriteLine (q.Dequeue ());
   }
}

#region class PriorityQueue<T> --------------------------------------------------------------------
public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T> {
   #region Constructors ---------------------------------------------
   /// <summary>Construct instance of Priority Queue<typeparamref name="T"/></summary>
   public PriorityQueue () => mList = new () { default };
   List<T> mList;
   #endregion

   #region Method ---------------------------------------------------
   /// <summary>Returns smallest element in queue</summary>
   /// <exception cref="InvalidOperationException">Throws InvalidOperationException if queue is empty</exception>
   public T Dequeue () {
      if (IsEmpty) throw new InvalidOperationException ("Count < 0");
      T returnVal = mList[1];
      Count--;
      SiftDown ();
      return returnVal;
   }

   /// <summary>Add T value to PriorityQueue</summary>
   public void Enqueue (T value) {
      mList.Add (value);
      Count++;
      SiftUp ();
   }

   /// <summary>Returns string PriorityQueue elements separated by commas</summary>
   public override string ToString () => string.Join (", ", mList.ToArray ()[1..]);
   #endregion

   #region Properties -----------------------------------------------
   /// <summary>Number of elements in Priority Queue</summary>
   public int Count { get; private set; }

   /// <summary>True if Priority Queue is Empty</summary>
   public bool IsEmpty => Count == 0;
   #endregion

   #region Implementation -------------------------------------------
   /// <summary>Sift down to re-place Dequeue-d element by smallest element in queue</summary>
   void SiftDown () {
      int child = 1;
      while (child <= Count / 2) {
         T min = mList[child * 2].CompareTo (mList[child * 2 + 1]) >= 0 ? mList[child * 2 + 1] : mList[child * 2];
         mList[child] = min;
         child = min.CompareTo (mList[child * 2]) == 0 ? child * 2 : child * 2 + 1;
      }
      mList.RemoveAt (child);
   }

   /// <summary>Sift up to place smallest element on top of heap tree</summary>
   void SiftUp () {
      int parent = Count / 2, child = Count;
      while (parent > 0 && mList[parent].CompareTo (mList[child]) == 1) {
         (mList[parent], mList[child]) = (mList[child], mList[parent]);
         (child, parent) = (parent, parent / 2);
      }
   }

   public IEnumerator<T> GetEnumerator () => mList.GetEnumerator ();

   IEnumerator IEnumerable.GetEnumerator () => mList.GetEnumerator ();

   public void Add (T x) => Enqueue (x);
   #endregion
}
#endregion