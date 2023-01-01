using System;
using System.Globalization;
using Xamarin.Forms;

namespace Imi.Project.Mobile.Converters
{
    public class ItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is ItemTappedEventArgs eventArgs))
                throw new ArgumentException("Expected TappedEventArgs as value", "value");
            //Item contains the tapped item
            return eventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}