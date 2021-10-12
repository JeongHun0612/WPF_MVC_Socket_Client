using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class ReceiveOptionViewModel : Notifier
    {
        public ReceiveOptionViewModel()
        {
            MainWindowViewModel.ReceiveOptionViewModel = this;

            this.commandTimeTagClick = new DelegateCommand(TimeTagClick);
        }

        private DelegateCommand commandTimeTagClick = null;
        public DelegateCommand CommandTimeTagClick
        {
            get => this.commandTimeTagClick;
            set => this.commandTimeTagClick = value;
        }

        private bool isTimeTag = true;
        public bool IsTimeTag
        {
            get { return this.isTimeTag; }
            set { this.isTimeTag = value; Notify("IsTimeTag"); }
        }

        private void TimeTagClick(object obj)
        {
            if (IsTimeTag)
            {
                foreach (ReceiveDataModel item in MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection)
                {
                    Debug.WriteLine(item.Time);
                    item.IsTimeVisibility = Visibility.Visible;
                }
                //MainWindowViewModel.DataReceiveViewModel.IsTimeVisibility = true;
            }
            else
            {
                foreach (ReceiveDataModel item in MainWindowViewModel.DataReceiveViewModel.ReceiveDataCollection)
                {
                    item.IsTimeVisibility = Visibility.Collapsed;
                }
                //MainWindowViewModel.DataReceiveViewModel.IsTimeVisibility = false;
            }
        }
    }
}
