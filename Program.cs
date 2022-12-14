using System.Text;
using System.Text.RegularExpressions;

int counter = 0;
StringBuilder sb = new StringBuilder();

System.Console.WriteLine(@"Enter the path of the Whatsapp Chat you would like to fix the date for:");

string? path = System.Console.ReadLine();
string? filename = Path.GetFileNameWithoutExtension(path);
string? directory = Path.GetDirectoryName(path);


if (!string.IsNullOrEmpty(path))
{
    // Read the file and display it line by line.  
    foreach (string line in System.IO.File.ReadLines(path))
    {
        if (line.Length > 10 && line.Substring(4, 1).Equals(@"/"))
        {
            string sDate = line.Substring(0, 10);
            string rest = line.Substring(10, line.Length - 10);

            string newLine = $"{sDate.Substring(8, 2)}/{sDate.Substring(5, 2)}/{sDate.Substring(0, 4)}{rest}";
            sb.AppendLine(newLine);
        }
        else
            sb.AppendLine(line);

        counter++;
    }

    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Path.Combine(directory, filename + " - DateFixed.txt")))
    {
        file.WriteLine(sb.ToString());
    }
}

System.Console.WriteLine("There were {0} lines.", counter);
System.Console.WriteLine("New file contains {0} lines.", Regex.Matches(sb.ToString(), Environment.NewLine).Count);
// Suspend the screen.  
System.Console.ReadLine();