﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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

        private TcpClient tcpClient = null;
        public TcpClient TcpClient
        {
            get { return this.tcpClient; }
            set { this.tcpClient = value; Notify("TcpClient"); }
        }

        private bool isConnect = false;
        public bool IsConnect
        {
            get { return this.isConnect; }
            set { this.isConnect = value; Notify("IsConnect"); }
        }

        private string portNumText = string.Empty;
        public string PortNumText
        {
            get { return this.portNumText; }
            set { this.portNumText = value; Notify("PortNumText"); }
        }

        private bool isPortError = false;
        public bool IsPortError
        {
            get { return this.isPortError; }
            set { this.isPortError = value; Notify("IsPortError"); }
        }

        private bool isIPAddressError = false;
        public bool IsIPAddressError
        {
            get { return this.isIPAddressError; }
            set { this.isIPAddressError = value; Notify("IsIPAddressError"); }
        }

        private bool isConnectButtonVisibility = true;
        public bool IsConnectButtonVisibility
        {
            get { return this.isConnectButtonVisibility; }
            set { this.isConnectButtonVisibility = value; Notify("IsConnectButtonVisibility"); }
        }

        private bool isDisConnectButtonVisibility = false;
        public bool IsDisConnectButtonVisibility
        {
            get { return this.isDisConnectButtonVisibility; }
            set { this.isDisConnectButtonVisibility = value; Notify("IsDisConnectButtonVisibility"); }
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
                if (int.TryParse(PortNumText, out int portNum))
                {
                    tcpClient = new TcpClient();
                    tcpClient.BeginConnect(ipAddress, portNum, new AsyncCallback(CallbackConnect), tcpClient);
                }
                else
                {
                    IsPortError = true;
                    Debug.WriteLine("Port Number Error");
                }
            }
            else
            {
                IsIPAddressError = true;
                iPMaskedTextBox.IPAddressError();
                Debug.WriteLine("IP Address Error");
            }
        }

        private void CallbackConnect(IAsyncResult ar)
        {
            try
            {
                tcpClient.EndConnect(ar);
                IsConnect = true;
                IsConnectButtonVisibility = false;
                IsDisConnectButtonVisibility = true;
                MainWindowViewModel.DataSendViewModel.IsSendBtnEnabled = true;
                MainWindowViewModel.DataSendViewModel.IsAutoSendBtnEnabled = true;
                ReceiveMessage();
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                byte[] receiveByte = new byte[1024];
                string receiveMessage = string.Empty;

                if (tcpClient.GetStream().Read(receiveByte, 0, receiveByte.Length) != 0)
                {
                    if (MainWindowViewModel.ReceiveOptionViewModel.IsHex)
                    {
                        receiveMessage = BitConverter.ToString(receiveByte).Replace("-00", string.Empty).Replace("-", " ");
                    }

                    if (MainWindowViewModel.ReceiveOptionViewModel.IsAscii)
                    {
                        receiveMessage = Encoding.ASCII.GetString(receiveByte).Trim('\0');
                    }

                    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        if (!MainWindowViewModel.ReceiveOptionViewModel.IsPause)
                        {
                            MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[RX]", receiveMessage));
                        }
                    }));
                }
                else
                {
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
            IsConnectButtonVisibility = true;
            IsDisConnectButtonVisibility = false;
            MainWindowViewModel.DataSendViewModel.IsAutoSend = false;
            MainWindowViewModel.DataSendViewModel.IsSendBtnEnabled = false;
            MainWindowViewModel.DataSendViewModel.IsAutoSendBtnEnabled = false;
        }
    }
}
