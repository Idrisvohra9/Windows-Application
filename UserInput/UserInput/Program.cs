using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age > 18)
            {
                Console.WriteLine("You are allowed!");
            }
            else
            {
                Console.WriteLine("You are not allowed.");
            }
        }
    }
}