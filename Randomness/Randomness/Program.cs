using System;
using System.Net.NetworkInformation;

namespace Randomness
{
    class Program
    {
        public static void getRandomStudent()
        {
            Random random = new Random();

            string[] students = [
                "Aman",
                "Gaurav",
                "Kirtan",
                "Dhaval",
                "Dharmik",
                "Mayank",
                "Bhagvan",
                "Vaibhav",
                "Gopal",
                "Jyoti",
                "Krishna",
                "Taniksha",
                "Neha",
                "Khushbu",
                "Pal",
                "Vishwapal",
                "Arpit",
                "Daivik",
                "Sidhhant"
                ];
            int i = random.Next(students.Length);
            Console.WriteLine(students[i]);
        }
        public static void Main(string[] args)
        {
            Random random = new Random();
            Console.WriteLine(random.NextInt64(100));
            getRandomStudent();
        }
    }
}