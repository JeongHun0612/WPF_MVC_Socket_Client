using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class ReceiveOptionViewModel : Notifier
    {
        public ReceiveOptionViewModel()
        {
            MainWindowViewModel.ReceiveOptionViewModel = this;
        }


        private bool isTimeTag = false;
        public bool IsTimeTag
        {
            get { return this.isTimeTag; }
            set { this.isTimeTag = value; Notify("IsTimeTag"); }
        }
    }
}
