using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookComputing.XmlRpc;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
//namespace calculatorServer
//{
    class _
    {
        static void Main(string[] args)
        {
            IDictionary props = new Hashtable();
            props["name"] = "MyHttpChannel";
            props["port"] = 5656;
            HttpChannel channel = new HttpChannel(
              props,
              null,
              new XmlRpcServerFormatterSinkProvider()
           );
            ChannelServices.RegisterChannel(channel, false);

            //RemotingConfiguration.Configure("calculatorServer.exe.config", false);
            RemotingConfiguration.RegisterWellKnownServiceType(
                 typeof(Calculator),
                 "calculator.rem",
                 WellKnownObjectMode.Singleton);
            Console.WriteLine("Press <ENTER> to shutdown");
            Console.ReadLine();
        }
    }
//}
