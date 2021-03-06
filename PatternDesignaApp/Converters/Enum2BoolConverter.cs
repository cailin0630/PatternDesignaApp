﻿using PatternDesignaApp.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace PatternDesignaApp.Converters
{
    public class LanguageEnum2BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            var l = (Language)value;
            return l.ToString() == parameter?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}