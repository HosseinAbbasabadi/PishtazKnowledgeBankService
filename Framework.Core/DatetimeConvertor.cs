using System;
using System.Globalization;

namespace Framework.Core
{
    public static class DatetimeConvertor
    {
        public static DateTime ConvertToPersianDate(DateTime datetime)
        {
            var gregorianDate = new GregorianCalendar();
            var persianCalendar = new PersianCalendar();
            return new DateTime(persianCalendar.GetYear(datetime), gregorianDate.GetMonth(datetime),
                gregorianDate.GetDayOfMonth(datetime), persianCalendar.GetHour(datetime),
                persianCalendar.GetMinute(datetime), persianCalendar.GetSecond(datetime),gregorianDate);
            //return
            //    $"{persianCalendar.GetYear(datetime)}/{persianCalendar.GetMonth(datetime)}/{persianCalendar.GetDayOfMonth(datetime)}";
        }

        public static DateTime ConvertToGregorianDate(string value, int hour)
        {
            var datetime = DateTime.Parse(value);
            var gregorianDate = new GregorianCalendar();
            var persianCalendar = new PersianCalendar();
            return new DateTime(gregorianDate.GetYear(datetime), gregorianDate.GetMonth(datetime),
                gregorianDate.GetDayOfMonth(datetime), hour, 00, 00, persianCalendar);
        }
    }
}