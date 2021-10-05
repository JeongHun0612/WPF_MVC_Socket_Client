using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVC_Socket_Client.Model
{
    public class DataReceiveModel
    {
        public DataReceiveModel(string TXRXtag, string dateTime, string content)
        {
            this.TXRXtag = TXRXtag;
            this.dateTime = dateTime;
            this.content = content;
        }

        private string TXRXtag = string.Empty;
        public string TXRXTag
        {
            get { return this.TXRXtag; }
            set { this.TXRXtag = value; }
        }

        private string dateTime = string.Empty;
        public string DateTime
        {
            get { return this.dateTime; }
            set { this.dateTime = value; }
        }

        private string content = string.Empty;
        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }
    }
}
