using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the value");

            if( int.Parse(Console.ReadLine()) % 2 == 0)
                Console.WriteLine("Value is even"); 
            else
                Console.WriteLine("Value is odd");
        }
    }
}
