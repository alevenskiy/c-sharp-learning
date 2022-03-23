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

        static int getLastID(string filename)
        {
            int id = 0;
            string readLine;
            using (StreamReader sr = new StreamReader(filename))
            {
                while ((readLine = sr.ReadLine()) != null)
                {
                    string[] splittedLine = readLine.Split('#');
                    id = Convert.ToInt32(splittedLine[0]);
                }
            }
            return id;
        }

        static void addLineToFile(string line, string fileName)
        {
            int id = 0;
            string date = DateTime.Now.ToString("dd.MM.yyyy HH:mm");

            FileInfo f = new FileInfo(fileName);
            if (f.Exists)
                id = getLastID(fileName);
            id++;

            string writeLine = id.ToString() + "#" + date + "#" + line;

            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine(writeLine);
            }
        }

        static string enterData()
        {
            Console.WriteLine("enter Surname Name SecondName");
            StringBuilder line = new StringBuilder(Console.ReadLine());
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
