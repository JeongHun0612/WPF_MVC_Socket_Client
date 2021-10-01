using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_MVC_Socket_Client.View
{
    /// <summary>
    /// IPMaskedTextBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class IPMaskedTextBox : UserControl
    {
        public IPMaskedTextBox()
        {
            InitializeComponent();
        }

        public string GetIPAddress()
        {
            return firstBox.Text + "." + secondBox.Text + "." + thirdBox.Text + "." + fourthBox.Text;
        }

        public void FocusChanged()
        {
            if (firstBox.Text == string.Empty) { firstBox.Focus(); }
            else if (secondBox.Text == string.Empty) { secondBox.Focus(); }
            else if (thirdBox.Text == string.Empty) { thirdBox.Focus(); }
            else if (fourthBox.Text == string.Empty) { fourthBox.Focus(); }
        }

        private void JumpRight(TextBox rightNeighborBox, KeyEventArgs e)
        {
            rightNeighborBox.CaretIndex = 0;
            rightNeighborBox.Focus();

            e.Handled = true;
        }

        private void JumpLeft(TextBox leftNeighborBox, KeyEventArgs e)
        {
            leftNeighborBox.Focus();

            if (leftNeighborBox.Text != "")
            {
                leftNeighborBox.CaretIndex = leftNeighborBox.Text.Length;
            }
            e.Handled = true;
        }

        private bool CheckJumpRight(TextBox currentBox, TextBox rightNeighborBox, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    if (currentBox.CaretIndex == currentBox.Text.Length || currentBox.Text == "")
                    {
                        JumpRight(rightNeighborBox, e);
                    }
                    return true;
                case Key.Space:
                    JumpRight(rightNeighborBox, e);
                    rightNeighborBox.SelectAll();
                    return true;

                default:
                    return false;
            }
        }

        private bool CheckJumpLeft(TextBox currentBox, TextBox leftNeighborBox, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    if (currentBox.CaretIndex == 0 || currentBox.Text == "")
                    {
                        JumpLeft(leftNeighborBox, e);
                    }
                    return true;
                case Key.Back:
                    if ((currentBox.CaretIndex == 0 || currentBox.Text == "") && currentBox.SelectionLength == 0)
                    {
                        JumpLeft(leftNeighborBox, e);
                    }
                    return true;
                default:
                    return false;
            }
        }

        private void HandleTextChange(TextBox currentBox, TextBox rightNeighborBox)
        {
            if (currentBox.Text.Length == 3)
            {
                if (!byte.TryParse(currentBox.Text, out _))
                {
                    currentBox.Text = "255";
                }

                if (currentBox != fourthBox)
                {
                    rightNeighborBox.SelectAll();
                    rightNeighborBox.Focus();
                }
            }
        }

        // PreviewKeyDown Event
        private void FirstByte_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckJumpRight(firstBox, secondBox, e);
        }

        private void SecondByte_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (CheckJumpRight(secondBox, thirdBox, e)) { return; }
            CheckJumpLeft(secondBox, firstBox, e);
        }

        private void ThirdByte_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (CheckJumpRight(thirdBox, fourthBox, e)) { return; }
            CheckJumpLeft(thirdBox, secondBox, e);
        }

        private void FourthByte_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (CheckJumpRight(fourthBox, firstBox, e)) { return; }
            CheckJumpLeft(fourthBox, thirdBox, e);
        }

        // TextChanged Event
        private void FirstByte_TextChanged(object sender, TextChangedEventArgs e)
        {
            HandleTextChange(firstBox, secondBox);
        }

        private void SecondByte_TextChanged(object sender, TextChangedEventArgs e)
        {
            HandleTextChange(secondBox, thirdBox);
        }

        private void ThirdByte_TextChanged(object sender, TextChangedEventArgs e)
        {
            HandleTextChange(thirdBox, fourthBox);
        }

        private void FourthByte_TextChanged(object sender, TextChangedEventArgs e)
        {
            HandleTextChange(fourthBox, fourthBox);
        }

        // TextInput Event
        private void OnlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
