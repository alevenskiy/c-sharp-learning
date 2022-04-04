using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            Console.WriteLine("input number");
            string str;
            while ((str = Console.ReadLine()) != "")
            {
                if(set.Add(str))
                    Console.WriteLine(str + " added to set\n");
                else
                    Console.WriteLine(str + " is already in set\n");
                Console.WriteLine("input number");
            }
        }
    }
}
