using System;
using System.Diagnostics;
using System.Windows;
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

        private void DataReceiveListView_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer scrollViewer && e.ExtentHeightChange > 0.0)
            {
                scrollViewer.ScrollToEnd();
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
