using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldService
{
    class HelloWorld: IHelloWorld
    {
        public string Hello(Name name)
        {
            return $"Hello, {name.FirstName} {name.LastName}!";
        }
    }
    
    [DataContract]
    public class Name
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

    }
    [ServiceContract]
    public interface IHelloWorld
    {
        [OperationContract]
        string Hello(Name name);
    }
}
