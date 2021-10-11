using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_MVC_Socket_Client.View
{
    /// <summary>
    /// ReceiveOptionView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ReceiveOptionView : UserControl
    {
        public ReceiveOptionView()
        {
            InitializeComponent();
        }

        private void StringPrintMethod_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            string content = radioButton.Content as string;

            MainWindow.connectTCPController.CallStringPrintMethod(content);
        }

        private void TimeTag_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Checked");
            MainWindow.connectTCPController.CallTimeTag(true);
        }

        private void TimeTag_Unchecked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("UnChecked");
            MainWindow.connectTCPController.CallTimeTag(false);
        }

        private void RXTXTag_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
