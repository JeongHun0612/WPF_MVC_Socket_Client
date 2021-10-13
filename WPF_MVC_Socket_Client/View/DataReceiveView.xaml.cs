using System;
using System.Windows.Controls;

namespace WPF_MVC_Socket_Client.View
{
    /// <summary>
    /// DataReceiveView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataReceiveView : UserControl
    {
        public DataReceiveView()
        {
            InitializeComponent();
        }

        private void DataGridText_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer scrollViewer && Math.Abs(e.ExtentHeightChange) > 0.0)
            {
                scrollViewer.ScrollToEnd();
            }
        }
    }
}
