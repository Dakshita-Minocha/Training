// ---------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ---------------------------------------------------------------------------
// Program.cs                                                                     
// Program to implement a custom MyList<T> class using arrays as the underlying data structure.
// The MyList<T> should start with an initial capacity of 4 and double its capacity when needed. 
// ---------------------------------------------------------------------------------------
using static System.Console;

namespace Training {
   #region class Program ------------------------------------------------------------------------
   internal class Program {
      #region Method ----------------------------------------------
      static void Main () {
         MyList<int> list = new ();
         list.Add (3);  // index 0, count = 1
         list.Add (2);
         list[2] = 5;  // index 2
         list.Add (2);
         list.Add (3);
         list.Add (4);
         list.Add (-5);
         list.Add (112);  // index 7, count = 8
         list.Add (29);  // index 8 -> list resizes to double capacity
         list.Remove (4);  // list resizes to half previous capacity
         list.Remove (29);  // count - 1, count = 7
         list.Insert (3, 5);  // count = 8
         WriteLine ($"list.Insert (3, 5): list.Count: {list.Count}");
         WriteLine ($"list.Insert (3, 5): list.Capacity: {list.Capacity}");
         list.RemoveAt (4); // count = 7
         WriteLine ($"list.RemoveAt (4): list.Count: {list.Count}");
         list.Clear ();
         WriteLine ($"list.Clear (); list.Count: {list.Count}");
         //foreach (var i in list) WriteLine (i);  // Does not have GetEnumerator
         //MyList<char> list1 = new () { 'a', 'b', 'c', 'd' }; // Does not work because we have not implemented System.Collections.IEnumerable
      }
      #endregion
   }
   #endregion

   #region class MyList -------------------------------------------------------------------------
   public class MyList<T> {
      #region Method ----------------------------------------------
      int _count = 0, _capacity = 4;
      T[] array = null;

      public MyList () => array = new T[_capacity];

      /// <summary> Number of non-null elements in list </summary>
      public int Count => _count;

      /// <summary> Current max capacity of list </summary>
      public int Capacity => _capacity;

      /// <summary> Allows user to acces elements by specifying index within index specifiers: list[index] </summary>
      /// <param name="index"> Specified Index </param>
      /// <returns> Value of element in list at index </returns>
      /// <exception cref="IndexOutOfRangeException"> If specified Index is out of range [0, Count) </exception>
      public T this[int index] {
         get {
            try {
               return array[index];
            } catch (IndexOutOfRangeException) {
               throw new IndexOutOfRangeException ("Index " + (index > _capacity ? "> " : "< ") + "Capacity.");
            }
         }
         set {
            try {
               array[index] = value;
               _count = index + 1;
            } catch (IndexOutOfRangeException) {
               throw new IndexOutOfRangeException ("Index " + (index > _capacity ? "> " : "< ") + "Capacity.");
            } catch (Exception ex) {
               WriteLine (ex.Message);
            }
         }
      }

      /// <summary> Adds {value} to end of current list </summary>
      /// <exception cref="IndexOutOfRangeException"> If specified Index is out of range [0, Count) </exception>
      public void Add (T value) {
         try {
            array[_count] = value;
            _count++;                     // Incrementing separately as it skips next element in case of resizing
         } catch (IndexOutOfRangeException) {
            Resize (2);
            array[_count++] = value;
         }
      }

      /// <summary> Removes first instance of given value </summary>
      /// <param name="value"> Value to be removed from list </param>
      /// <returns> true if Value has been removed </returns>
      /// <exception cref="InvalidOperationException"> If value does not exist in list </exception>
      public bool Remove (T value) {
         if (!array.Any (x => x.Equals (value)))
            throw new InvalidOperationException ($"{value} does not exist in {array}");
         int index = Array.IndexOf (array, value);
         for (int i = 0, count = 0; i < _count; i++)
            if (i != index) array[count++] = array[i];
         array[--_count] = default;
         if (_count <= _capacity / 2) Resize (0.5);
         return true;
      }

      /// <summary> Clears all elements of list </summary>
      public void Clear () {
         _count = 0;
         array = new T[_capacity];
      }

      /// <summary> Inserts element in array at specified index. </summary>
      /// <param name="index"> Index value at which element is to be inserted. </param>
      /// <param name="value"> Values of element </param>
      /// <exception cref="Exception"> If specified Index is out of range [0, Count) </exception>
      public void Insert (int index, T value) {
         try {
            T[] temp = array.ToArray ();
            for (int count = 0, i = 0; count < _count + 1; count++)
               if (count != index) {
                  if (count == _capacity) Resize (2);
                  array[count] = temp[i++];
               }
            array[index] = value;
            _count++;
         } catch (IndexOutOfRangeException) {
            throw new IndexOutOfRangeException ();
         }
      }

      /// <summary> Remove element at specified index </summary>
      /// <param name="index"> Specified index </param>
      /// <exception cref="IndexOutOfRangeException"> if specified index is out of range [0, Count) </exception>
      public void RemoveAt (int index) {
         try {
            for (int i = 0, count = 0; i < _count; i++)
               if (i != index) array[count++] = array[i];
            array[--_count] = default;
            if (_count <= _capacity / 2) Resize (0.5);
         } catch (IndexOutOfRangeException) {
            throw new IndexOutOfRangeException ();
         }
      }

      /// <summary> Resizes Array to double current capacity </summary>
      void Resize (double multiplier) {
         _capacity = (int)(_capacity * multiplier);
         Array.Resize (ref array, _capacity);
      }
      #endregion
   }
   #endregion
}