using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.View
{
    /// <summary>
    /// DataReceiveView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DataReceiveView : UserControl
    {
        private ObservableCollection<DataReceiveModel> dataReceiveList = new ObservableCollection<DataReceiveModel>();

        public DataReceiveView()
        {
            InitializeComponent();

            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage1TestMessage1TestMessage1TestMessage1TestMessage1TestMessage1TestMessage1TestMessage1TestMessage1TestMessage1TestMessage1TestMessage1"));
            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[RX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));
            dataReceiveList.Add(new DataReceiveModel("[TX]", "2021-09-19", "TestMessage2"));


            DataReceiveListView.ItemsSource = dataReceiveList;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Debug.WriteLine("Click Test");
        }
    }
}
