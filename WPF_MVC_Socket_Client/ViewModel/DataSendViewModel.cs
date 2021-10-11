using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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

        private DelegateCommand commandSendClick = null;
        public DelegateCommand CommandSendClick
        {
            get => this.commandSendClick;
            set => this.commandSendClick = value;
        }

        private void SendClick(object obj)
        {
            try
            {
                SendText = SendText.Replace(" ", string.Empty);
                byte[] sendByte = new byte[SendText.Length / 2];

                for (int i = 0; i < sendByte.Length; i++)
                {
                    sendByte[i] = Convert.ToByte(SendText.Substring(i * 2, 2), 16);
                }

                MainWindowViewModel.ConnectTCPViewModel.TcpClient.GetStream().Write(sendByte, 0, sendByte.Length);
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[TX]", SendText));
                }));
            }
            catch (Exception e)
            {
                byte[] sendByte = Encoding.Default.GetBytes(SendText);
                MainWindowViewModel.ConnectTCPViewModel.TcpClient.GetStream().Write(sendByte, 0, sendByte.Length);
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                {
                    MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection.Add(new ReceiveDataModel("[TX]", SendText));
                }));
            }

            SendText = string.Empty;
            //DataSendTextBox.Focus();
        }
    }
}
