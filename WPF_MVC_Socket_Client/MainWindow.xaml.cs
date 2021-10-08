using System.Windows;
using WPF_MVC_Socket_Client.Controller;

namespace WPF_MVC_Socket_Client
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static ConnectTCPController connectTCPController = new ConnectTCPController();
    }
}
