using System.Text;

int counter = 0;  
StringBuilder sb = new StringBuilder();
  
// Read the file and display it line by line.  
foreach (string line in System.IO.File.ReadLines(@"C:\Users\louis\Downloads\WhatsApp Chat with Michael Harris.txt"))
{  
    if (line.Length > 10 && line.Substring(4, 1).Equals(@"/"))
    {
        string sDate = line.Substring(0, 10);
        string rest = line.Substring(10, line.Length - 10);

        string newLine = $"{sDate.Substring(8, 2)}/{sDate.Substring(5, 2)}/{sDate.Substring(0, 4)}{rest}";
        sb.AppendLine(newLine);
    }
    else
        sb.Append(line);

    counter++;  
}  

using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\louis\Downloads\WhatsApp Chat with Michael Harris - DateFixed.txt"))
{
    file.WriteLine(sb.ToString());
}

System.Console.WriteLine("There were {0} lines.", counter);  
// Suspend the screen.  
System.Console.ReadLine();  