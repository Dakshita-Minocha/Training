// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to implement a Queue<T> using arrays as the underlying data structure.
// The queue should grow the queue when needed (like the TStack above does).
// If the queue does not have to be grown, both Enqueue and Dequeue should be
// constant time (O(1)) operations.Throw exceptions as needed. 
// class TQueue<T> {
//    public void Enqueue (T a) { }
//    public T Dequeue () { }
//    public T Peek () { }
//    public bool IsEmpty { get; }
// }
// InvalidOperationException: This exception should be thrown when attempting to dequeue or peek an empty queue. 
// ---------------------------------------------------------------------------------------
using static System.Console;
namespace Training {

   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main (string[] args) {
         WriteLine ("Implementing Queues (First in - First Out) using arrays: ");
         TQueue<int> queue = new ();
         queue.Enqueue (1);
         queue.Enqueue (2);
         queue.Enqueue (3);
         queue.Enqueue (4);
         WriteLine ($"added 4 elements: 1 2 3 4: Count: {queue.Count} Capacity: {queue.Capacity}");
         Write ($"Remaining elements in queue: {queue}\n\n");
         queue.Enqueue (5);
         WriteLine ($"added 5th element: 5 Count: {queue.Count} Capacity: {queue.Capacity}");
         Write ($"Remaining elements in queue: {queue}\n\n");
         queue.Enqueue (6);
         queue.Enqueue (7);
         WriteLine ($"added 4 elements: 6 7: Count: {queue.Count} Capacity: {queue.Capacity}");
         Write ($"Remaining elements in queue: {queue}\n\n");
         WriteLine ($"Dequeueing first element: {queue.Dequeue ()} Count: {queue.Count} Capacity: {queue.Capacity}");
         Write ($"Remaining elements in queue: {queue}\n\n");
         WriteLine ($"Peeking at current first element in queue: {queue.Peek ()} Count: {queue.Count} Capacity: {queue.Capacity}");
         Write ($"Remaining elements in queue: {queue}\n\n");
         TQueue<int> queue1 = new ();
         try {
            // Dequeue-ing empty queue throws InvalidOperationException
            queue1.Dequeue ();
         } catch (Exception e) {
            WriteLine (e.Message);
         }
         try {
            // Peeking at empty queue throws InvalidOperationException
            queue1.Peek ();
         } catch (Exception e) {
            WriteLine (e.Message);
         }
      }
      #endregion
   }
   #endregion

   #region class MyQueue ------------------------------------------------------------------------
   public class TQueue<T> {
      #region Private Data ----------------------------------------
      static int _count, _capacity;
      static T[] queue = null;
      #endregion

      #region Public Properties -----------------------------------
      public int Count => _count;
      public int Capacity => _capacity;
      public bool IsEmpty => Count == 0;
      #endregion

      #region Method ----------------------------------------------
      public TQueue () {
         _count = 0; _capacity = 4;
         queue = new T[_capacity];
      }

      /// <summary> Add item to Queue </summary>
      public void Enqueue (T item) {
         try {
            queue[_count] = item;
            _count++;
         } catch (IndexOutOfRangeException) {
            _capacity *= 2;
            Array.Resize (ref queue, _capacity);
            queue[_count++] = item;
         }
      }

      /// <summary> Removes First-In element from Queue. </summary>
      /// <returns> First element from Queue. </returns>
      /// <exception cref="InvalidOperationException"> If Queue is Empty. </exception>
      public T Dequeue () {
         if (IsEmpty) throw new InvalidOperationException ("Cannot Dequeue: Empty Queue");
         T temp = queue[0];
         queue = queue[1..(Count + 1)];
         _count--;
         return temp;
      }

      /// <summary> Peeks at the first element in Queue without removing it. </summary>
      /// <returns> First element from Queue. </returns>
      /// <exception cref="InvalidOperationException"> If Queue is Empty </exception>
      public T Peek () {
         if (IsEmpty) throw new InvalidOperationException ("Nothing to Peek at! Empty Queue");
         return queue[0];
      }

      /// <summary> Overrides ToString() to display all elements of Queue </summary>
      /// <returns> String containing all members of Queue </returns>
      public override string ToString () {
         string s = "";
         for (int i = 0; i < Count; i++) {
            s += queue[i].ToString () + " ";
         }
         return s;
      }
      #endregion
   }
   #endregion
}