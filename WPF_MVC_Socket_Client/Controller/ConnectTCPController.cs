using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Threading;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.Controller
{
    public class ConnectTCPController
    {
        private TcpClient client = null;
        private string stringMethod = "HEX";

        public delegate void DelegateIsConnect(bool isConnect);
        public event DelegateIsConnect delegateIsConnect;
        public delegate void DelegateReceiveData(ReceiveDataModel receiveData);
        public event DelegateReceiveData delegateReceiveData;

        public delegate void DdelegateIsTimeTag(bool isTimeTag);
        public event DdelegateIsTimeTag delegateIsTimeTag;


        public void CallTCPConnect(IPAddress address, int port)
        {
            client = new TcpClient();
            client.BeginConnect(address, port, new AsyncCallback(CallbackConnect), client);
        }

        private void CallbackConnect(IAsyncResult ar)
        {
            try
            {
                client.EndConnect(ar);
                delegateIsConnect?.Invoke(true);
                ReceiveMessage();
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void CallTCPDisConnect()
        {
            client.Close();
            delegateIsConnect?.Invoke(false);
        }

        public void CallSendMessage(string sendMessage)
        {
            try
            {
                sendMessage = sendMessage.Replace(" ", string.Empty);
                byte[] sendByte = new byte[sendMessage.Length / 2];

                for (int i = 0; i < sendByte.Length; i++)
                {
                    sendByte[i] = Convert.ToByte(sendMessage.Substring(i * 2, 2), 16);
                }

                client.GetStream().Write(sendByte, 0, sendByte.Length);
                delegateReceiveData?.Invoke(new ReceiveDataModel("[TX]", sendMessage));
            }
            catch (Exception e)
            {
                byte[] sendByte = Encoding.Default.GetBytes(sendMessage);
                client.GetStream().Write(sendByte, 0, sendByte.Length);
                delegateReceiveData?.Invoke(new ReceiveDataModel("[TX]", sendMessage));
            }
        }

        public void CallStringPrintMethod(string content)
        {
            stringMethod = (content == "HEX") ? "HEX" : "ASCII";
        }

        public void CallTimeTag(bool isTimeTag)
        {
            delegateIsTimeTag?.Invoke(isTimeTag);
        }

        private void ReceiveMessage()
        {
            byte[] receiveByte = new byte[1024];
            string receiveMessage = string.Empty;

            while (true)
            {
                if (client.GetStream().Read(receiveByte, 0, receiveByte.Length) != 0)
                {
                    switch (stringMethod)
                    {
                        case "HEX":
                            receiveMessage = BitConverter.ToString(receiveByte).Replace("-00", string.Empty).Replace("-", " ");
                            delegateReceiveData?.Invoke(new ReceiveDataModel("[RX]", receiveMessage));
                            break;
                        case "ASCII":
                            receiveMessage = Encoding.ASCII.GetString(receiveByte).Trim('\0');
                            delegateReceiveData?.Invoke(new ReceiveDataModel("[RX]", receiveMessage));
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    CallTCPDisConnect();
                    break;
                }
            }
        }
    }
}
