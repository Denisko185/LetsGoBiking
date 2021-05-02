using System;
using System.ServiceModel;

namespace WebProxyServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WebProxyService.WebProxyService)))
            {
                host.Open();
                Console.WriteLine("The service is ready at {0}", host.BaseAddresses[0]);
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
