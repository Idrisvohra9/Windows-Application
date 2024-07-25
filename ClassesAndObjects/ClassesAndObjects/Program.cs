namespace ClassesAndObjects
{
    class Program
    {
        public static void Main(string[] args)
        {
            Person person1 = new Person();
            Console.WriteLine("Enter Id: ");

            person1.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name: ");

            person1.Name = Console.ReadLine();
            Console.WriteLine("Enter Age: ");

            person1.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Id: " + person1.Id);
            Console.WriteLine("Name: "+ person1.Name);
            Console.WriteLine("Age: " + person1.Age);
        }
    }

}