using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVC_Socket_Client.Model
{
    public class ClientDataModel : Notifier
    {
        private bool isConnect = true;
        public bool IsConnect
        {
            get { return this.isConnect; }
            set { this.isConnect = value; Notify("IsConnect"); }
        }

        private string stringConnect = "testconnect";
        public string StringConnect
        {
            get { return this.stringConnect; }
            set { this.stringConnect = value; Notify("StringConnect"); }
        }
    }
}
