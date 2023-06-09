using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();
            Queue<int> evenNumbers = new Queue<int>();
            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                    evenNumbers.Enqueue(num);
            }
            while (evenNumbers.Count > 0)
            {
                Console.Write($"{evenNumbers.Dequeue()}");
                if (evenNumbers.Count != 0)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}