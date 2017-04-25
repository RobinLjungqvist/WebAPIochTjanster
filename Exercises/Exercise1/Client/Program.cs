using Client.HelloWorldServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new HelloWorldClient("BasicHttp");
            Console.WriteLine("Enter your first name.");
            var first = Console.ReadLine();
            Console.WriteLine("Enter your last name.");
            var last = Console.ReadLine();
            var NewName = new Name() { FirstName = first, LastName = last };
            Console.WriteLine("Loading...");
            var greeting = service.Hello(NewName);
            Console.Clear();
            Console.WriteLine(greeting);
            Console.ReadKey();
        }
    }
}
