

using System;
class Task2 {
  static void Main() {
    int size = 0;
    while (size <= 0 || size > 20){
        Console.WriteLine("enter size of a sequence (0, 20]");
        size = int.Parse(Console.ReadLine());
    }
    
    int[] sequence = new int [size];
    Console.WriteLine("enter " + size + " values");
    for(int i = 0; i < size; i++){
        sequence[i] = int.Parse(Console.ReadLine());
    }
    
    int min = sequence[0];
    for(int i = 1; i < size; i++){
        if(min > sequence[i]){
            min = sequence[i];
        }
    }
    Console.WriteLine("min = " + min);
  }
}
