// ------------------------------------------------------------------------------------------------
// Training ~ DriveA training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement a file name parser using a Mealy State Machine.
// ------------------------------------------------------------------------------------------------
using static System.Console;
using static Training.EState;
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
         WriteLine (Path.PathParse (path, out (string, string, string, string, string) ActOutput) + "\t" + ActOutput);

      //Path fp = new ("C:\\WorkGIT\\Dakshita\\Training.sln");
      //WriteLine (fp);
      //WriteLine (fp.FilePath);
   }
}

#region class Path --------------------------------------------------------------------------
public class Path {
   #region Constructors ------------------------------------------
   /// <summary>Creates new instance of a filepath</summary>
   public Path (string path) => mPath = path.Trim ().ToLower ();
   #endregion

   #region Properties ------------------------------------------
   /// <summary>If path is valid, returns components of a file's path, else returns empty strings.</summary>
   public (string Drive, string Dir, string Path, string Filename, string Ext) FilePath {
      get {
         // FilePath is computed only once for 1 instance of class (lazy evaluation).
         if (mComputed)
            return mFilePath;
         else {
            mValid = PathParse (mPath, out (string drive, string dir, string path, string filename, string ext) f);
            mFilePath = mValid ? f : ("", "", "", "", "");
            mComputed = true;
            nComputations++;
            return mFilePath;
         }
      }
   }
   string mPath;
   (string drive, string dir, string path, string filename, string ext) mFilePath;
   bool mComputed = false;

   /// <summary>Returns if current instance of Path is valid.</summary>
   public bool IsValid {
      get {
         if (mComputed) return mValid;
         else {
            mValid = PathParse (mPath, out (string drive, string dir, string path, string filename, string ext) f);
            mFilePath = mValid ? f : ("", "", "", "", "");
            mComputed = true;
            nComputations++;
            return mValid;
         }
      }
   }
   bool mValid = false;

   /// <summary> Keeps track of number of times PathParse is called to check working of lazy evaluation.</summary>
   public int nComputations { get; private set; }
   #endregion

   #region Method ------------------------------------------------
   /// <summary>Parses through input path to sort components if valid and returns true and false otherwise.</summary>
   /// <param name="input">input file path</param>
   /// <param name="filePath">Output components of path: Drive, Directory, Path (Drive + Directory), Filename and Extension.</param>
   /// See file://FileParser_BNF.png
   public static bool PathParse (string input, out (string Drive, string Dir, string Path, string Filename, string Ext) filePath) {
      EState s = DriveA;
      Action none = () => { }, todo;
      filePath = ("", "", "", "", "");
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
      if (s == End) {
         path = string.Join ("", path.Replace ("\\", "/").Skip (1));
         string[] parts = path.Split ('/');
         fileName = parts[^1] + ext;
         path = dir + '/' + string.Join ("/", parts.SkipLast (1));
         filePath = (drive, dir, path, fileName, ext);
         return true;
      }
      return false;
   }

   public override string ToString () => $"{(IsValid ? $"FileName: {FilePath.Filename}\nDrive: {FilePath.Drive}\nDirectory: {FilePath.Dir}\nFile Path: {FilePath.Path}\n" : $"Invalid Path {mPath}")}";
   #endregion
}
#endregion
enum EState { DriveA, DriveB, DriveC, DirA, PathA, FileA, End, Err };
