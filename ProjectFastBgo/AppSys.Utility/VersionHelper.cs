using System;
using System.Collections.Generic;
using System.Text;

namespace AppSys.Utility
{
   public static class VersionHelper
    {
        /// <summary>
        /// 最大支持3|3|3,一共9位，如果超出则转化失败
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ConvertVersionToInt(this string str)
        {
            int result = 0;
            if (string.IsNullOrEmpty(str))
            {
                return result;
            }
            Version temVersion;
            if (!Version.TryParse(str, out temVersion))
            {
                return result;

            }
            if(temVersion==null)
            {
                return result;

            }

            if (temVersion.Minor > 999 || temVersion.Major > 999 || temVersion.Build > 999)
            {
                return result;
            }

            result += temVersion.Build;
            result += temVersion.Minor * 1000;
            result += temVersion.Major * 1000000;


            return result;


        }
    }
}
