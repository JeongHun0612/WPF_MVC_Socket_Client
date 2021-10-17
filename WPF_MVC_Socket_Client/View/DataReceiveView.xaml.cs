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

        private void DataGridReceive_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if(e.OriginalSource is ScrollViewer scrollViewer && e.ExtentHeightChange > 0.0)
            {
                scrollViewer.ScrollToEnd();
            }

            //if (e.OriginalSource is ScrollViewer scrollViewer && Math.Abs(e.ExtentHeightChange) > 0.0)
            //{
            //    scrollViewer.ScrollToEnd();
            //}
   
        }

        private void DataReceiveListView_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer scrollViewer && Math.Abs(e.ExtentHeightChange) > 0.0)
            {
                scrollViewer.ScrollToEnd();
            }
        }
    }
}
