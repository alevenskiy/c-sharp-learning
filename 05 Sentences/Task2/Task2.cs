using System;
class Task2
{

    static string[] SplitSentences(string str)
    {
        return str.Split(' ');
    }

    static string ReversWords(string input)
    {
        string[] words = SplitSentences(input);
        string output = "";
        for (int i = words.Length - 1; i >= 0; i--)
        {
            output += words[i] + " ";
        }
        return output;
    }

    static void Main()
    {
        string str = Console.ReadLine();
        Console.WriteLine(ReversWords(str));
    }
}