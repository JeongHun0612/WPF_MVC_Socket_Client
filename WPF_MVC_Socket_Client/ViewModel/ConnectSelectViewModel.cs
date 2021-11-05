using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class ConnectSelectViewModel : Notifier
    {
        public ConnectSelectViewModel()
        {
            MainWindowViewModel.ConnectSelectViewModel = this;
            this.commandConnectSelectChanged = new DelegateCommand(ConnectSelectChanged);
        }

        private bool isConnect = false;
        public bool IsConnect
        {
            get { return this.isConnect; }
            set { this.isConnect = value; Notify("IsConnect"); }
        }

        private DelegateCommand commandConnectSelectChanged = null;
        public DelegateCommand CommandConnectSelectChanged
        {
            get => this.commandConnectSelectChanged;
            set => this.commandConnectSelectChanged = value;
        }

        private void ConnectSelectChanged(object obj)
        {
            TabItem selectedItem = obj as TabItem;

            if (IsConnect)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
