using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, how many cards you have?");
            int count = int.Parse(Console.ReadLine());

            Console.WriteLine("Please, input nominal value of your cards");

            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                switch (Console.ReadLine())
                {
                    case "1": sum += 1; break;
                    case "2": sum += 2; break;
                    case "3": sum += 3; break;
                    case "4": sum += 4; break;
                    case "5": sum += 5; break;
                    case "6": sum += 6; break;
                    case "7": sum += 7; break;
                    case "8": sum += 8; break;
                    case "9": sum += 9; break;
                    case "10": sum += 10; break;
                    case "J": sum += 10; break;
                    case "Q": sum += 10; break;
                    case "K": sum += 10; break;
                    case "T": sum += 10; break;
                    default: Console.WriteLine("There's no card with that value"); i--; break;
                }
                Console.WriteLine("Next card please");
            }
            Console.WriteLine("Value of your hand is: " + sum);
        }
    }
}
