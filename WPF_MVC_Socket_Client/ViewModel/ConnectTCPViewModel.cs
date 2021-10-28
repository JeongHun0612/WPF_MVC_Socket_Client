using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using WPF_MVC_Socket_Client.Model;
using WPF_MVC_Socket_Client.View;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class ConnectTCPViewModel : Notifier
    {
        public ConnectTCPViewModel()
        {
            MainWindowViewModel.ConnectTCPViewModel = this;
            this.commandConnectClick = new DelegateCommand(ConnectClick);
            this.commandDisConnectClick = new DelegateCommand(DisConnectClick);
        }

        public static TcpClient tcpClient = null;

        private string portNumText = string.Empty;
        public string PortNumText
        {
            get { return this.portNumText; }
            set { this.portNumText = value; Notify("PortNumText"); }
        }

        private bool isPortTextBoxFocus = false;
        public bool IsPortTextBoxFocus
        {
            get { return this.isPortTextBoxFocus; }
            set { this.isPortTextBoxFocus = value; Notify("IsPortTextBoxFocus"); }
        }

        private bool isConnect = false;
        public bool IsConnect
        {
            get { return this.isConnect; }
            set { this.isConnect = value; Notify("IsConnect"); }
        }

        private bool isConnecting = false;
        public bool IsConnecting
        {
            get { return this.isConnecting; }
            set { this.isConnecting = value; Notify("IsConnecting"); }
        }

        private DelegateCommand commandConnectClick = null;
        public DelegateCommand CommandConnectClick
        {
            get => this.commandConnectClick;
            set => this.commandConnectClick = value;
        }

        private DelegateCommand commandDisConnectClick = null;
        public DelegateCommand CommandDisConnectClick
        {
            get => this.commandDisConnectClick;
            set => this.commandDisConnectClick = value;
        }

        private void ConnectClick(object obj)
        {
            IPMaskedTextBox iPMaskedTextBox = obj as IPMaskedTextBox;

            if (!IPAddress.TryParse(iPMaskedTextBox.GetIPAddress(), out IPAddress ipAddress))
            {
                iPMaskedTextBox.IPAddressError();
                return;
            }

            if (!int.TryParse(PortNumText, out int portNum) || portNumText == "0")
            {
                PortNumText = string.Empty;
                IsPortTextBoxFocus = false;
                IsPortTextBoxFocus = true;
                return;
            }

            IsConnecting = true;
            ThreadPool.QueueUserWorkItem(state => Connect(ipAddress, portNum));
        }

        private void Connect(IPAddress ipAddress, int portNum)
        {
            tcpClient = new TcpClient();
            IAsyncResult result = tcpClient.BeginConnect(ipAddress, portNum, null, null);

            if (!result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2), false))
            {
                IsConnecting = false;
            }
            else
            {
                IsConnect = true;
                IsConnecting = false;
                tcpClient.EndConnect(result);
                ReceiveMessage();
            }
        }

        private void ReceiveMessage()
        {
            string receiveMessage = string.Empty;

            while (true)
            {
                byte[] receiveByte = new byte[1024];

                try
                {
                    if (tcpClient.GetStream().Read(receiveByte, 0, receiveByte.Length) == 0)
                    {
                        DisConnect();
                        break;
                    }

                    Dispatcher.Invoke(() =>
                    {
                        if (!MainWindowViewModel.ReceiveOptionViewModel.IsPause)
                        {
                            if (MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Count >= 100)
                            {
                                MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.RemoveAt(0);
                            }

                            MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[RX]", ReceiveTextConvert(receiveByte), MainWindowViewModel.ReceiveOptionViewModel.IsReceive));
                        }
                    });
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    DisConnect();
                    break;
                }
            }
        }

        private void DisConnectClick(object obj)
        {
            DisConnect();
        }

        private void DisConnect()
        {
            tcpClient.Close();
            IsConnect = false;
            MainWindowViewModel.DataSendViewModel.ReleaseAutoSend();
        }

        private string ReceiveTextConvert(byte[] receiveByte)
        {
            if (MainWindowViewModel.ReceiveOptionViewModel.IsHex)
            {
                return BitConverter.ToString(receiveByte).Replace("-00", string.Empty).Replace("-", " ");
            }

            else
            {
                return Encoding.ASCII.GetString(receiveByte).Trim('\0');
            }
        }
    }
}
