using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using PatientsManager.Models;

namespace PatientsManager.Converters
{
    public class PatientToIDConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Patient)
            {
                return (value as Patient).PatientID;
            }
            else
            {
                return value;
            }
        }
    }
}
