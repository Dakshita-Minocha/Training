// ------------------------------------------------------------------------------------------------
// Training ~ DriveA training program for new joinees at Metamation, Batch- July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------
// Program.cs
// Program to implement a file name parser using state machines.
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

      static void Validate (string path) {
         WriteLine (Path.PathParse (path, out (string, string, string, string, string) ActOutput) + "\t" + ActOutput);
      }
      //Path fp = new ("C:\\WorkGIT\\Dakshita\\Training.sln");
      //WriteLine (fp);
      //WriteLine (fp.FilePath);
      //Path p = new ("suppppp");
      //WriteLine (p.FilePath);
      //if (Path.PathParse ("C:/words/words.txt", out (string drive, string dir, string path, string filename, string ext) filepath)) {
      //   WriteLine (filepath);
      //} else { WriteLine ("Invalid path"); }
   }
}

#region class Path --------------------------------------------------------------------------
public class Path {
   #region Constructors ------------------------------------------
   public Path (string path) => mPath = path.Trim ().ToLower ();
   #endregion

   #region Properties ------------------------------------------
   public (string Drive, string Dir, string Path, string Filename, string Ext) FilePath {
      get {
         if (mComputed)
            return mFilePath;
         else {
            mValid = PathParse (mPath, out (string drive, string dir, string path, string filename, string ext) f);
            mFilePath =  mValid? f : ("", "", "", "", "");
            mComputed = true;
            return mFilePath;
         }
      }
   }
   string mPath;
   (string drive, string dir, string path, string filename, string ext) mFilePath;
   bool mComputed = false;

   public bool IsValid => mValid;
   bool mValid = true;
   #endregion

   #region Method ------------------------------------------------
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
         path = string.Join("", path.Replace ("\\", "/").Skip(1));
         string[] parts = path.Split ('/');
         fileName = parts[^1] + ext;
         path = string.Join ("/", parts.SkipLast (1));
         filePath = (drive, dir, path, fileName, ext);
         return true;
      }
      return false;
   }
   public override string ToString () => $"{(IsValid ? $"FileName: {FilePath.Filename}\nDrive: {FilePath.Drive}\nDirectory: {FilePath.Dir + FilePath.Path}\n" : $"Invalid Path {mPath}")}";
   #endregion
}
#endregion
enum EState { DriveA, DriveB, DriveC, DirA, PathA, FileA, End, Err };
