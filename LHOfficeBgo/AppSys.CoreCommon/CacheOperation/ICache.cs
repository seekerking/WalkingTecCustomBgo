using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace AppSys.CoreCommon.CacheOperation
{
    public interface ICache
    {
        /// <summary>
        /// redis实例
        /// </summary>
        IDatabase DB { get; }

        bool AddExpireTime(string key, TimeSpan timeSpan);
        TimeSpan? KeyTimeToLive(string key);

        #region Lock

        bool Lock(string key, string value, TimeSpan expiry);
        bool UnLock(string key, string value);
     
        #endregion

        #region String

        string StringGet(string key);
        Task<string> StringGetAsync(string key);

        T StringGet<T>(string key);
        Task<T> StringGetAsync<T>(string key);

        bool StringSet(string key, string value, TimeSpan? timeSpan = null);
        Task<bool> StringSetAsync(string key, string value, TimeSpan? timeSpan = null);

        bool StringSet<T>(string key, T entity, TimeSpan? timeSpan = null);

        Dictionary<string, string> StringBatchGetAsync(List<string> keys);

        Dictionary<string, T> StringBatchGetAsync<T>(List<string> keys);

        void StringBatchSetAsync(Dictionary<string, string> dic, TimeSpan? timeSpan = null);

        void StringBatchSetAsync<T>(Dictionary<string, T> list, TimeSpan? timeSpan = null);

        long StringAppend(string key, string value);

        long StringIncrement(string key);

        long StringIncrementCount(string key, long value = 1);

        double StringIncrementCount(string key, double value = 1);

        long StringDecrement(string key);

        long StringDecrementCount(string key, long value = 1);

        double StringDecrement(string key, double value = 1);

        long StringGetLength(string key);

        #endregion

        #region Hash

        bool HashFieldExsits(string key, string fieldName);

        string HashGet(string key, string hashField);
        Task<string> HashGetAsync(string key, string hashField);

        Dictionary<string, string> HashGetAll(string key);
        Task<Dictionary<string, string>> HashGetAllAsync(string key);

        T HashGetAll<T>(string key) where T : class, new();

        bool HashSet(string key, string hashField, string value);

        void HashSet(string key, Dictionary<string, string> hashFields);
        Task HashSetAsync(string key, Dictionary<string, string> hashFields);
        void HashSetField(string key, string fieldName, string value);

        void HashSetField<T>(string key, string fieldName, string value);

        long HashIncr(string key, string hashField, long value = 1);

        bool HashFieldRemove(string key, string fieldName);

        #endregion

        bool KeyExsists(string key);
        Task<bool> KeyExsistsAsync(string key);

        bool RemoveKey(string key);
        Task<bool> RemoveKeyAsync(string key);

        bool SetExpireTime(string key, TimeSpan timeSpan);
        Task<bool> SetExpireTimeAsync(string key, TimeSpan timeSpan);


    }
}
