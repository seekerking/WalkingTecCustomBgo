using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace AppSys.Utility
{
    /// <summary>
    /// DataReader扩展方法,实现高性能的ORM
    /// </summary>
    /// <remarks>
    /// <para>
    ///     在实体对象的转换中，若需要支持Enum类型的，请确保数据库字段类型为tinyint
    /// </para>
    /// </remarks>
    public static class DataReaderHelper
    {

        /// <summary>
        /// 获取DataReader某列数据(不会进行DataReader合法性判断)
        /// </summary>
        /// <typeparam name="T">需要返回的数据类型</typeparam>
        /// <param name="dr">DataReader</param>
        /// <param name="columnName">列名</param>
        /// <param name="defaultVal">默认值</param>
        /// <returns>列值</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     
        ///     string sql="select ID,Name from user where ID=1";
        ///     using(SqlDataReader dr=SqlHelper.ExceuteDataReader(conn,CommandType.Text,sql)){
        ///         if(dr.Read()){
        ///             int id=dr.GetColumnValue<int>("ID",0);
        ///             string name=dr.GetColumnValue<string>("Name");
        ///         }
        ///     }
        /// ]]>
        /// </code>
        /// </example>
        public static T GetColumnValue<T>(this IDataReader dr, string columnName,T defaultVal) {
            return dr[columnName].ToType<T>(defaultVal);
        }

        /// <summary>
        /// 装载实体对象
        /// </summary>
        /// <typeparam name="T">实体对象类型</typeparam>
        /// <param name="dr">SqlDataReader对象</param>
        /// <param name="action">自定义操作</param>
        /// <returns>实体对象</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     public class UserInfo{
        ///         public int ID{get;set;}
        ///         public string Name{get;set;}
        ///     }
        ///     
        ///     string sql="select ID,Name from user where ID=1";
        ///     using(SqlDataReader dr=SqlHelper.ExceuteDataReader(conn,CommandType.Text,sql)){
        ///         UserInfo user=dr.ToEntity();
        ///     }
        /// ]]>
        /// </code>
        /// </example>
        public static T ToEntity<T>(this IDataReader dr, Action<T, IDataReader> action = null)
        {
            if (dr == null)
            {
                return default(T);
            }
            
            if (dr.Read())
            {
                IDictionary<string, Func<T, object, object>> dic = GetMap<T>();
                T model = Activator.CreateInstance<T>();
                LoadEntity(dr, dic, ref model);
                if (action != null)
                {
                    action(model, dr);
                }
                return model;
            }
            return default(T);
        }

        /// <summary>
        /// 装载实体
        /// </summary>
        /// <typeparam name="T">实体对象类型</typeparam>
        /// <param name="dr">SqlDataReader对象</param>
        /// <param name="action">自定义操作</param>
        /// <param name="model">实体对象</param>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     public class UserInfo{
        ///         public int ID{get;set;}
        ///         public string Name{get;set;}
        ///         
        ///         public string Phone{get;set;}
        ///     }
        ///      UserInfo user;
        ///     string sql="select ID,Name from user where ID=1";
        ///     using(SqlDataReader dr=SqlHelper.ExceuteDataReader(conn,CommandType.Text,sql)){
        ///          user=dr.ToEntity();
        ///     }
        ///     sql="select phone from usercontact where UserID=1";
        ///     using(SqlDataReader dr=SqlHelper.ExceuteDataReader(conn,CommandType.Text,sql)){
        ///         dr.ToEntity(ref user);
        ///     }
        /// ]]>
        /// </code>
        /// </example>        
        public static void ToEntity<T>(this IDataReader dr, ref T model, Action<T, IDataReader> action = null)
        {
            if (dr == null)
            {
                return;
            }
            
            if (dr.Read())
            {
                IDictionary<string, Func<T, object, object>> dic = GetMap<T>();
                if (model.Equals(null))
                {
                    model = Activator.CreateInstance<T>();
                }
                LoadEntity(dr, dic, ref model);
                if (action != null)
                {
                    action(model, dr);
                }
            }
        }


        /// <summary>
        /// 装载实体集合
        /// </summary>
        /// <typeparam name="T">实体对象类型</typeparam>
        /// <param name="dr">SqlDataReader对象</param>
        /// <param name="action">自定义操作</param>
        /// <returns>实体对象集合</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     public class UserInfo{
        ///         public int ID{get;set;}
        ///         public string Name{get;set;}
        ///     }
        ///     
        ///     string sql="select top 10 ID,Name from user";
        ///     using(SqlDataReader dr=SqlHelper.ExceuteDataReader(conn,CommandType.Text,sql)){
        ///         var list=dr.ToEntityList();
        ///     }
        /// ]]>
        /// </code>
        /// </example>
        public static List<T> ToEntityList<T>(this IDataReader dr, Action<T, IDataReader> action = null)
        {
            if (dr == null )
            {
                return null;
            }
            List<T> list = new List<T>();
            IDictionary<string, Func<T, object, object>> dic = GetMap<T>();
            while (dr.Read())
            {
                T model = Activator.CreateInstance<T>();
                LoadEntity(dr, dic, ref model);
                if (action != null)
                {
                    action(model, dr);
                }
                list.Add(model);

            }
            return list;
        }

        /// <summary>
        /// 装载实体
        /// </summary>
        /// <typeparam name="T">实体对象类型</typeparam>
        /// <param name="dr">SqlDataReader对象</param>
        /// <param name="dic">缓存字典</param>
        /// <param name="model">返回实体</param>
        private static void LoadEntity<T>(IDataReader dr, IDictionary<string, Func<T, object, object>> dic, ref T model)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                string fieldName = dr.GetName(i);
                if (dic.ContainsKey(fieldName))
                {
                    object val = dr[fieldName];
                    if (val != null && val != DBNull.Value)
                    {
                        Func<T, object, object> fc = dic[fieldName];
                        fc(model, dr[fieldName]);
                    }
                }
            }
        }

        #region
        static Func<T, object, object> SetDelegate<T>(MethodInfo m, Type type)
        {
            ParameterExpression paramObj = Expression.Parameter(typeof(T), "obj");
            ParameterExpression paramVal = Expression.Parameter(typeof(object), "val");
            UnaryExpression bodyVal = Expression.Convert(paramVal, type);
            MethodCallExpression body = Expression.Call(paramObj, m, bodyVal);
            Action<T, object> set = Expression.Lambda<Action<T, object>>(body, paramObj, paramVal).Compile();

            return (instance, v) =>
            {
                set(instance, v);
                return null;
            };
        }

        static IDictionary<Type, object> dicCache = new Dictionary<Type, object>();
        private static object lockobj = new object();
        static IDictionary<string, Func<T, object, object>> GetMap<T>()
        {
            object dic;
            Type type = typeof(T);

            if (!dicCache.TryGetValue(type, out dic))
            {
                lock (lockobj)
                {
                    if (!dicCache.TryGetValue(type, out dic))
                    {
                        return InitMap<T>(type);
                    }
                }
            }
            return (IDictionary<string, Func<T, object, object>>)dic;
        }
        /// <summary>
        /// 初始化对象映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        private static IDictionary<string, Func<T, object, object>> InitMap<T>(Type type)
        {
            var _dic = new Dictionary<string, Func<T, object, object>>(StringComparer.OrdinalIgnoreCase);
            PropertyInfo[] ps =
                type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                                   BindingFlags.IgnoreCase);
            foreach (PropertyInfo pi in ps)
            {
                MethodInfo setMethodInfo = pi.GetSetMethod(true);
                if (setMethodInfo == null)
                    continue;
                Func<T, object, object> func = SetDelegate<T>(setMethodInfo, pi.PropertyType);
                _dic.Add(pi.Name, func);
            }
            dicCache[type] = _dic;
            return _dic;
        }

        #endregion

    }
}
