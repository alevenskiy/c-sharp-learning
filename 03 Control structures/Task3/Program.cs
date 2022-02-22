using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int value = int.Parse(Console.ReadLine());

            bool flag = false;

            if (value > 0) {
                int count = 2;

                while (count < value) 
                {
                    if(value % count == 0)
                    {
                        flag = true;
                        break;
                    }
                    else count++;
                }
                if(flag) Console.WriteLine("Not a Prime");
                else Console.WriteLine("Prime");  
            }
            else Console.WriteLine("Not a Prime");
        }
    }
}
