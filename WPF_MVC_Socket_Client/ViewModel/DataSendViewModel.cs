using System;
using System.Diagnostics;
using System.Text;
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
            this.commandValueChanged = new DelegateCommand(ValueChanged);

            AutoSendLoop();
        }

        DispatcherTimer timer = new DispatcherTimer();
        private bool IsCatch = false;

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

        private DelegateCommand commandValueChanged = null;
        public DelegateCommand CommandValueChanged
        {
            get => this.commandValueChanged;
            set => this.commandValueChanged = value;
        }


        private void SendClick(object obj)
        {
            if (SendText != string.Empty)
            {
                DataSend();
            }

            SendText = string.Empty;
            IsSendTextBoxFocus = false;
            IsSendTextBoxFocus = true;
        }

        private void AutoSendClick(object obj)
        {
            if (IsAutoSend && SendText != string.Empty)
            {
                DataSend();
                timer.Start();
                IsSendBtnEnabled = false;
            }
            else
            {
                IsSendBtnEnabled = true;
                ReleaseAutoSend();
            }
        }

        public void ReleaseAutoSend()
        {
            timer.Stop();
            IsCatch = false;
            IsAutoSend = false;
            SendText = string.Empty;
        }

        private void AutoSendLoop()
        {
            timer.Interval = TimeSpan.FromMilliseconds(SendTime * 1000);
            timer.Tick += (o, e) =>
            {
                DataSend();
            };
        }

        private void ValueChanged(object obj)
        {
            timer.Interval = TimeSpan.FromMilliseconds(SendTime * 1000);
        }

        private void DataSend()
        {
            byte[] sendByte = null;

            try
            {
                if (IsCatch)
                {
                    sendByte = AsciiToByte();
                }
                else
                {
                    sendByte = HexToByte();
                }
            }
            catch
            {
                IsCatch = true;
                sendByte = AsciiToByte();
            }

            try
            {
                ConnectTCPViewModel.tcpClient.GetStream().Write(sendByte, 0, sendByte.Length);

                Dispatcher.Invoke(() =>
                {
                    if (!MainWindowViewModel.ReceiveOptionViewModel.IsPause)
                    {
                        if (MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Count >= 100)
                        {
                            MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.RemoveAt(0);
                        }

                        MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[TX]", SendTextConvert(sendByte), MainWindowViewModel.ReceiveOptionViewModel.IsTransmit));
                    }
                });
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private byte[] HexToByte()
        {
            string convertString = SendText.Replace(" ", string.Empty);
            byte[] sendByte = new byte[convertString.Length / 2];

            for (int idx = 0; idx < sendByte.Length; idx++)
            {
                sendByte[idx] = Convert.ToByte(convertString.Substring(idx * 2, 2), 16);
            }

            return sendByte;
        }

        private byte[] AsciiToByte()
        {
            return Encoding.Default.GetBytes(SendText);
        }

        private string SendTextConvert(byte[] sendByte)
        {
            if (MainWindowViewModel.ReceiveOptionViewModel.IsHex)
            {
                return BitConverter.ToString(sendByte).Replace("-00", string.Empty).Replace("-", " ");
            }

            else
            {
                return Encoding.ASCII.GetString(sendByte).Trim('\0');
            }
        }
    }
}
