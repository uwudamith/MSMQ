using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace MSMQ
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                WriteToQueue();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        /// <summary>
        /// References : Thanks to below URLs
        /// http://www.dotnetcurry.com/wcf/1156/using-wcf-msmq-message-service-oriented-solutions
        /// 
        /// </summary>
        public static void WriteToQueue()
        {
            int i = 1;

            while (true)
            {
                Console.WriteLine("Creating new user");

                var user = new Dto.User()
                {
                    UserId = i,
                    FirstName = "Damith" + i,
                    LastName = "Wanninayake" + i,
                    Email = "damith.uwu@gmail.com",
                    UserName = "damith" + i
                };


                // Create a Message and set the body to the order object above
                var msmqPath = ConfigurationManager.AppSettings["MessageQueuePath"];
                var msg = new Message {Body = user};

                // Create a transaction
                using (var ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    MessageQueue queue = null;

                    if (MessageQueue.Exists(msmqPath))
                    {
                        queue = new MessageQueue(msmqPath);
                    }
                    else
                    {
                        // Create transactional message queue
                        MessageQueue.Create(msmqPath, true);
                        queue = new MessageQueue(msmqPath);
                    }
                    queue.Send(user,"User registration",MessageQueueTransactionType.Automatic); // send the message
                    ts.Complete(); // complete the transaction
                }

                i += 1;
                Console.WriteLine("Message Sent");

                Thread.Sleep(5000);
            }
            
        }

    }
}
