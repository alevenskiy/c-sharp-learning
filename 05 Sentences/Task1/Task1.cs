using System;
class Task1
{
    static string[] SplitSentences(string str)
    {
        return str.Split(' ');
    }

    static void Output(string[] str)
    {
        foreach (var sub in str)
        {
            Console.WriteLine(sub);
        }
    }

    static void Main()
    {
        string str = Console.ReadLine();
        Output(SplitSentences(str));
    }
}