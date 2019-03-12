using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TaskDropper.Forms.Convertors
{
    public class BoolToStringConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                bool isChecked = (bool)value;
                if (isChecked == true)
                {
                    
                    return "Checked";
                }
                if (isChecked == false)
                {
                    return "Unchecked";
                }
            }
            return null;
        }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        
    }
}
