// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement a custom MyList<T> class using arrays as the underlying data structure.
// The MyList<T> should start with an initial capacity of 4 and double its capacity when needed.
// ------------------------------------------------------------------------------------------------
using Classlib;
using static System.Console;
namespace Demo;

public class Program {
   #region Method ---------------------------------------------------
   static void Main (string[] args) {
      MyList<int> list = new ();
      list.Add (3);
      list.Add (2);
      list.Add (1);
      list.Add (2);
      list.Add (3);
      list.Add (4);
      list.Add (-5);
      list.Add (112);
      list.Add (29);
      WriteLine ($"Added 3 2 1 2 3 4 -5 112 29 to list\nlist.Count: {list.Count} list.Capacity: {list.Capacity}");
      list[2] = 5;
      WriteLine ($"\nEntering value 5 at index 2");
      list.Remove (4);
      list.Remove (29);
      WriteLine ($"Remove 4 29   list.Count: {list.Count} list.Capacity: {list.Capacity}");
      Write ("Current list: ");
      for (int i = 0; i < list.Count; i++) Write ($"{list[i]} ");
      list.Insert (3, 5);
      WriteLine ($"\n\nlist.Insert (3, 5): list.Count: {list.Count} list.Capacity: {list.Capacity}");
      list.RemoveAt (4);
      WriteLine ($"list.RemoveAt (4): list.Count: {list.Count}");
      Write ("Current list: ");
      for (int i = 0; i < list.Count; i++) Write ($"{list[i]} ");
      list.Clear ();
      WriteLine ($"\n\nlist.Clear (); list.Count: {list.Count}");
      Write ("Current list: ");
      for (int i = 0; i < list.Count; i++) Write ($"{list[i]} ");
      WriteLine ();
   }
   #endregion
}