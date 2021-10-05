using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Send Click");
        }
    }
}
