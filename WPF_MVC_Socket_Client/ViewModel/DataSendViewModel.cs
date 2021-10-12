using System;
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
        }

        private string sendText = string.Empty;
        public string SendText
        {
            get { return this.sendText; }
            set { this.sendText = value; Notify("SendText"); }
        }

        private bool sendBtnIsEnabled = false;
        public bool SendBtnIsEnabled
        {
            get { return this.sendBtnIsEnabled; }
            set { this.sendBtnIsEnabled = value; Notify("SendBtnIsEnabled"); }
        }

        private bool isSendTextBoxFocus = false;
        public bool IsSendTextBoxFocus
        {
            get { return this.isSendTextBoxFocus; }
            set { this.isSendTextBoxFocus = value; Notify("IsSendTextBoxFocus"); }
        }


        private DelegateCommand commandSendClick = null;
        public DelegateCommand CommandSendClick
        {
            get => this.commandSendClick;
            set => this.commandSendClick = value;
        }


        private void SendClick(object obj)
        {
            IsSendTextBoxFocus = false;

            try
            {
                string replaceString = string.Empty;
                replaceString = SendText.Replace(" ", string.Empty);
                byte[] sendByte = new byte[replaceString.Length / 2];

                for (int i = 0; i < sendByte.Length; i++)
                {
                    sendByte[i] = Convert.ToByte(replaceString.Substring(i * 2, 2), 16);
                }

                MainWindowViewModel.ConnectTCPViewModel.TcpClient.GetStream().Write(sendByte, 0, sendByte.Length);
                SendTextConvert(sendByte);
            }
            catch (Exception e)
            {
                byte[] sendByte = Encoding.Default.GetBytes(SendText);
                MainWindowViewModel.ConnectTCPViewModel.TcpClient.GetStream().Write(sendByte, 0, sendByte.Length);
                SendTextConvert(sendByte);
            }

            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[TX]", SendText));
            }));

            SendText = string.Empty;
            IsSendTextBoxFocus = true;
        }

        private void SendTextConvert(byte[] sendByte)
        {
            if (MainWindowViewModel.ReceiveOptionViewModel.IsHex)
            {
                SendText = BitConverter.ToString(sendByte).Replace("-00", string.Empty).Replace("-", " ");
            }

            if (MainWindowViewModel.ReceiveOptionViewModel.IsAscii)
            {
                SendText = Encoding.ASCII.GetString(sendByte).Trim('\0');
            }
        }
    }
}
