using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dto;
using WcfServer.Interfaces;

namespace WcfServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class UserInboundMessageHandlerService : IUserInboundMessageHandlerService
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ProcessIncomingMessage(MsmqMessage<User> incomingOrderMessage)
        {
            Console.WriteLine("New Message Recieved.. Procession Output...");
            Console.WriteLine();
            var orderRequest = incomingOrderMessage.Body;
            Console.WriteLine(orderRequest.UserId);
            Console.WriteLine(orderRequest.FirstName);
            Console.WriteLine(orderRequest.LastName);
            Console.WriteLine(orderRequest.Email);
            Console.WriteLine(orderRequest.UserName);
            Console.WriteLine();
            Console.WriteLine("Procession completed...");

            //Thread.Sleep(1000);
        }
    }
}
