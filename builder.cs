using System.Text;
using static System.Console;
public class Demo
{

    //we áre going to create a html paragraph
    static void Main(string[] args)
    {
        var hello = "hello";

        //now use the stringbuilder of .net
        //we are now using a low lwvwl builder taht builds strings
        var sb = new StringBuilder();
        sb.Append("<p>");
        sb.Append(hello);
        sb.Append("</p>");
        WriteLine(sb);

        var words = new[] { "Hello", "world" };
        sb.Clear();
        sb.Append("<ul>");
        foreach (var word in words)
        {
            sb.AppendFormat("<li>{0}</li>" , word);
        }

        sb.Append("</ul>");
        WriteLine(sb);

    }
}