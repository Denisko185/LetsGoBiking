using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace RoutingHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Routing.RoutingWS)))
            {
                host.Open();
                Console.WriteLine("The service is ready at {0}", host.BaseAddresses[0]);
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
