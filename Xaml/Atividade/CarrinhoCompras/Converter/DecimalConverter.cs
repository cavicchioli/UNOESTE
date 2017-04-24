using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace CarrinhoCompras.Converter
{
    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            decimal dec = (decimal)value;
            return dec.ToString("C2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            string strValue = value as string;
            decimal resultDecimal;
            if (decimal.TryParse(strValue, out resultDecimal))
            {
                return resultDecimal;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
