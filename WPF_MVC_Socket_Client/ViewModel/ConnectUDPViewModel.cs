using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using WPF_MVC_Socket_Client.View;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class ConnectUDPViewModel : Notifier
    {
        public ConnectUDPViewModel()
        {
            MainWindowViewModel.ConnectUDPViewModel = this;
            this.commandConnectClick = new DelegateCommand(ConnectClick);
            this.commandDisConnectClick = new DelegateCommand(DisConnectClick);
        }


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

            UdpClient udpClient = new UdpClient();
            IPEndPoint ipe = new IPEndPoint(ipAddress, portNum);

            byte[] data = Encoding.Default.GetBytes("Hello Client");
            udpClient.Send(data, data.Length, ipe);
            //Debug.Write(udpClient.Send(data, data.Length, ipe));
        }

        private void ReceiveMessage()
        {
            string receiveMessage = string.Empty;

            while (true)
            {
                try
                {
                    Dispatcher.Invoke(() =>
                    {
                        if (!MainWindowViewModel.ReceiveOptionViewModel.IsPause)
                        {
                            if (MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Count >= 100)
                            {
                                MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.RemoveAt(0);
                            }

                            //MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[RX]", ReceiveTextConvert(receiveByte), MainWindowViewModel.ReceiveOptionViewModel.IsReceive));
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
            //udpClient.Close();
            IsConnect = false;
            MainWindowViewModel.DataSendViewModel.ReleaseAutoSend();
            MainWindowViewModel.DataSendViewModel.IsSendBtnEnabled = false;
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
