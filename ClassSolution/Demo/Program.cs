// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement a Queue<T> using arrays as the underlying data structure.
// The queue should grow the queue when needed (like the TStack above does).
// If the queue does not have to be grown, both Enqueue and Dequeue should be
// constant time (O(1)) operations.Throw exceptions as needed.
// class MyQueue<T> {
//    public void Enqueue (T a) { }
//    public T Dequeue () { }
//    public T Peek () { }
//    public bool IsEmpty { get; }
// }
// InvalidOperationException: This exception should be thrown when attempting to dequeue or peek an empty queue.
// ------------------------------------------------------------------------------------------------
using Classlib;
using static System.Console;
namespace demo;

#region class Program ------------------------------------------------------------------------
internal class Program {
   #region Method ----------------------------------------------
   static void Main (string[] args) {
      WriteLine ("Implementing Queues (First in - First Out) using arrays: ");
      MyQueue<int> queue = new ();
      queue.Enqueue (1);
      queue.Enqueue (2);
      queue.Enqueue (3);
      queue.Enqueue (4);
      queue.Dequeue ();
      queue.Dequeue ();
      WriteLine (queue);
      queue.Enqueue (5);
      queue.Enqueue (6);
      queue.Enqueue (7);
      queue.Enqueue (8);
      queue.Dequeue ();
      queue.Dequeue ();
      WriteLine (queue);
      queue.Dequeue ();
      WriteLine (queue);
      queue.Enqueue (8);
      queue.Enqueue (9);
      WriteLine (queue);
   }
   #endregion
}
#endregion