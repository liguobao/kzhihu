using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kzhihuWF
{
    class CommonHelper
    {
        /// <summary>
        /// Datetime转Json时间，datetime - 1970.1.1
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int UnixTicks(DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dt.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return (int)ts.TotalSeconds;
        }

        /// <summary>
        /// Json 时间转DateTime
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static DateTime JsonDateToDateTime(int num)
        {
            DateTime time = new DateTime(1970, 1, 1);
            return time.AddSeconds(num);
        }
    }
}
