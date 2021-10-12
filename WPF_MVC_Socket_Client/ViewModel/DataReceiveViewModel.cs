using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
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
        }

        private ObservableCollection<ReceiveDataModel> receiveDataCollection = new ObservableCollection<ReceiveDataModel>();
        public ObservableCollection<ReceiveDataModel> ReceiveDataCollection
        {
            get { return this.receiveDataCollection; }
            set { this.receiveDataCollection = value; Notify("ReceiveDataCollection"); }
        }
   

        private DelegateCommand commandSaveClick = null;
        public DelegateCommand CommandSaveClick
        {
            get => this.commandSaveClick;
            set => this.commandSaveClick = value;
        }

        private DelegateCommand commandClearClick = null;
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
