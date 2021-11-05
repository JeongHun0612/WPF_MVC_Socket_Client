using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;
using WPF_MVC_Socket_Client.Model;
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

        private UdpClient udpClient = null;

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

            udpClient = new UdpClient();
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, portNum);

            byte[] sendData = Encoding.Default.GetBytes("Send Data2");
            udpClient.Send(sendData, sendData.Length, remoteEP);

            IsConnect = true;
            MainWindowViewModel.DataSendViewModel.IsSendBtnEnabled = true;
            ThreadPool.QueueUserWorkItem(state => ReceiveMessage());

            //try
            //{
            //    byte[] receiveData = new byte[1024];
            //    receiveData = udpClient.Receive(ref localEP);
            //    Debug.WriteLine(Encoding.ASCII.GetString(receiveData, 0, receiveData.Length));
            //}
            //catch (Exception e)
            //{
            //    Debug.WriteLine(e.Message);
            //}

       

            //ThreadPool.QueueUserWorkItem(state => ReceiveMessage());
        }
     
        private void ReceiveMessage()
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 0);

            try
            {
                byte[] receiveData = new byte[1024];
                receiveData = udpClient.Receive(ref localEP);
                Debug.WriteLine(Encoding.ASCII.GetString(receiveData, 0, receiveData.Length));
            }
            catch (Exception e)
            {
                Debug.WriteLine("Receive Error");
                Debug.WriteLine(e.Message);
            }

            //IPEndPoint sendEP = new IPEndPoint(IPAddress.None, 0);

            //while (true)
            //{
            //    try
            //    {
            //        byte[] receiveByte = udpClient.Receive(ref sendEP);

            //        Dispatcher.Invoke(() =>
            //        {
            //            if (!MainWindowViewModel.ReceiveOptionViewModel.IsPause)
            //            {
            //                if (MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Count >= 100)
            //                {
            //                    MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.RemoveAt(0);
            //                }

            //                MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[RX]", ReceiveTextConvert(receiveByte), MainWindowViewModel.ReceiveOptionViewModel.IsReceive));
            //            }
            //        });
            //    }
            //    catch (Exception e)
            //    {
            //        Debug.WriteLine(e.Message);
            //        DisConnect();
            //        break;
            //    }
            //}
        }

        private void DisConnectClick(object obj)
        {
            DisConnect();
        }

        private void DisConnect()
        {
            udpClient.Close();
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
