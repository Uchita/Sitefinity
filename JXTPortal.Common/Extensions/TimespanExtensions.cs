using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JXTPortal.Common.Extensions
{
    public static class TimespanExtensions
    {
        public static int TotalYears(this TimeSpan t)
        { 
            DateTime date = DateTime.MinValue + t;
            return date.Year;
        }
        public static int TotalMonths(this TimeSpan t)
        {
            DateTime date = DateTime.MinValue + t;
            return date.Month;
        }
    }
}
