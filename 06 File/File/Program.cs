using System;

namespace File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter 1 to show data\n" +
                    "Enter 2 to enter data and add it to file\n" +
                    "Enter 0 to close");
                string choice = Console.ReadLine();
                if (choice == "0") 
                    break;
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("1");
                        break;
                    case "2":
                        Console.WriteLine("2");
                        break;
                    default: break;
                }
            }
        }
    }
}
