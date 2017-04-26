using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PersonService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PersonService : IPersonService
    {
        public static Person person;
        
        public bool ChangeAdress(string newAdress)
        {
            person.Adress = newAdress;
            return true;
        }

        public bool ChangeFirstName(string newFirstName)
        {
            person.FirstName = newFirstName;
            return true;
        }

        public bool ChangeLastName(string newLastName)
        {
            person.LastName = newLastName;
            return true;
        }

        public bool ChangePhoneNumber(int newPhoneNumber)
        {
            person.PhoneNumber = newPhoneNumber;
            return true;
        }

        public string PrintAdress()
        {
            return $"Adress: {person.Adress}, Phone: {person.PhoneNumber}";
        }

        public string PrintName()
        {
            return $"{person.FirstName} {person.LastName}";
        }
        public PersonService()
        {
            person = new Person();
            person.FirstName = "Chuck";
            person.LastName = "Norris";
            person.PhoneNumber = 037114708;
            person.Adress = "Awesome Street 5";
        }
    }
    [DataContract]
    public class Person
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Adress { get; set; }
        [DataMember]
        public int PhoneNumber { get; set; }
    }
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IPersonService
    {
        [OperationContract]
        bool ChangeFirstName(string newFirstName);
        [OperationContract]

        bool ChangeLastName(string newLastName);
        [OperationContract]

        bool ChangeAdress(string newAdress);
        [OperationContract]

        bool ChangePhoneNumber(int newPhoneNumber);

        [OperationContract]
        string PrintName();
        [OperationContract]
        string PrintAdress();
    }
}
