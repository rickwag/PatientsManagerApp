using System;
using System.Globalization;
using System.Windows.Data;

namespace PatientsManager.Converters
{
    public class DateOfBirthToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return ConvertFromDateToAge((DateTime)value);
            else
                return "null";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public string ConvertFromDateToAge(DateTime dateOfBirth)
        {
            if (dateOfBirth != null)
            {
                var age = DateTime.Today.Year - dateOfBirth.Year;
                return age.ToString();
            }
            else return "";
        }
    }
}
