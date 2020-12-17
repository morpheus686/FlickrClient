using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FlickrClient.Components.Converter
{
    public class BooleanToSymbolConverter : IValueConverter
    {  
        public PackIconKind TrueIcon { get; set; }
        public PackIconKind FalseIcon { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;

            if (boolValue)
            {
                return TrueIcon;
            }

            return FalseIcon;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
