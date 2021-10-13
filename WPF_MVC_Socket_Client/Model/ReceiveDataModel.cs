using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVC_Socket_Client.ViewModel;

namespace WPF_MVC_Socket_Client.Model
{
    public class ReceiveDataModel : NotifierCollection
    {
        public ReceiveDataModel(string RXTXtag, string content)
        {
            this.RXTXtag = RXTXtag;
            this.content = content;
        }

        private string RXTXtag = string.Empty;
        public string RXTXTag
        {
            get { return this.RXTXtag; }
            set { this.RXTXtag = value; NotifyCollection("RXTXTag"); }
        }

        private string time = DateTime.Now.ToString("[HH:mm:ss]");
        public string Time
        {
            get { return this.time; }
            set { this.time = value; NotifyCollection("Time"); }
        }

        private string content = string.Empty;
        public string Content
        {
            get { return this.content; }
            set { this.content = value; NotifyCollection("Content"); }
        }

        private bool isVisibility = true;
        public bool IsVisibility
        {
            get { return this.isVisibility; }
            set { this.isVisibility = value; NotifyCollection("IsVisibility"); }
        }
    }
}
