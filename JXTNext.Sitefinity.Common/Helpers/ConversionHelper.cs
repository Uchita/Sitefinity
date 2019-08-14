using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JXTNext.Sitefinity.Common.Helpers
{
    public class ConversionHelper
    {
        public static double GetUnixTimestamp(DateTime Date, bool IsMilliSeconds = false)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = Date.ToUniversalTime() - origin;

            return (IsMilliSeconds ? Math.Floor(diff.TotalMilliseconds) : Math.Floor(diff.TotalSeconds));
        }

        public static DateTime GetDateTimeFromUnix(double unixTimeStamp, string timeZoneId = "")
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

            try
            {
                dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp);

                if (!string.IsNullOrWhiteSpace(timeZoneId))
                {
                    TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                    return TimeZoneInfo.ConvertTimeFromUtc(dtDateTime, zone);
                }

                return dtDateTime;
            }
            catch (Exception ex)
            {
                return dtDateTime;
            }
        }

        public static byte[] StreamToBytes(Stream InStream)
        {
            if (InStream is MemoryStream)
                return ((MemoryStream)InStream).ToArray();

            using (var memoryStream = new MemoryStream())
            {
                InStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}