using System;
using System.Text;

namespace AppSys.Utility
{
    /// <summary>
    /// 对 StringBuilder的扩展
    /// </summary>
    public static class StringBuilderHelper
    {
        /// <summary>
        /// 确定此实例的开头是否与指定的字符串匹配
        /// </summary>
        /// <param name="builder">StringBuilder的引用</param>
        /// <param name="value">要比较的 System.String</param>
        /// <param name="stringComparison">方法的某些重载要使用的区域、大小写和排序规则。</param>
        /// <returns>是否以某些字符开始</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     StringBuilder strB=new StringBuilder("中国浙江杭州");
        ///     bool ret=strB.StartsWith("中国"); //TRUE
        /// ]]>
        /// </code>
        /// </example>
        public static bool StartsWith(this StringBuilder builder, string value, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");

            if (value == null)
                throw new ArgumentNullException("value");

            if (value.Length == 0)
                return true;

            if (value.Length > builder.Length)
                return false;

            return builder.ToString(0, value.Length).Equals(value, stringComparison);

        }

        /// <summary>
        /// 确定此实例的结尾是否与指定的字符串匹配
        /// </summary>
        /// <param name="builder">StringBuilder的引用</param>
        /// <param name="value">要比较的 System.String</param>
        /// <param name="stringComparison">方法的某些重载要使用的区域、大小写和排序规则。</param>
        /// <returns>是否以某些字符串结束</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     StringBuilder strB=new StringBuilder("中国浙江杭州");
        ///     bool ret=strB.StartsWith("杭州"); //TRUE
        /// ]]>
        /// </code>
        /// </example>
        public static bool EndsWith(this StringBuilder builder, string value, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");

            if (value == null)
                throw new ArgumentNullException("value".TrimEnd());

            if (value.Length == 0)
                return true;

            if (value.Length > builder.Length)
                return false;

            return builder.ToString(builder.Length - value.Length, value.Length).Equals(value, stringComparison);

        }
        /// <summary>
        /// 从当前 StringBuilder 对象移除数组中指定的一组字符的所有尾部匹配项。
        /// </summary>
        /// <param name="builder">StringBuilder的引用</param>
        /// <param name="trimStr">要移除的 Unicode 字符数组或 null。</param>
        /// <param name="stringComparison">方法的某些重载要使用的区域、大小写和排序规则。</param>
        /// <returns>返回移除尾部数据后的项</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     StringBuilder strB=new StringBuilder("中国浙江杭州");
        ///     StringBuilder ret=strB.TrimEnd("杭州"); //返回："中国浙江"
        /// ]]>
        /// </code>
        /// </example>
        public static StringBuilder TrimEnd(this StringBuilder builder, string trimStr, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(trimStr))
            {
                return builder;
            }
            while (builder.EndsWith(trimStr, stringComparison))
            {
                builder = builder.Remove(builder.Length - trimStr.Length, trimStr.Length);
            }
            return builder;
        }

        /// <summary>
        /// 从当前 StringBuilder 对象移除数组中指定的一组字符的所有首部匹配项。
        /// </summary>
        /// <param name="builder">StringBuilder的引用</param>
        /// <param name="trimStr">要移除的 Unicode 字符数组或 null。</param>
        /// <param name="stringComparison">方法的某些重载要使用的区域、大小写和排序规则。</param>
        /// <returns>返回移除尾部数据后的项</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     StringBuilder strB=new StringBuilder("中国浙江杭州");
        ///     StringBuilder ret=strB.TrimStart("中国"); //返回："浙江杭州"
        /// ]]>
        /// </code>
        /// </example>
        public static StringBuilder TrimStart(this StringBuilder builder, string trimStr, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(trimStr))
            {
                return builder;
            }
            while (builder.StartsWith(trimStr, stringComparison))
            {
                builder = builder.Remove(0, trimStr.Length);              
            }
            return builder;
        }
    }
}
