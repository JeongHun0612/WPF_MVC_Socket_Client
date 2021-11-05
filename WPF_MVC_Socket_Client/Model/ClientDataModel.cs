using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WPF_MVC_Socket_Client.ViewModel;

namespace WPF_MVC_Socket_Client.Model
{
    public class ClientDataModel : Notifier
    {
        public ClientDataModel(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            this.receiveByte = new byte[1024];
        }

        private TcpClient tcpClient = null;
        public TcpClient TcpClient
        {
            get { return this.tcpClient; }
            set { this.tcpClient = value; Notify("TcpClient"); }
        }

        private byte[] receiveByte = null;
        public byte[] ReceiveByte
        {
            get { return this.receiveByte; }
            set { this.receiveByte = value; Notify("ReceiveByte"); }
        }

        private bool isConnect = false;
        public bool IsConnect
        {
            get { return this.isConnect; }
            set { this.isConnect = value; Notify("IsConnect"); }
        }
    }
}
