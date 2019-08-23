using System.Collections.Generic;
using System.Linq;

namespace AppSys.Utility.Extensions
{
    public static class UtilsExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null || !enumerable.Any())
            {
                return true;
            }

            return false;
        }
        
        public static string CutIfTooLong(this string str, int len = 400)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > len)
            {
                return str.Substring(0, len);
            }

            return str;
        }

        public static string TrimOrEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }

            return str.Trim();
        }
    }
}
