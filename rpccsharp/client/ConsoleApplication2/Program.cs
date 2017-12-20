using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookComputing.XmlRpc;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

//namespace calculatorClient
//{

    public interface ICalculator
    {
        [XmlRpcMethod("sample.add")]
        int Add(int a, int b);

        [XmlRpcMethod("sample.subtract")]
        float Subtract(float a, float b);

        [XmlRpcMethod("sample.multiply")]
        float multiply(float a, float b);

        [XmlRpcMethod("sample.divide")]
        float divide(float a, float b);
    }

    class _
    {
        static void Main(string[] args)
        {
            HttpChannel chnl = new HttpChannel(null, new XmlRpcClientFormatterSinkProvider(), null);
            ChannelServices.RegisterChannel(chnl, false);

            ICalculator svr = (ICalculator)Activator.GetObject(
              typeof(ICalculator), "http://localhost:5656/calculator.rem");

            Console.WriteLine(svr.Add(1, 2));
           // int res =  svr.Add(1, 2);
            double test = 0;
            Console.ReadLine();
        }
    }

