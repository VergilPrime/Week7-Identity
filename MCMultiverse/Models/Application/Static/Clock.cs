using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Models.Application.Static
{
    public static class Clock
    {
        // Return UnixTimestamp in MS from current time
        public static int Time()
        {
            return (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        }

        // Return UnixTimestamp in MS from specified time
        public static int Time(DateTime datetime)
        {
            return (int)(datetime.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        }

        // Convert miliseconds to DateTime
        public static DateTime DateT(int ms)
        {
            return new DateTime(1970, 1, 1).AddMilliseconds(ms);
        }
    }
}
