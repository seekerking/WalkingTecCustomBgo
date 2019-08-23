using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AppSys.Utility.Enum
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumHelper
    {
        class EnumCache<T> : ReaderWriterCache<Type, Dictionary<T, EnumItem<T>>>
        {
            public Dictionary<T, EnumItem<T>> GetEnumMap(Type t, Creator<Dictionary<T, EnumItem<T>>> cr)
            {
                return FetchOrCreateItem(t, cr);
            }
        }

        #region 私有成员
        //  static readonly EnumCache instance = new EnumCache();

        static ConcurrentDictionary<Type, object> concurrentDic = new ConcurrentDictionary<Type, object>();
        //static object lockpad = new object();

        static EnumCache<T> GetInstance<T>()
        {
            object obj = null;
            if (concurrentDic.TryGetValue(typeof(T), out obj))
            {
                return (EnumCache<T>)obj;
            }
            else
            {
                EnumCache<T> instance = new EnumCache<T>();
                concurrentDic.TryAdd(typeof(T), instance);
                return instance;
            }
        }

        static Dictionary<T, EnumItem<T>> fetchOrCreateEnumMap<T>(Type t)
        {
            return GetInstance<T>().GetEnumMap(t, () => createEnumMap<T>(t));
        }
        static Dictionary<T, EnumItem<T>> createEnumMap<T>(Type t)
        {
            Dictionary<T, EnumItem<T>> map = new Dictionary<T, EnumItem<T>>();
            FieldInfo[] fields = t.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo f in fields)
            {
                T v = f.GetValue(null).ToType<T>();
                DescriptionAttribute[] ds = (DescriptionAttribute[])f.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (ds.Length > 0)
                {
                    map[v] = new EnumItem<T> { Value = v, Description = ds[0].Description, EnumName = f.Name };
                }
                else {
                    map[v] = new EnumItem<T> { Value = v, Description = string.Empty, EnumName = f.Name };
                }
            }
            return map;
        }


        #endregion

        /// <summary>
        /// 返回该枚举类型的所有枚举项成员以及描述 
        /// </summary>
        /// <typeparam name="TEnumType">枚举类型</typeparam>
        /// <typeparam name="T">int或者long</typeparam>
        /// <returns>枚举的所有项的描述信息</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     public enum UserType{
        ///     
        ///         [Description("普通会员")]
        ///         Normal=0,
        ///         
        ///         [Description("高级会员")]
        ///         VIP=1
        ///     }
        ///     
        ///     List<EnumItem<int>> list=EnumHelper.GetTypeItemList<UserType,int>();
        ///     //返回：[{Value:0,Description:"普通会员",EnumName:"Normal"},{Value:1,Description:"高级会员",EnumName:"VIP"}]
        /// ]]>
        /// </code>
        /// </example>
        public static List<EnumItem<T>> GetTypeItemList<TEnumType, T>()
        {
            Type t = typeof(TEnumType);
            return fetchOrCreateEnumMap<T>(t).Values.ToList();
        }

        /// <summary>
        /// 返回该枚举类型的所有枚举项成员以及描述
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <typeparam name="T">int或者long</typeparam>
        /// <returns>枚举的所有项的描述信息</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     public enum UserType{
        ///     
        ///         [Description("普通会员")]
        ///         Normal=0,
        ///         
        ///         [Description("高级会员")]
        ///         VIP=1
        ///     }
        ///     
        ///     List<EnumItem<int>> list=EnumHelper.GetTypeItemList<int>(typeof(UserType));
        ///     //返回：[{Value:0,Description:"普通会员",EnumName:"Normal"},{Value:1,Description:"高级会员",EnumName:"VIP"}]
        /// ]]>
        /// </code>
        /// </example>

        public static List<EnumItem<T>> GetTypeItemList<T>(Type type)
        {
            return fetchOrCreateEnumMap<T>(type).Values.ToList();
        }

        /// <summary>
        ///返回单枚举值的描述信息
        /// </summary>
        /// <param name="v">枚举值</param>
        /// <returns>枚举值的描述信息</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     public enum UserType{
        ///     
        ///         [Description("普通会员")]
        ///         Normal=0,
        ///         
        ///         [Description("高级会员")]
        ///         VIP=1
        ///     } 
        ///     string desc=UserType.Normal.GetDescription();   //返回:普通会员
        /// ]]>
        /// </code>
        /// </example>
        public static string GetDescription(this System.Enum v)
        {
            Type t = v.GetType();
            var map = fetchOrCreateEnumMap<long>(t);
            EnumItem<long> item;
            if (map.TryGetValue(Convert.ToInt64(v), out item))
            {
                return item.Description;
            }
            return string.Empty;
        }

        /// <summary>
        /// 返回按位组合枚举值 所构成的每一个值
        /// </summary>
        /// <param name="values">枚举值</param>
        /// <returns>枚举值集合</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     [Flags]
        ///     public enum UserType{
        ///         
        ///         Normal=0,
        ///         
        ///         VIP=1,
        ///         
        ///         VIP2=2,
        ///         
        ///         VIP3=4,
        ///         
        ///         VIP4=8
        ///     }
        ///     
        ///     UserType userType=UserType.VIP1|UserType.VIP3;  //1,4
        ///     
        ///     var list =userType.GetValues();
        ///       //返回：[1,4]
        /// ]]>
        /// </code>
        /// </example>
        public static List<long> GetValues(this System.Enum values)
        {
            Type t = values.GetType();
            long lv = Convert.ToInt64(values);
            Dictionary<long, EnumItem<long>> _map = fetchOrCreateEnumMap<long>(t);
            var items = new List<long>();
            foreach (var item in _map)
            {
                var v = item.Key;
                if ((v & lv) == v)
                {
                    items.Add(v);
                }
            }
            return items;
        }

        /// <summary>
        ///  返回将按位组合枚举值的每一个值描述连接起来的字符串
        /// </summary>
        /// <param name="v">枚举值</param>
        /// <returns>描述信息</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     [Flags]
        ///     public enum UserType{
        ///         [Description("普通会员")]
        ///         Normal=0,
        ///         
        ///         [Description("普通VIP")]
        ///         VIP=1,
        ///         
        ///         [Description("一级VIP")]
        ///         VIP2=2,
        ///         
        ///         [Description("二级VIP")]
        ///         VIP3=4,
        ///         
        ///         [Description("三级VIP")]
        ///         VIP4=8
        ///     }
        ///     
        ///     UserType userType=UserType.VIP1|UserType.VIP3;  //1,4
        ///     
        ///     var string =userType.GetDescriptions();
        ///       //返回： 普通VIP,二级VIP
        /// ]]>
        /// </code>
        /// </example>
        public static string GetDescriptions(this System.Enum v)
        {
            Type t = v.GetType();
            Dictionary<long, EnumItem<long>> _map = fetchOrCreateEnumMap<long>(t);
            long lv = Convert.ToInt64(v);
            StringBuilder sb = new StringBuilder();
            var emtor = _map.Where(i => (i.Key & lv) == i.Key).GetEnumerator();
            if (emtor.MoveNext())
            {
                sb.Append(emtor.Current.Value.Description);
            }
            while (emtor.MoveNext())
            {
                sb.AppendFormat(",{0}", emtor.Current.Value.Description);
            }
            return sb.ToString();
        }

    }
}
