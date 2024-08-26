using System.IO;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string fileName = "Person.json";
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            Console.WriteLine(json);
        }
        else
        {
            File.Create(fileName);
        }
    }
}