using System;
using System.Collections.Generic;

namespace AppSys.Utility.Extensions
{
    public static class StringArrayExtension
    {
        /// <summary>
        /// 返回去重后的数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string[] GetDistinctData(this string[] data)
        {
            List<string> result = new List<string>();
            Array.Sort(data);
            string lastData = null;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Equals(lastData))
                    continue;
                lastData = data[i];
                result.Add(lastData);
            }
            return result.ToArray();
        }
    }
}
