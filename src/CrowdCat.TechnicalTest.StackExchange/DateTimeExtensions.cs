using System;

namespace CrowdCat.TechnicalTest.StackExchange
{
    public static class DateTimeExtensions
    {
        public static DateTime FromUnixTimeStampToDateTime(this double unixTimeStamp) =>
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(unixTimeStamp);

        public static DateTime FromUnixTimeStampToDateTime(this int unixTimeStamp) =>
            new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(unixTimeStamp);

        public static double ToUnixTimestamp(this DateTime dateTime) => dateTime
            .Subtract(new DateTime(1970, 1, 1))
            .TotalSeconds;
    }
}