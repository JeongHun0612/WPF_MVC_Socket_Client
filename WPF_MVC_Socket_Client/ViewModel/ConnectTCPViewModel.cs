using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

        private bool isConnectButtonEnabled = true;
        public bool IsConnectButtonEnabled
        {
            get { return this.isConnectButtonEnabled; }
            set { this.isConnectButtonEnabled = value; Notify("IsConnectButtonEnabled"); }
        }

        private bool isDisConnectButtonVisibility = false;
        public bool IsDisConnectButtonVisibility
        {
            get { return this.isDisConnectButtonVisibility; }
            set { this.isDisConnectButtonVisibility = value; Notify("IsDisConnectButtonVisibility"); }
        }

        private bool isConnectLampVisibility = true;
        public bool IsConnectLampVisibility
        {
            get { return this.isConnectLampVisibility; }
            set { this.isConnectLampVisibility = value; Notify("IsConnectLampVisibility"); }
        }

        private bool isSpinnerVisibility = false;
        public bool IsSpinnerVisibility
        {
            get { return this.isSpinnerVisibility; }
            set { this.isSpinnerVisibility = value; Notify("IsSpinnerVisibility"); }
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

            if (IPAddress.TryParse(iPMaskedTextBox.GetIPAddress(), out IPAddress ipAddress))
            {
                if (int.TryParse(PortNumText, out int portNum) && PortNumText != "0")
                {
                    IsConnecting(true);
                    ThreadPool.QueueUserWorkItem(state => Connect(ipAddress, portNum));
                }
                else
                {
                    PortNumText = string.Empty;
                    IsPortTextBoxFocus = false;
                    IsPortTextBoxFocus = true;
                }
            }
            else
            {
                iPMaskedTextBox.IPAddressError();
            }
        }

        private void Connect(IPAddress ipAddress, int portNum)
        {
            tcpClient = new TcpClient();
            IAsyncResult result = tcpClient.BeginConnect(ipAddress, portNum, null, null);

            if (!result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(2), false))
            {
                IsConnecting(false);
            }
            else
            {
                tcpClient.EndConnect(result);
                IsConnecting(false);
                IsConnect(true);
                ReceiveMessage();
            }
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                byte[] receiveByte = new byte[1024];
                string receiveMessage = string.Empty;

                try
                {
                    if (tcpClient.GetStream().Read(receiveByte, 0, receiveByte.Length) != 0)
                    {
                        receiveMessage = MainWindowViewModel.ReceiveOptionViewModel.IsHex ? ByteToHex(receiveByte) : ByteToAscii(receiveByte);

                        Dispatcher.Invoke(() =>
                        {
                            if (!MainWindowViewModel.ReceiveOptionViewModel.IsPause)
                            {
                                if (MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Count >= 100)
                                {
                                    MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.RemoveAt(0);
                                }

                                MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[RX]", receiveMessage, MainWindowViewModel.ReceiveOptionViewModel.IsReceive));
                            }
                        });
                    }
                    else
                    {
                        IsConnect(false);
                        break;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    IsConnect(false);
                    break;
                }
            }
        }

        private void DisConnectClick(object obj)
        {
            IsConnect(false);
        }

        private void IsConnecting(bool isConnecting)
        {
            if (isConnecting)
            {
                IsConnectButtonEnabled = false;
                IsSpinnerVisibility = true;
                IsConnectLampVisibility = false;
            }
            else
            {
                IsConnectButtonEnabled = true;
                IsSpinnerVisibility = false;
                IsConnectLampVisibility = true;
            }
        }

        private void IsConnect(bool isConnect)
        {
            if (isConnect)
            {
                IsDisConnectButtonVisibility = true;
                MainWindowViewModel.DataSendViewModel.IsSendBtnEnabled = true;
                MainWindowViewModel.DataSendViewModel.IsAutoSendBtnEnabled = true;
            }
            else
            {
                tcpClient.Close();
                IsDisConnectButtonVisibility = false;
                MainWindowViewModel.DataSendViewModel.ReleaseAutoSend();
                MainWindowViewModel.DataSendViewModel.IsSendBtnEnabled = false;
                MainWindowViewModel.DataSendViewModel.IsAutoSendBtnEnabled = false;
            }
        }

        private string ByteToHex(byte[] receiveByte)
        {
            return BitConverter.ToString(receiveByte).Replace("-00", string.Empty).Replace("-", " ");
        }

        private string ByteToAscii(byte[] receiveByte)
        {
            return Encoding.ASCII.GetString(receiveByte).Trim('\0');
        }
    }
}
