using System;
using System.Collections.Generic;

namespace Task2
{
    internal class Program
    {
        static Dictionary<string, string> FillTheBook()
        {
            Dictionary<string, string> book = new Dictionary<string, string>();

            Console.WriteLine("input number");
            string str;
            while ((str = Console.ReadLine()) != "")
            {
                string number = str;

                Console.WriteLine("input name");
                string name = Console.ReadLine();

                book.Add(number, name);

                Console.WriteLine("\ninput number");
            }
            return book;
        }

        static void Finder(Dictionary<string, string> book)
        {
            Console.WriteLine("input number to find");
            string number;
            while((number = Console.ReadLine()) != "")
            {
                string name;
                if (book.TryGetValue(number, out name))
                {
                    Console.WriteLine(name);
                }
                else
                    Console.WriteLine("there is no number in the book");
                Console.WriteLine("\ninput number to find");
            }
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> book = FillTheBook();

            Console.WriteLine("book is filled");

            Finder(book);
        }
    }
}
