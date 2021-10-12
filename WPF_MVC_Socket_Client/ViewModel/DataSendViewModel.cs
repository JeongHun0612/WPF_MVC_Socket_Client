using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class DataSendViewModel : Notifier
    {
        public DataSendViewModel()
        {
            MainWindowViewModel.DataSendViewModel = this;
            this.commandSendClick = new DelegateCommand(SendClick);
            this.commandAutoSendClick = new DelegateCommand(AutoSendClick);
        }

        private string convertStringText = string.Empty;

        private string sendText = string.Empty;
        public string SendText
        {
            get { return this.sendText; }
            set { this.sendText = value; Notify("SendText"); }
        }

        private bool isSendBtnEnabled = false;
        public bool IsSendBtnEnabled
        {
            get { return this.isSendBtnEnabled; }
            set { this.isSendBtnEnabled = value; Notify("IsSendBtnEnabled"); }
        }

        private bool isAutoSendBtnEnabled = false;
        public bool IsAutoSendBtnEnabled
        {
            get { return this.isAutoSendBtnEnabled; }
            set { this.isAutoSendBtnEnabled = value; Notify("IsAutoSendBtnEnabled"); }
        }

        private bool isSendTextBoxFocus = false;
        public bool IsSendTextBoxFocus
        {
            get { return this.isSendTextBoxFocus; }
            set { this.isSendTextBoxFocus = value; Notify("IsSendTextBoxFocus"); }
        }

        private bool isAutoSend = false;
        public bool IsAutoSend
        {
            get { return this.isAutoSend; }
            set { this.isAutoSend = value; Notify("IsAutoSend"); }
        }

        private int sendTime = 1;
        public int SendTime
        {
            get { return this.sendTime; }
            set { this.sendTime = value; Notify("SendTime"); }
        }

        private DelegateCommand commandSendClick = null;
        public DelegateCommand CommandSendClick
        {
            get => this.commandSendClick;
            set => this.commandSendClick = value;
        }

        private DelegateCommand commandAutoSendClick = null;
        public DelegateCommand CommandAutoSendClick
        {
            get => this.commandAutoSendClick;
            set => this.commandAutoSendClick = value;
        }


        private void SendClick(object obj)
        {
            IsSendTextBoxFocus = false;

            DataSend();

            SendText = string.Empty;
            IsSendTextBoxFocus = true;
        }


        private void AutoSendClick(object obj)
        {
            if (IsAutoSend)
            {
                IsSendBtnEnabled = false;
                ThreadPool.QueueUserWorkItem(AutoSendLoop);
            }
            else
            {
                SendText = string.Empty;
                IsSendBtnEnabled = true;
            }
        }

        private void AutoSendLoop(object callBack)
        {
            while (true)
            {
                if (!IsAutoSend || !MainWindowViewModel.ConnectTCPViewModel.IsConnect)
                {
                    return;
                }

                byte[] sendByte = Encoding.Default.GetBytes(SendText);
                MainWindowViewModel.ConnectTCPViewModel.TcpClient.GetStream().Write(sendByte, 0, sendByte.Length);
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    if (!MainWindowViewModel.ReceiveOptionViewModel.IsPause)
                    {
                        MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[TX]", SendText));
                    }
                }));
                Thread.Sleep(SendTime * 1000);
            }
        }

        private void DataSend()
        {
            //try
            //{
            //    string convertString = SendText;
            //    convertString = convertString.Replace(" ", string.Empty);
            //    byte[] sendByte = new byte[convertString.Length / 2];

            //    for (int i = 0; i < sendByte.Length; i++)
            //    {
            //        sendByte[i] = Convert.ToByte(convertString.Substring(i * 2, 2), 16);
            //    }

            //    MainWindowViewModel.ConnectTCPViewModel.TcpClient.GetStream().Write(sendByte, 0, sendByte.Length);
            //    SendTextConvert(sendByte);
            //}
            //catch (Exception e)
            //{
            //    byte[] sendByte = Encoding.Default.GetBytes(SendText);
            //    MainWindowViewModel.ConnectTCPViewModel.TcpClient.GetStream().Write(sendByte, 0, sendByte.Length);
            //    SendTextConvert(sendByte);
            //}

            //Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            //{
            //    MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[TX]", convertStringText));
            //}));

            byte[] sendByte = Encoding.Default.GetBytes(SendText);
            MainWindowViewModel.ConnectTCPViewModel.TcpClient.GetStream().Write(sendByte, 0, sendByte.Length);

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[TX]", SendText));
            }));
        }

        private void SendTextConvert(byte[] sendByte)
        {
            if (MainWindowViewModel.ReceiveOptionViewModel.IsHex)
            {
                convertStringText = BitConverter.ToString(sendByte).Replace("-00", string.Empty).Replace("-", " ");
            }

            if (MainWindowViewModel.ReceiveOptionViewModel.IsAscii)
            {
                convertStringText = Encoding.ASCII.GetString(sendByte).Trim('\0');
            }
        }
    }
}
