using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class DataReceiveViewModel : Notifier
    {
        public DataReceiveViewModel()
        {
            MainWindowViewModel.DataReceiveViewModel = this;

            this.commandSelectedItemCopy = new DelegateCommand(SelectedItemCopy);
            this.commandSaveClick = new DelegateCommand(SaveClick);
            this.commandClearClick = new DelegateCommand(ClearClick);
        }

        private ObservableCollection<ReceiveDataModel> receiveDataCollection = new ObservableCollection<ReceiveDataModel>();
        public ObservableCollection<ReceiveDataModel> ReceiveDataCollection
        {
            get { return this.receiveDataCollection; }
            set { this.receiveDataCollection = value; Notify("ReceiveDataCollection"); }
        }

        private DelegateCommand commandSelectedItemCopy = null;
        public DelegateCommand CommandSelectedItemCopy
        {
            get => this.commandSelectedItemCopy;
            set => this.commandSelectedItemCopy = value;
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

        private void SelectedItemCopy(object obj)
        {
            IList selectedItems = obj as IList;
            List<ReceiveDataModel> SelectedItemsList = selectedItems.OfType<ReceiveDataModel>().ToList();

            Clipboard.SetText(StringBuilderAppend(SelectedItemsList).ToString());
        }

        private void SaveClick(object obj)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.Filter = "Text File (*.txt;)|*.txt;";
            fileDialog.FileName = "log";
            fileDialog.DefaultExt = "txt";
            fileDialog.ShowDialog();

            if (fileDialog.FileName != string.Empty)
            {
                File.WriteAllText(fileDialog.FileName, StringBuilderAppend(ReceiveDataCollection.ToList()).ToString());
            }
        }

        private void ClearClick(object obj)
        {
            ReceiveDataCollection.Clear();
        }

        private StringBuilder StringBuilderAppend(List<ReceiveDataModel> appendList)
        {
            StringBuilder strBuilder = new StringBuilder();

            foreach (ReceiveDataModel item in appendList)
            {
                if (item.IsVisibility)
                {
                    if (MainWindowViewModel.ReceiveOptionViewModel.IsRXTXTag) { strBuilder.Append(item.RXTXTag); }
                    if (MainWindowViewModel.ReceiveOptionViewModel.IsTimeTag) { strBuilder.Append(item.Time); }
                    strBuilder.Append(item.Content);
                    strBuilder.Append("\n");
                }
            }

            return strBuilder;
        }
    }
}
