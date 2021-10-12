using System.Diagnostics;
using WPF_MVC_Socket_Client.Model;

namespace WPF_MVC_Socket_Client.ViewModel
{
    public class ReceiveOptionViewModel : Notifier
    {
        public ReceiveOptionViewModel()
        {
            MainWindowViewModel.ReceiveOptionViewModel = this;
        }

        private bool isHex = true;
        public bool IsHex
        {
            get { return this.isHex; }
            set { this.isHex = value; Notify("IsHex"); }
        }

        private bool isAscii = true;
        public bool IsAscii
        {
            get { return this.isAscii; }
            set { this.isAscii = value; Notify("IsAscii"); }
        }

        private bool isReceive = true;
        public bool IsReceive
        {
            get { return this.isReceive; }
            set { this.isReceive = value; Notify("IsReceive"); }
        }

        private bool isTransmit = true;
        public bool IsTransmit
        {
            get { return this.isTransmit; }
            set { this.isTransmit = value; Notify("IsTransmit"); }
        }

        private bool isTimeTag = true;
        public bool IsTimeTag
        {
            get { return this.isTimeTag; }
            set { this.isTimeTag = value; Notify("IsTimeTag"); }
        }

        private bool isRXTXTag = true;
        public bool IsRXTXTag
        {
            get { return this.isRXTXTag; }
            set { this.isRXTXTag = value; Notify("IsRXTXTag"); }
        }

        private bool isLineBreak = true;
        public bool IsLineBreak
        {
            get { return this.isLineBreak; }
            set { this.isLineBreak = value; Notify("IsLineBreak"); }
        }

        private bool isPause = false;
        public bool IsPause
        {
            get { return this.isPause; }
            set { this.isPause = value; Notify("IsPause"); }
        }
    }
}
