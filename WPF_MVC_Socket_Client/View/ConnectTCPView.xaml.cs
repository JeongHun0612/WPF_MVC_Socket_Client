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

            MainWindow.connectTCPController.delegateIsConnect += SendIsConnect;
        }

        private Color normalStartColor = (Color)ColorConverter.ConvertFromString("#A7E59E");
        private Color normalEndColor = (Color)ColorConverter.ConvertFromString("#69E03A");

        private Color connectStartColor = (Color)ColorConverter.ConvertFromString("#A7E59E");
        private Color connectEndColor = (Color)ColorConverter.ConvertFromString("#69E03A");


        private void ConnectClick(object sender, RoutedEventArgs e)
        {
            MainWindow.connectTCPController.CallTCPConnect(IpMaskedTextBoxView.GetIPAddress(), PortTextBox.Text);
        }

        private void SendIsConnect(bool isConnect)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                if (isConnect)
                {
                    ConnectLampStartColor.Color = connectStartColor;
                    ConnectLampEndColor.Color = connectEndColor;
                }
                else
                {
                    ConnectLampStartColor.Color = normalStartColor;
                    ConnectLampEndColor.Color = normalEndColor;
                }
            }));
        }

        private void OnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
