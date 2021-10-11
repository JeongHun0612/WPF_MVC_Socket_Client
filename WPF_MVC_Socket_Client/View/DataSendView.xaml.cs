using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace WPF_MVC_Socket_Client.View
{
    /// <summary>
    /// DataSendView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataSendView : UserControl
    {
        public DataSendView()
        {
            InitializeComponent();
            //MainWindow.connectTCPController.delegateIsConnect += SendIsConnect;
        }

        //private void SendClick(object sender, RoutedEventArgs e)
        //{
        //    MainWindow.connectTCPController.CallSendMessage(DataSendTextBox.Text);
        //    DataSendTextBox.Clear();
        //    DataSendTextBox.Focus();
        //}

        //private void SendIsConnect(bool isConnect)
        //{
        //    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
        //    {
        //        if (isConnect)
        //        {
        //            SendButton.IsEnabled = true;
        //        }
        //        else
        //        {
        //            SendButton.IsEnabled = false;
        //        }
        //    }));
        //}

        //private void OnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}
    }
}
