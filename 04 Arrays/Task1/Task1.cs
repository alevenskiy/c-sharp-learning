

using System;
class Task1 {
  static void Main() {
    
    int rows = 0;
    int columns = 0;
    
    while(rows  <= 0 || rows > 100){
        Console.WriteLine("enter the number of rows (0, 100]");
        rows = Convert.ToInt32(Console.ReadLine());
    }
    while(columns  <= 0 || columns > 100){
        Console.WriteLine("enter the number of columns (0, 100]");
        columns = Convert.ToInt32(Console.ReadLine());
    }
    
    int sum = 0;
    int value = 0;
    Random rand = new Random();
    
    for(int i = 0; i < columns; i++){
        for(int j = 0; j < rows; j++){
            value = rand.Next(101);
            Console.Write("{0,4:N0}", value);
            sum += value;
        }
        Console.WriteLine();
    }
    Console.WriteLine("" + sum);
  }
}
