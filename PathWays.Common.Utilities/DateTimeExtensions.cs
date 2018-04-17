using System;
using System.Collections.Generic;
using System.Text;

namespace PathWays.Common.Utilities
{
    public static class DateTimeExtensions
    {
        public static DateTime GetCmDateTime(this DateTime dt)
        {
            return Convert.ToDateTime(dt.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ"));
        }

        public static string ToCmDateTimeString(this DateTime? dt)
        {
            if (!dt.HasValue)
            {
                return string.Empty;
            }

            return dt.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ");
        }

        public static string ToCmDateTimeString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ");
        }

        public static bool CompareDateParts(DateTime? dt1, DateTime? dt2)
        {
            if (dt1.HasValue && dt2.HasValue)
            {
                return dt1.Value.Year == dt2.Value.Year
                    && dt1.Value.Month == dt2.Value.Month
                    && dt1.Value.Day == dt2.Value.Day;
            }

            return false;
        }
    }
}
