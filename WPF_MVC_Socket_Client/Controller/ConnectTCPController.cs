using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.Controller
{
    public class ConnectTCPController
    {
        private TcpClient client = null;

        public delegate void DelegateIsConnect(bool isConnect);
        public event DelegateIsConnect delegateIsConnect;

        public void CallTCPConnect(string address, string port)
        {
            delegateIsConnect?.Invoke(true);

            //if (IPAddress.TryParse(address, out IPAddress ipAddress))
            //{
            //    if (int.TryParse(port, out int portNum))
            //    {
            //        //&& PortTextBox.Text != "0"
            //        //client = new TcpClient();
            //        //client.BeginConnect(address, port, new AsyncCallback(CallbackConnect), client);
            //    }
            //    else
            //    {
            //        Debug.WriteLine("Port Number Error");
            //    }
            //}
            //else
            //{
            //    Debug.WriteLine("IP Address Error");
            //}
        }

        private void CallbackConnect(IAsyncResult ar)
        {
            try
            {
                client.EndConnect(ar);
                delegateIsConnect?.Invoke(true);
                Debug.WriteLine("Success");
                //ReceiveMessage();
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
