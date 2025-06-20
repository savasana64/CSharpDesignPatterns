﻿using System.Diagnostics;
using static System.Console;


namespace DotNetDesignPatternDemos.SOLID.SRP
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

            // breaks single responsibility principle
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }

    // handles the responsibility of persisting objects
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }
    public class Demo
{
   static void Main(string[] args)
   {
          var j = new Journal();
          j.AddEntry("I cried today");
          j.AddEntry("I ate a bug");
          WriteLine(j);

          var p = new Persistence();
          var filename = @"d:\temp\journal.txt";
          p.SaveToFile(j, filename);
          Process.Start(new ProcessStartInfo   //opens the joutnal in the default text editor
          {
            FileName = filename,
            UseShellExecute = true
          });//
        }
  }
}