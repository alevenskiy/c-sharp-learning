using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Consultant consultant = new Consultant();
                Console.WriteLine();
                Console.WriteLine("press 1 to show Client Info");
                Console.WriteLine("press 2 to change the Phone Number");
                Console.WriteLine("press 0 to exit");
                switch (Console.ReadLine())
                {
                    case "1": Console.WriteLine(); consultant.ShowClient(); break;
                    case "2": Console.WriteLine(); consultant.PhoneNumberChange(); break;
                    case "0": return;
                }
            }
        }
    }
}