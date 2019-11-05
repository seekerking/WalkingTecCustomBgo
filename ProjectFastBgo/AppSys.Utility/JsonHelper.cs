using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AppSys.Utility
{
    /// <summary>
    /// Json格式化帮助类
    /// </summary>
    public static class JsonHelper
    {
        #region Json反序列化
        /// <summary>
        /// 将指定的 JSON 字符串转换为 T 类型的对象
        /// </summary>
        /// <typeparam name="T">所生成对象的类型</typeparam>
        /// <param name="str">要进行反序列化的 JSON 字符串</param>
        /// <returns>反序列化的对象</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     string str="{\"ID\":1,\"Name\":\"名称\"}";
        ///     
        ///     UserInfo user=str.JSONDeserialize<UserInfo>();
        /// 
        /// ]]>
        /// </code>
        /// </example>
        public static T JSONDeserialize<T>(this string str)
        {

            if (str == null)
                throw new ArgumentNullException("str");

            return JsonConvert.DeserializeObject<T>(str);

        }

        /// <summary>
        /// 将指定的 JSON 字符串转换为对象图
        /// </summary>
        /// <param name="str">要进行反序列化的 JSON 字符串</param>
        /// <returns>反序列化对象</returns>
        /// <example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     string str="{\"ID\":1,\"Name\":\"名称\"}";
        ///     
        ///     object user=str.JSONDeserialize();
        /// 
        /// ]]>
        /// </code>
        /// </example>
        public static object JSONDeserialize(this string str)
        {
            if (str == null)
                throw new ArgumentNullException("str");
            return JsonConvert.DeserializeObject(str);
        }
        #endregion

        #region Json序列化
        /// <summary>
        /// 将对象进行JSON格式序列化，dynamic 对象不支持该扩展方法调用，只能使用静态方法调用
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <returns>JSON字符串</returns>
        ///<example>
        /// <code lang="c#">
        /// <![CDATA[
        ///     UserInfo user=new UserInfo{ID=1,Name="名称"};
        ///     
        ///     string str=user.JSONSerialize();
        ///     
        ///     //dynamic 对象不支持该扩展方法调用，只能使用静态方法调用，如下：
        ///     
        ///     dynamic user1=new{ ID=1,Name="名称"};
        ///     
        ///     string str1=JsonHelper.JSONSerialize(user1); //正确
        ///     
        ///     string str2=user1.JSONSerialize();  //错误，不支持
        /// 
        /// ]]>
        /// </code>
        /// </example>
        public static string JSONSerialize(this object obj)
        {
            return JsonConvert.SerializeObject(obj,new JsonSerializerSettings(){ContractResolver = new CamelCasePropertyNamesContractResolver(),NullValueHandling = NullValueHandling.Ignore});
        }
        #endregion



        /// <summary>
        /// 将Json字符串转换为对象
        /// </summary>
        /// <param name="json">Json字符串</param>
        public static T ToObject<T>(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static T ToModel<T>(this string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                    return default(T);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public T ToModel<T>(this string s, T model)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public object ToModel(this string json, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(json, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将对象转换为Json字符串
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <param name="isConvertSingleQuotes">是否将双引号转成单引号</param>
        /// <param name="dateTimeFormat">如果将数据精确存储则使用默认的字符串输出方式，如果想自定义输出，在需要写上自定义输出格式</param>
        public static string ToJson(this object target, bool isConvertSingleQuotes = false,string dateTimeFormat=null)
        {
            if (target == null) return "";
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            if (!dateTimeFormat.IsNullOrEmpty())
            {
                jsSettings.DateFormatString = dateTimeFormat;
            }
            //忽略空值
            jsSettings.NullValueHandling = NullValueHandling.Ignore;
            var result = JsonConvert.SerializeObject(target, Formatting.None, jsSettings);
            if (isConvertSingleQuotes)
                result = result.Replace("\"", "'");
            return result;
        }

        /// <summary>
        /// 将对象转换为Json字符串，并且去除两侧括号
        /// </summary>
        /// <param name="target">目标对象</param>
        /// <param name="isConvertSingleQuotes">是否将双引号转成单引号</param>
        public static string ToJsonWithoutBrackets(this object target, bool isConvertSingleQuotes = false)
        {
            var result = ToJson(target, isConvertSingleQuotes);
            if (result == "{}")
                return result;
            return result.TrimStart('{').TrimEnd('}');
        }

        /// <summary>
        ///   n1=value1&n2=value2  转Json 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static public string ToJsonByForm(this string s)
        {
            Dictionary<string, string> dicdata = new Dictionary<string, string>();
            try
            {
                var data = s.Split('&');
                for (int i = 0; i < data.Length; i++)
                {
                    var dk = data[i].Split('=');
                    StringBuilder sb = new StringBuilder(dk[1]);
                    for (int j = 2; j <= dk.Length - 1; j++)
                        sb.Append(dk[j]);
                    dicdata.Add(dk[0], sb.ToString());
                }
            }
            catch
            {
            }
            return dicdata.ToJson();
        }

        /// <summary>
        ///   n1=value1&n2=value2  转Json 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static public Dictionary<string, string> ToDictionary(this string s)
        {
            Dictionary<string, string> dicdata = new Dictionary<string, string>();
            try
            {
                var data = s.Split('&');
                for (int i = 0; i < data.Length; i++)
                {
                    var dk = data[i].Split('=');
                    StringBuilder sb = new StringBuilder(dk[1]);
                    for (int j = 2; j <= dk.Length - 1; j++)
                        sb.Append(dk[j]);
                    dicdata.Add(dk[0], sb.ToString());
                }
            }
            catch
            {
            }
            return dicdata;
        }
    }
}
