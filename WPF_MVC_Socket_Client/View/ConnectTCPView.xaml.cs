using System;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.View
{
    /// <summary>
    /// ConnectTCPView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ConnectTCPView : UserControl
    {
        public ConnectTCPView()
        {
            InitializeComponent();
            //MainWindow.connectTCPController.delegateIsConnect += SendIsConnect;
        }

        //private void ConnectClick(object sender, RoutedEventArgs e)
        //{
        //    if (IPAddress.TryParse(IpMaskedTextBoxView.GetIPAddress(), out IPAddress ipAddress))
        //    {
        //        if (int.TryParse(PortTextBox.Text, out int portNum))
        //        {
        //            //&& PortTextBox.Text != "0"
        //            MainWindow.connectTCPController.CallTCPConnect(ipAddress, portNum);
        //        }
        //        else
        //        {
        //            PortTextBox.Focus();
        //        }
        //    }
        //    else
        //    {
        //        IpMaskedTextBoxView.IPAddressError();
        //    }
        //}

        //private void DisConnectClick(object sender, RoutedEventArgs e)
        //{
        //    MainWindow.connectTCPController.CallTCPDisConnect();
        //}

        //private void SendIsConnect(bool isConnect)
        //{
        //    Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
        //    {
        //        if (isConnect)
        //        {
        //            ConnectButton.Visibility = Visibility.Collapsed;
        //            DisConnectButton.Visibility = Visibility.Visible;
        //        }

        //        else
        //        {
        //            ConnectButton.Visibility = Visibility.Visible;
        //            DisConnectButton.Visibility = Visibility.Collapsed;
        //        }
        //    }));
        //}

        private void OnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
