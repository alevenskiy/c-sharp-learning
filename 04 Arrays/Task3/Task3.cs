using System;
class Task3
{
    static void Main()
    {
        int max = 0;
        while (max <= 0)
        {
            Console.WriteLine("enter max of a value (only positive)");
            max = int.Parse(Console.ReadLine());
        }

        Random rand = new Random();
        int answer = rand.Next(max);
        bool flag = true;
        Console.WriteLine("try to guess the Secret Number");
        while (flag)
        {
            string quest = Console.ReadLine();
            if (quest == "")
            {
                flag = false;
            }
            else
            {
                int value = int.Parse(quest);
                if (value > answer) Console.WriteLine("" + value + " > number");
                if (value < answer) Console.WriteLine("" + value + " < number");
                if (value == answer)
                {
                    flag = false;
                    Console.Write("Yes, ");
                }
            }
        }
        Console.WriteLine("Secret Number is " + answer);
    }
}
