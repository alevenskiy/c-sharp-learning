using System;
using System.IO;
using System.Text;

namespace File
{
    internal class Program
    {

        static void showFileData(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);

            string line;
            while ((line = sr.ReadLine()) != null)
                Console.WriteLine(line.Replace("#", " "));

            sr.Close();
        }

        static void addLineToFile(string line, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(line);
            }
        }

        static string enterData()
        {
            Console.WriteLine("enter ID");
            StringBuilder line = new StringBuilder(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Date and Time when record wa added");
            line.Append(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Surname Name SecondName");
            line.Append(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Age");
            line.Append(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Height");
            line.Append(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Birth Date");
            line.Append(Console.ReadLine());
            line.Append('#');
            Console.WriteLine("enter Birth Place");
            line.Append(Console.ReadLine());

            return line.ToString();
        }

        static void Main(string[] args)
        {
            string filename = "list.txt";
            while (true)
            {
                Console.WriteLine("\nEnter 1 to show data\n" +
                    "Enter 2 to enter data and add it to file\n" +
                    "Enter 0 to close");
                string choice = Console.ReadLine();

                if (choice == "0") 
                    break;
                
                switch (choice)
                {
                    case "1":
                        FileInfo f = new FileInfo(filename);
                        if (f.Exists)
                            showFileData(filename);
                        else 
                            Console.WriteLine("File didn't exist, add data to create file");
                        break;
                    
                    case "2":
                        addLineToFile(enterData(), filename);
                        break;
                    
                    default: break;
                }
            }
        }
    }
}
