using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int nOfStrings = int.Parse(Console.ReadLine());
            for (int i = 0; i < nOfStrings; i++)
            {
                Box<string> box = new Box<string>(Console.ReadLine());
                Console.WriteLine(box);
            }
        }
    }
}