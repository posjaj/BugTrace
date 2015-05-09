using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JAJ.WinServer
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IMessageService
    {
        [OperationContract]
        void Login(string id);

        [OperationContract(IsOneWay = true)]
        void Update(string id);

        [OperationContract(IsOneWay = true)]
        void Leave(string id);
        
    }
    public interface ICallback
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    } 
}
