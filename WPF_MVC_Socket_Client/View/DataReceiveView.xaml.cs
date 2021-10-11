using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.View
{
    /// <summary>
    /// DataReceiveView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataReceiveView : UserControl
    {
        //private ObservableCollection<ReceiveDataModel> receiveDataList = new ObservableCollection<ReceiveDataModel>();

        public DataReceiveView()
        {
            InitializeComponent();
            //MainWindow.connectTCPController.delegateReceiveData += SendReceiveData;
            //MainWindow.connectTCPController.delegateIsTimeTag += SendIsTimeTag;

            //DataReceiveListView.ItemsSource = receiveDataList;
        }

        //private void SendReceiveData(ReceiveDataModel receiveData)
        //{
        //    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
        //    {
        //        receiveDataList.Add(receiveData);
        //    }));
        //}

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Save Click");
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Clear Clcik");
            //receiveDataList.Clear();
        }

        //private void SendIsTimeTag(bool isTimeTage)
        //{
        //    if (isTimeTage)
        //    {
        //        foreach (ReceiveDataModel itme in receiveDataList)
        //        {
        //            itme.IsTimeVisibility = Visibility.Visible;
        //        }
        //    }
        //    else
        //    {
        //        foreach (ReceiveDataModel itme in receiveDataList)
        //        {
        //            itme.IsTimeVisibility = Visibility.Collapsed;
        //        }
        //    }
        //}
    }
}
