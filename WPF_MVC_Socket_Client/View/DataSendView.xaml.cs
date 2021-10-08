using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        //private void OnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    Regex regex = new Regex("[^0-9]+");
        //    e.Handled = regex.IsMatch(e.Text);
        //}
    }
}
