using System;
using System.Windows;
using System.Windows.Data;

namespace WPF_MVC_Socket_Client.Library
{
    public class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var isVisible = (bool)value;
                return isVisible ? Visibility.Visible : Visibility.Collapsed;
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var visibility = (Visibility)value;
                return visibility == Visibility.Visible;
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }

    public class BoolToVisibilityReverse : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
