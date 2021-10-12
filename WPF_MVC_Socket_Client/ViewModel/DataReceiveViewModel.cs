using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class DataReceiveViewModel : Notifier
    {
        public DataReceiveViewModel()
        {
            MainWindowViewModel.DataReceiveViewModel = this;

            this.CommandSaveClick = new DelegateCommand(SaveClick);
            this.CommandClearClick = new DelegateCommand(ClearClick);

            ReceiveDataCollection.Add(new ReceiveDataModel("[RX]", "TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2TestMessage2"));
            ReceiveDataCollection.Add(new ReceiveDataModel("[RX]", "TestMessage2"));
            ReceiveDataCollection.Add(new ReceiveDataModel("[RX]", "TestMessage2"));
        }

        private ObservableCollection<ReceiveDataModel> receiveDataCollection = new ObservableCollection<ReceiveDataModel>();
        public ObservableCollection<ReceiveDataModel> ReceiveDataCollection
        {
            get { return this.receiveDataCollection; }
            set { this.receiveDataCollection = value; Notify("ReceiveDataCollection"); }
        }

        private bool isRXTXTagVisibility = true;
        public bool IsRXTXTagVisibility
        {
            get { return this.isRXTXTagVisibility; }
            set { this.isRXTXTagVisibility = value; Notify("IsRXTXTagVisibility"); }
        }

        private bool isTimeVisibility = true;
        public bool IsTimeVisibility
        {
            get { return this.isTimeVisibility; }
            set { this.isTimeVisibility = value; Notify("IsTimeVisibility"); }
        }

        private DelegateCommand commandSaveClick = null;
        private DelegateCommand commandClearClick = null;

        public DelegateCommand CommandSaveClick
        {
            get => this.commandSaveClick;
            set => this.commandSaveClick = value;
        }

        public DelegateCommand CommandClearClick
        {
            get => this.commandClearClick;
            set => this.commandClearClick = value;
        }

        private void SaveClick(object obj)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            StringBuilder strBuilder = new StringBuilder();

            fileDialog.Filter = "Text File (*.txt;)|*.txt;";
            fileDialog.FileName = "log";
            fileDialog.DefaultExt = "txt";
            fileDialog.ShowDialog();

            if (fileDialog.FileName != string.Empty)
            {
                foreach (ReceiveDataModel item in ReceiveDataCollection)
                {
                    strBuilder.Append(item.Content);
                    strBuilder.Append("\n");
                }
            
                File.WriteAllText(fileDialog.FileName, strBuilder.ToString());
            }
        }

        private void ClearClick(object obj)
        {
            ReceiveDataCollection.Clear();
        }
    }
}
