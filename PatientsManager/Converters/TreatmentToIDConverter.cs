using System;
using System.Globalization;
using System.Windows.Data;
using PatientsManager.Models;

namespace PatientsManager.Converters
{
    public class TreatmentToIDConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Treatment)
                return (value as Treatment).TreatmentID;
            else
                return 0;
        }
    }
}
