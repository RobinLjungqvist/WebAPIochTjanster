using ClientExercise1.SoapService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new addSoapClient();

            double time;
            int sum = client.add(5, 5, out time);

            Console.WriteLine("Sum: " + sum + " it took: " + time + "ms");
            Console.ReadKey();

        }
    }
}
