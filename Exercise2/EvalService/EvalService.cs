using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace EvalServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService: IEvalService
    {
        public EvalService()
        {
            EvalCount = 0;
        }
        List<Eval> Evals = new List<Eval>();
        

        public int EvalCount { get; set; }

        public Eval GetEval(string id)
        {
            var eval = Evals.FirstOrDefault(e => e.Id == id);
            return (eval != null) ? eval : null;
        }

        public List<Eval> GetEvalBySubmitter(string submitter)
        {
            var evals = Evals.Where(e => e.Submitter == submitter);

            return (evals.ToList().Count > 0) ? evals.ToList() : Evals.ToList();
        }

        public List<Eval> GetEvals()
        {
            return Evals;
        }

        public void RemoveEval(string id)
        {
            var eval = Evals.FirstOrDefault(e => e.Id == id);
            if(eval != null)
            {
                Evals.Remove(eval);
            }
        }

        public void SubmitEval(Eval eval)
        {
            eval.Id = EvalCount.ToString();
            EvalCount++;
            Evals.Add(eval);
        }
    }
    [DataContract(Namespace="http://localhost:8080/EvalService")]
    public class Eval
    {
        [DataMember]
        public string Submitter { get; set; }
        [DataMember]
        public DateTime TimeSent { get; set; }
        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string Id { get; set; }

    }
    [ServiceContract]
    public interface IEvalService
    {
        [OperationContract]
        [WebInvoke(Method="POST", UriTemplate="evals")]
        void SubmitEval(Eval eval);

        [OperationContract]
        List <Eval> GetEvals();
        [OperationContract]
        [WebGet(UriTemplate="eval?id={id}")]
        Eval GetEval(string id);
        [OperationContract]
        [WebGet(UriTemplate="evals?submitter={submitter}")]
        List<Eval> GetEvalBySubmitter(string submitter);
        [OperationContract]
        [WebInvoke(Method="DELETE",UriTemplate="eval?id={id}")]
        void RemoveEval(string id);
    }
}
