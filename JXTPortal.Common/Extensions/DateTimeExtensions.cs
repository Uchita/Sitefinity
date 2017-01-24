using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static double ToEpocTimestamp(this DateTime date)
        {
            DateTime epoc = new DateTime(1970, 1, 1, 0, 0, 0);

            var diff = date - epoc;

            return diff.TotalMilliseconds;      
        }

        public static double? ToEpocTimestamp(this DateTime? date)
        {
            if (!date.HasValue)
            {
                return null;
            }

            DateTime epoc = new DateTime(1970, 1, 1, 0, 0, 0);

            var diff = date.Value - epoc;

            return diff.TotalMilliseconds;
        }
    }
}
