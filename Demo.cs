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
public class Demo
{
   static void Main(string[] args)
   {
          var j = new Journal();
          j.AddEntry("I cried today");
          j.AddEntry("I ate a bug");
          WriteLine(j);
   }
  }
}