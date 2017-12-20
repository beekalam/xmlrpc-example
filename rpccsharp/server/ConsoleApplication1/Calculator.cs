using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

using CookComputing.XmlRpc;


//namespace calculatorServer
//{
    public interface ICalculator
    {
        [XmlRpcMethod("sample.add")]
        double Add(double a, double b);

        [XmlRpcMethod("sample.subtract")]
        double Subtract(double a, double b);

        [XmlRpcMethod("sample.multiply")]
        double multiply(double a, double b);

        [XmlRpcMethod("sample.divide")]
        double divide(double a, double b);
    }

    public class Calculator : MarshalByRefObject, ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double multiply(double a, double b)
        {
            return a * b;
        }

        public double divide(double a, double b)
        {
            return a / b;
        }
    }

//}
