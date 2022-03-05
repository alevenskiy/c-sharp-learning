using System;
class Task1
{
    static void Main()
    {

        int rows = 0;
        int columns = 0;

        while (rows <= 0)
        {
            Console.WriteLine("enter the number of rows");
            rows = Convert.ToInt32(Console.ReadLine());
        }
        while (columns <= 0)
        {
            Console.WriteLine("enter the number of columns");
            columns = Convert.ToInt32(Console.ReadLine());
        }

        long sum = 0;
        int value = 0;
        Random rand = new Random();

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                value = rand.Next(int.MinValue, int.MaxValue);
                Console.Write($"{value,15}");
                sum += value;
            }
            Console.WriteLine();
        }
        Console.WriteLine("" + sum);
    }
}
