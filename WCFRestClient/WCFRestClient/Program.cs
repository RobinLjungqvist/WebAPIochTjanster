using EvalServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFRestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WebChannelFactory<IEvalService> cf = new WebChannelFactory<IEvalService>(
                new Uri("http://localhost:8080/EvalService"));
            IEvalService client = cf.CreateChannel();

            Console.WriteLine("Please enter one of following commands.");
            Console.WriteLine("submit");
            Console.WriteLine("get");
            Console.WriteLine("list");
            Console.WriteLine("remove");
            Console.WriteLine("exit");


            var command = Console.ReadLine();
            while (command != "Exit")
            {
                switch (command)
                {
                    case "submit":
                        Console.WriteLine("Enter comment");
                        var comment = Console.ReadLine();
                        Console.WriteLine("Enter Submitter");
                        var submitter = Console.ReadLine();
                        var eval = new Eval()
                        {
                            Comment = comment,
                            Submitter = submitter,
                            TimeSent = DateTime.Now
                        };

                        client.SubmitEval(eval);
                        Console.WriteLine("eval submitted");
                        command = null;
                        break;
                    case "get":
                        Console.WriteLine("Enter a Eval ID:");
                        var evalId = Console.ReadLine();
                        var gottenEval = client.GetEval(evalId);

                        Console.WriteLine((gottenEval != null) ? $" {gottenEval.Id}. {gottenEval.Submitter} said { gottenEval.Comment }" : "No Eval found");
                        Console.ReadLine();
                        command = null;

                        break;
                    case "list":
                        Console.WriteLine("Enter name of submitter");
                        var submitterName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(submitterName))
                        {

                            var evalsBySubmitter = client.GetEvalBySubmitter(submitterName);
                            if (evalsBySubmitter != null)
                            {
                                evalsBySubmitter.ForEach(e => Console.WriteLine($" {e.Id}. {e.Submitter} said { e.Comment }"));

                            }
                            else
                            {
                                Console.WriteLine("No Evals found by {0}", submitterName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        Console.ReadLine();
                        command = null;
                        break;
                    case "remove":
                        Console.WriteLine("Enter Id to remove Eval");
                        var idToRemove = Console.ReadLine();
                        client.RemoveEval(idToRemove);

                        break;
                    case "exit":
                        Environment.Exit(-1);
                        break;

                }
                Console.Clear();

                Console.WriteLine("Please enter one of following commands.");
                Console.WriteLine("submit");
                Console.WriteLine("get");
                Console.WriteLine("list");
                Console.WriteLine("remove");
                Console.WriteLine("exit");


                command = Console.ReadLine();
            }

        }
    }
}
