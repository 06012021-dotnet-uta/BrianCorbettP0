using System;

namespace my_first_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your age:");
            string age = Console.ReadLine();
            Console.WriteLine($"Your name is {name} and you are {age} years old.");
        }
    }
}
