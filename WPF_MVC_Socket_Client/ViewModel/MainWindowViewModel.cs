using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {

        }

        public static ConnectTCPViewModel ConnectTCPViewModel { get; set; } = null;
        public static ReceiveOptionViewModel ReceiveOptionViewModel { get; set; } = null;
        public static DataReceiveViewModel DataReceiveViewModel { get; set; } = null;
        public static DataSendViewModel DataSendViewModel { get; set; } = null;
    }
}
