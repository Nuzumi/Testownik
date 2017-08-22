using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Testownik.Model;

namespace Testownik.Converters
{
    class QuestionToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Question)
            {
                if((value as Question).Content != null)
                {
                    return (value as Question).Content;
                }
                else
                {
                    return "pytanie nie ma tresci";
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Question { Content = value.ToString() };
        }
    }
}
