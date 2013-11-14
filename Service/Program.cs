using System;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Service.Contracts;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var sessionHost = new ServiceHost(typeof (StatefulService));
            sessionHost.AddServiceEndpoint(typeof (IStatefulService), new NetTcpBinding(),
                                              "net.tcp://localhost:8013/Session");
            sessionHost.Open();

            var sharedSessionHost = new ServiceHost(typeof(SharedInstanceStatefulService));
            sharedSessionHost.AddServiceEndpoint(typeof(IStatefulService), new NetTcpBinding(), "net.tcp://localhost:8012/SharedSession");
            sharedSessionHost.Open();

            Console.WriteLine("Services ready...");
            Console.WriteLine("Press <ENTER> to shut down");

            Console.ReadLine();

            sessionHost.Close();
            sharedSessionHost.Close();
        }
    }
}
