using System.IO;
using System.Text.Json;
class Program
{
    static void Main(string[] args)
    {
        string fileName = "Person.json";
        if (File.Exists(fileName))
        {
            Console.WriteLine("It exists");
        }
        else
        {
            Console.WriteLine("It does not exist");
            Console.WriteLine("Creating the file");
            File.Create(fileName);
            //File.WriteAllText(fileName,"[{'name': 'bhagvan
       }
    }
}