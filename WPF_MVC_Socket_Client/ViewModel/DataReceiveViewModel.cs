using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class DataReceiveViewModel : Notifier
    {
        public DataReceiveViewModel()
        {
            MainWindowViewModel.DataReceiveViewModel = this;
        }

        private ObservableCollection<ReceiveDataModel> receiveDataCollection = new ObservableCollection<ReceiveDataModel>();
        public ObservableCollection<ReceiveDataModel> ReceiveDataCollection
        {
            get { return this.receiveDataCollection; }
            set { this.receiveDataCollection = value; Notify("ReceiveDataCollection"); }
        }
    }
}
