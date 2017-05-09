using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFRestHost
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(
                typeof(EvalServiceLibrary.EvalService));
            try
            {
                host.Open();
                Console.WriteLine("Running");
                Console.ReadLine();
            }
            catch (Exception)
            {
                host.Abort();
                throw;
            }
            host.Close();
        }
    }
}
