using System;
using System.Collections.Generic;

namespace Task1
{
    internal class Program
    {
        static List<int> CreateAndFillList()
        {
            List<int> list = new List<int>();
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.Add(random.Next(100));
            }
            return list;
        }

        static void ShowList(List<int> list)
        {
            foreach (int item in list)
                Console.Write(item.ToString() + " ");
            Console.WriteLine();
        }

        static List<int> DeleteFromList(List<int> list)
        {
            List<int> list2 = new List<int>();
            foreach (int item in list)
            {
                if (item <= 25 || item >= 50)
                {
                    list2.Add(item);
                }
            }
            return list2;
        }

        static void Main(string[] args)
        {
            List<int> list = CreateAndFillList();

            Console.WriteLine("List Created and Filled");

            ShowList(list);

            list = DeleteFromList(list);

            Console.WriteLine("List devoid of values between 25 and 50");

            ShowList(list);
        }
    }
}
