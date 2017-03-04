using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;
using Dto;

namespace WcfServer.Interfaces
{
    [ServiceContract]
    [ServiceKnownType(typeof(User))]
    public interface IUserInboundMessageHandlerService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void ProcessIncomingMessage(MsmqMessage<User> incomingOrderMessage);
    }
}
