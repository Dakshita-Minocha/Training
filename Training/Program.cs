// ------------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement a file name parser using a Mealy State Machine.
// ------------------------------------------------------------------------------------------------
using System.Runtime.CompilerServices;
using static System.Console;
using static Training.PathParser.EState;

[assembly: InternalsVisibleTo ("TestTraining")]
namespace Training;

class Program {
   static void Main (string[] args) {
      Dictionary<string, (string, string, string, string, string)> validPaths = new () {
         { "C:\\WorkGIT\\Dakshita\\Training.sln", ("c", "workgit", "dakshita", "training.sln", ".sln")},
         { "C:/words/words.txt", ("c", "words", "", "words.txt", ".txt")}
      };
      string[] invalidPaths = { "suppppp", "Ca:/workgit/hjh.txt", "c:\\Dakshita123.md", "C:\\workgit\\dakshita", "c:/dakshita.txt" };
      foreach (var kvp in validPaths)
         Validate (kvp.Key);
      foreach (string path in invalidPaths)
         Validate (path);

      static void Validate (string path) =>
         WriteLine (PathParser.PathParse (path, out (string, string, string, string, string) ActOutput) + "   " + ActOutput);
   }
}

#region class PathParser --------------------------------------------------------------------------
public class PathParser {
   #region Constructors ---------------------------------------------
   /// <summary>Creates new instance of a filepath</summary>
   public PathParser (string path) => mInput = path.Trim ().ToLower ();
   string mInput;
   #endregion

   #region Properties -----------------------------------------------
   /// <summary>If path is valid, returns components of a file's path, else returns empty strings.</summary>
   public (string Drive, string Dir, string Path, string Filename, string Ext) FilePath {
      get {
         // FilePath is computed only once for 1 instance of class (lazy evaluation).
         if (!mComputed) Compute ();
         return mFilePath;
      }
   }
   (string Drive, string Dir, string Path, string Filename, string Ext) mFilePath;
   bool mComputed = false;

   /// <summary>Returns if current instance of PathParser is valid.</summary>
   public bool IsValid {
      get {
         _ = FilePath;
         return mValid;
      }
   }
   bool mValid = false;
   #endregion

   #region Method ---------------------------------------------------
   /// <summary>Parses through input path to sort components if valid and returns true and false otherwise.</summary>
   /// <param name="input">input file path</param>
   /// <param name="filePath">Output components of path: Drive, Directory, PathParser (Drive + Directory), Filename and Extension.</param>
   /// See file://FileParser_BNF.png
   public static bool PathParse (string input, out (string Drive, string Dir, string Path, string Filename, string Ext) filePath) {
      EState s = DriveA;
      Action none = () => { }, todo;
      string path = "", dir = "", drive = "", fileName = "", ext = ".";
      foreach (var ch in input.Trim ().ToLower () + '~') {
         (s, todo) = (s, ch) switch {
            (DriveA, >= 'a' and <= 'z') => (DriveB, () => drive += ch),
            (DriveB, ':') => (DriveC, none),
            (DriveC, '/' or '\\') => (DirA, none),
            (DirA, >= 'a' and <= 'z') => (DirA, () => dir += ch),
            (DirA, '/' or '\\') => (PathA, () => path += ch),
            (PathA, >= 'a' and <= 'z') => (PathA, () => path += ch),
            (PathA, '/' or '\\') => (PathA, () => path += ch),
            (PathA, '.') => (FileA, none),
            (FileA, >= 'a' and <= 'z') => (FileA, () => ext += ch),
            (FileA, '~') => (End, none),
            _ => (Err, none),
         };
         todo ();
      }
      if (s != End) {
         filePath = ("", "", "", "", "");
         return false;
      }
      path = string.Join ("", path.Replace ("\\", "/").Skip (1));
      string[] parts = path.Split ('/');
      fileName = parts[^1] + ext;
      path = dir + '/' + string.Join ("/", parts.SkipLast (1));
      filePath = (drive, dir, path, fileName, ext);
      return true;
   }

   public override string ToString () => $"{(IsValid ? $"FileName: {FilePath.Filename}{NL}" +
                                                       $"Drive: {FilePath.Drive}{NL}" +
                                                       $"Directory: {FilePath.Dir}{NL}" +
                                                       $"File Path: {FilePath.Path}{NL}" : $"Invalid Path {mInput}")}";
   #endregion

   #region Implementation -------------------------------------------
   /// <summary>Computes FilePath using static function and sets mComputed = true.</summary>
   void Compute () {
      mValid = PathParse (mInput, out (string Drive, string Dir, string Path, string Filename, string Ext) f);
      mFilePath = mValid ? f : ("", "", "", "", "");
      mComputed = true;
      Computations++;
   }

   /// <summary> Keeps track of number of times PathParse is called to check working of lazy evaluation.</summary>
   internal int Computations { get; private set; }
   #endregion

   #region Private Data ---------------------------------------------
   static readonly string NL = Environment.NewLine;
   #endregion

   #region Enum -----------------------------------------------------
   internal enum EState { DriveA, DriveB, DriveC, DirA, PathA, FileA, End, Err };
   #endregion
}
#endregion