using EvalServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace svcUtilExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ChannelFactory<IEvalService>("http");

            IEvalService channel = factory.CreateChannel();
            var eval = new Eval() { Comment = "Hallå ja", Submitter = "Dallas", TimeSent = DateTime.Now };
            channel.SubmitEval(eval);

            Console.WriteLine("Success!");
            var doneEval = channel.GetEvals();
            foreach (var e in doneEval)
            {
                Console.WriteLine($"{e.Submitter} {e.TimeSent}");
                Console.WriteLine($"{e.Comment}");
                Console.WriteLine("--------------------------");

            }
            Console.ReadKey();
            factory.Close();
        }
    }
}
