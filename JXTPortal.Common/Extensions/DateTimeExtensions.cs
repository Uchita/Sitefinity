using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns the total millisecondes between a date and Epoch (01/01/1970)
        /// </summary>
        /// <param name="date">The date calculate the timestamp for</param>
        /// <returns>total millisecondes between  the date and 01/01/1970</returns>
        public static double ToEpocTimestamp(this DateTime date)
        {
            DateTime epoc = new DateTime(1970, 1, 1, 0, 0, 0);

            var diff = date - epoc;

            return diff.TotalMilliseconds;      
        }

        /// <summary>
        /// Returns the total millisecondes between a date and Epoch (01/01/1970)
        /// </summary>
        /// <param name="date">The date calculate the timestamp for</param>
        /// <returns>total millisecondes between  the date and 01/01/1970</returns>
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
