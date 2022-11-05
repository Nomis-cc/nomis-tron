namespace Nomis.Tronscan.Extensions
{
    /// <summary>
    /// Extension methods for converting DateTime.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Convert Unix TimeStamp to DateTime.
        /// </summary>
        /// <param name="unixTimeStamp">Unix TimeStamp in string.</param>
        /// <returns><see cref="DateTime"/>.</returns>
        public static DateTime ToTronDateTime(this string unixTimeStamp)
        {
            var unixTimeStampLong = long.Parse(unixTimeStamp);
            var beginTicks = DateTime.UnixEpoch.Ticks;
            return new DateTime(beginTicks + unixTimeStampLong * 10000, DateTimeKind.Utc).ToLocalTime();
        }

        /// <summary>
        /// Convert Unix TimeStamp to DateTime.
        /// </summary>
        /// <param name="unixTimeStampLong">Unix TimeStamp in long.</param>
        /// <returns><see cref="DateTime"/>.</returns>
        public static DateTime ToTronDateTime(this long unixTimeStampLong)
        {
            var beginTicks = DateTime.UnixEpoch.Ticks;
            return new DateTime(beginTicks + unixTimeStampLong * 10000, DateTimeKind.Utc).ToLocalTime();
        }
    }
}