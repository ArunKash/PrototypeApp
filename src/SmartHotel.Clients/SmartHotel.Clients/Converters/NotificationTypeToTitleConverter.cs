using SmartHotel.Clients.Core.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SmartHotel.Clients.Core.Converters
{
    public class NotificationTypeToTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is NotificationType)
            {
                var notificationType = (NotificationType)value;

                switch(notificationType)
                {
                    case NotificationType.BeGreen:
                        return "TouchPoint Program #1";
                    case NotificationType.Hotel:
                        return "TouchPoint Program #2";
                    case NotificationType.Room:
                        return "TouchPoint Program #3";
                    case NotificationType.Other:
                        return "TouchPoint Program #4";
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
