using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using CookComputing.XmlRpc;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace calculatorServerGUI
{
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

    public partial class Form1 : Form
    {
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        string result;
        char operation;
        HttpChannel chnl;
        ICalculator svr;
        public Form1()
        {
            InitializeComponent();
            resultTxt.Text = "";
            Stack stack = new Stack();

             chnl = new HttpChannel(null, new XmlRpcClientFormatterSinkProvider(), null);
            ChannelServices.RegisterChannel(chnl, false);

            svr = (ICalculator)Activator.GetObject(
              typeof(ICalculator), "http://localhost:5656/calculator.rem");

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.D1):
                    btn_1.PerformClick();
                    break;
                case (Keys.D2):
                    btn_2.PerformClick();
                    break;
                case (Keys.D3):
                    btn_3.PerformClick();
                    break;
                case (Keys.D4):
                    btn_4.PerformClick();
                    break;
                case (Keys.D5):
                    btn_5.PerformClick();
                    break;
                case (Keys.D6):
                    btn_1.PerformClick();
                    break;
                case (Keys.D7):
                    btn_2.PerformClick();
                    break;
                case (Keys.D8):
                    btn_3.PerformClick();
                    break;
                case (Keys.D9):
                    btn_4.PerformClick();
                    break;
                case (Keys.D0):
                    btn_5.PerformClick();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void input_handler(object sender, EventArgs e)
        {
            var btn = sender as Button;
            //resultTxt.Text += btn.Text;   
            string btntext = btn.Text;
            switch (btntext)
            {
                case "0":
                    if (resultTxt.Text != "0")
                    {
                        resultTxt.Text += "0";
                    }
                    break;
                case "1":
                    resultTxt.Text += "1";
                    break;
                case "2":
                    resultTxt.Text += "2";
                    break;
                case "3":
                    resultTxt.Text += "3";
                    break;
                case "4":
                    resultTxt.Text += "4";
                    break;
                case "5":
                    resultTxt.Text += "5";
                    break;
                case "6":
                    resultTxt.Text += "6";
                    break;
                case "7":
                    resultTxt.Text += "7";
                    break;
                case "8":
                    resultTxt.Text += "8";
                    break;
                case "9":
                    resultTxt.Text += "9";
                    break;
                case ".":
                    resultTxt.Text += ".";
                    break;
                case "AC":
                    resultTxt.Text = "";
                    break;
            }

            switch (btntext)
            {
                case "+":
                    operand1 = resultTxt.Text; 
                    operation = '+' ; 
                    resultTxt.Text = string.Empty;
                    break;
                case "-":
                    operand1 = resultTxt.Text;
                    operation = '-';
                    resultTxt.Text = string.Empty;
                    break;
                case "*":
                    operand1 = resultTxt.Text;
                    operation = '*';
                    resultTxt.Text = string.Empty;
                    break;
                case "/":
                    operand1 = resultTxt.Text;
                    operation = '/';
                    resultTxt.Text = string.Empty;
                    break;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_equal_Click(object sender, EventArgs e)
        {
            operand2 = resultTxt.Text;

            double opr1, opr2;
            double.TryParse(operand1, out opr1);
            double.TryParse(operand2, out opr2);
            //fixme to doble

            switch (operation)
            {
                case '+':
                  resultTxt.Text = svr.Add(opr1, opr2).ToString();
                    break;

                case '-':
                    resultTxt.Text = svr.Subtract(opr1, opr2).ToString();
                    break;

                case '*':
                    resultTxt.Text = svr.multiply(opr1, opr2).ToString();
                    break;

                case '/':
                    if (opr2 != 0)
                    {
                        resultTxt.Text = svr.divide(opr1, opr2).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Can't divide by zero");
                    }
                    break;
            }

            //resultTxt.Text = result.ToString();
        }

    }
}
