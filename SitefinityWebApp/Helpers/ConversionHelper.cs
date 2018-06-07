using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JXTNext.Sitefinity.Mvc.Helpers
{
    public class ConversionHelper
    {
        public static double GetUnixTimestamp(DateTime Date, bool IsMilliSeconds = false)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = Date.ToUniversalTime() - origin;

            return (IsMilliSeconds ? Math.Floor(diff.TotalMilliseconds) : Math.Floor(diff.TotalSeconds));
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