using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDropper.Core.Convertors
{
    public class BooleanTrueToFalseConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
