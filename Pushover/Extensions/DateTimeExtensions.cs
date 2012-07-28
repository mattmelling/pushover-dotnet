using System;

namespace Pushover.Extensions
{
    static class DateTimeExtensions
    {
        private readonly static DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert a date time to Unix epoch date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static Int64 ToEpoch(this DateTime date)
        {
            return Convert.ToInt64((date.ToUniversalTime() - Epoch).TotalSeconds);
        }
    }
}
