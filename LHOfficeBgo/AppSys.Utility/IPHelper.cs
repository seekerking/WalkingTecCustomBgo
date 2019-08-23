namespace AppSys.Utility
{
    /// <summary>
    /// IP地址帮助类
    /// </summary>
    public static class IPHelper
    {
        #region 将IP地址转换为整数
        /// <summary>
        /// 将IP地址转换为整数
        /// </summary>
        /// <param name="ip">待转换IP地址</param>
        /// <returns>转换结果</returns>
        public static int IPToInt(this string ip)
        {
            if (string.IsNullOrEmpty(ip) || !ip.IsIP())
            {
                return 0;
            }
            char[] dot = new char[] { '.' };
            string[] ipArr = ip.Split(dot);
            if (ipArr.Length == 3)
                ip = ip + ".0";
            ipArr = ip.Split(dot);

            int ip_Int = 0;
            int p1 = ipArr[0].ToInt32(0);
            int p2 = ipArr[1].ToInt32(0) * 256;
            int p3 = ipArr[2].ToInt32(0) * 256 * 256;
            int p4 = ipArr[3].ToInt32(0) * 256 * 256 * 256;
            ip_Int = p1 + p2 + p3 + p4;
            return ip_Int;
        }



        /// <summary>
        /// 将IP地址转换为长整数
        /// </summary>
        /// <param name="ip">待转换IP地址</param>
        /// <returns>转换结果</returns>
        public static long IPToLong(this string ip)
        {
            if (string.IsNullOrEmpty(ip) || !ip.IsIP())
            {
                return 0;
            }
            char[] dot = new char[] { '.' };
            string[] ipArr = ip.Split(dot);
            if (ipArr.Length == 3)
                ip = ip + ".0";
            ipArr = ip.Split(dot);

            long ip_Int = 0;
            long p1 = long.Parse(ipArr[0]) * 256 * 256 * 256;
            long p2 = long.Parse(ipArr[1]) * 256 * 256;
            long p3 = long.Parse(ipArr[2]) * 256;
            long p4 = long.Parse(ipArr[3]);
            ip_Int = p1 + p2 + p3 + p4;
            return ip_Int;
        }

        #endregion

        #region 将Int数据转换成IP字符串
        /// <summary>
        /// 将Int数据转换成IP字符串
        /// </summary>
        /// <param name="ip">Int数据</param>
        /// <returns>IP字符串</returns>
        public static string IntToIP(this int ip)
        {
            string sIP = "";
            uint t = 0;
            uint uip = (uint)ip;
            for (int i = 3; i >= 0; i--)
            {
                uint powIP = 1;
                for (int j = 0; j < i; j++)
                {
                    powIP *= 256;
                }
                t = uip / powIP;

                sIP = t.ToString() + "." + sIP;
                uip = uip - t * powIP;
            }
            sIP = sIP.Substring(0, sIP.Length - 1);
            return sIP;
        }
        #endregion

        #region 将Long数据转换成IP字符串
        /// <summary>
        /// 将Long数据转换成IP字符串
        /// </summary>
        /// <param name="ip_Int">Long格式IP</param>
        /// <returns>IP字符串</returns>
        public static string LongToIP(this long ip_Int)
        {
            long seg1 = (ip_Int & 0xff000000) >> 24;
            if (seg1 < 0)
                seg1 += 0x100;
            long seg2 = (ip_Int & 0x00ff0000) >> 16;
            if (seg2 < 0)
                seg2 += 0x100;
            long seg3 = (ip_Int & 0x0000ff00) >> 8;
            if (seg3 < 0)
                seg3 += 0x100;
            long seg4 = (ip_Int & 0x000000ff);
            if (seg4 < 0)
                seg4 += 0x100;
            string ip = seg1.ToString() + "." + seg2.ToString() + "." + seg3.ToString() + "." + seg4.ToString();

            return ip;
        }
        #endregion
    }
}
