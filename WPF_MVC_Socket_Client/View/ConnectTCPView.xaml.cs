using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

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
        }

        private void OnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
