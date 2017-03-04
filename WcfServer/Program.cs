using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(UserInboundMessageHandlerService));
            host.Faulted += host_Faulted;

            host.Open();
            Console.WriteLine("The service is ready");
            Console.WriteLine("Press <ENTER> to terminate the service");
            Console.ReadLine();

            if (host != null)
            {
                if (host.State == CommunicationState.Faulted)
                {
                    host.Abort();
                }
                host.Close();
            }
        }

        static void host_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Faulted!"); // Change to something more sensible – this is just an example showing what happens when the host has faulted.
        }
    }
}
