using EvalServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost
{
    public class Program
    {
        static void Main(string[] args)
        {

            var host = new ServiceHost(typeof(EvalService));
            host.AddServiceEndpoint(typeof(IEvalService), new BasicHttpBinding(), "http://localhost:8080/Evals/basic");
            host.AddServiceEndpoint(typeof(IEvalService), new WSHttpBinding(), "http://localhost:8080/Evals/ws");
            host.AddServiceEndpoint(typeof(IEvalService), new NetTcpBinding(), "net.tcp://localhost:8081/Evals/");



            

            try
            {
                host.Open();
                PrintServiceInfo(host);
                var evalService = new EvalService();
                var eval = new Eval()
                {
                    Submitter = "Chuck Norris",
                    TimeSent = DateTime.Now,
                    Comment = "It Works!"
                };
                evalService.SubmitEval(eval);
                var evalList = new List<Eval>();
                evalList = evalService.GetEvals();
                if (evalList != null)
                {
                    foreach (var e in evalList)
                    {
                        Console.WriteLine("Submitted Evaluations");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine($"Submitter: {e.Submitter} Time: {e.TimeSent}");
                        Console.WriteLine($"Comment: {e.Comment}");
                        Console.WriteLine("---------------------------------------------");


                    }
                }
                host.Close();

            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                host.Abort();
            }
            Console.ReadLine();

        }

        private static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine($"Service Info: {host.Description.Name} {host.State.ToString()}!");
            foreach (var endpoint in host.Description.Endpoints)
            {
                
                Console.WriteLine($"{endpoint.Name}: {endpoint.Address}");
                
            }
            

        }
    }
}
