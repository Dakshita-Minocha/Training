// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.                                                
// ------------------------------------------------------------------
// Program.cs                                                                     
// Program to implement a custom MyStack<T> class using arrays as the underlying data structure.
// The MyStack<T> should start with an initial capacity of 4 and double its capacity when needed. 
// ------------------------------------------------------------------------------------------------
using Classlib;
using static System.Console;
namespace Demo;

class Program {
   static void Main (string[] args) {
      MyStack<int> stack = new ();
      Write ("--Pushing to stack: 1 2 3 4");
      stack.Push (1);
      stack.Push (2);
      stack.Push (3);
      stack.Push (4);
      WriteLine ($"\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
      stack.Push (5); stack.Push (6);
      WriteLine ($"--Pushing: 5 6\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
      WriteLine ($"--Popping: {stack.Pop ()}\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
      WriteLine ($"--Popping: {stack.Pop ()}\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
      WriteLine ($"--Peeking: {stack.Peek ()}\nCount: {stack.Count}\nCapacity: {stack.Capacity}");
   }
}
