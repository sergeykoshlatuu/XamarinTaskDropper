using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TaskDropper.Forms.Convertors
{
    public class BoolToImageSourceConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource retSource = null;
            if (value != null)
            {
                bool isChecked = (bool)value;
                if (isChecked == true)
                {
                    retSource = ImageSource.FromResource("Checked");
                    return "Checked";
                }
                if (isChecked == false)
                {
                    retSource = ImageSource.FromResource("Unchecked");
                    return "Unchecked";
                }
            }
        return retSource;  
        }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        
    }
}
