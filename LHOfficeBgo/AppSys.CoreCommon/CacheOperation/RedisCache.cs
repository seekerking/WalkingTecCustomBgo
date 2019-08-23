using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppSys.CoreCommon.RedisHelper;
using AppSys.Framework.Config;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace AppSys.CoreCommon.CacheOperation
{
    public class RedisCache : ICache
    {

        public RedisCache()
        { }

        public IDatabase DB
        {
            get { return StackExchangeRedisHelper.Instance().GetDatabase(); }
        }
        public string PrefixKey
        {
            get { return ConfigConst.RediesPrefix; }
        }
        private string GetPrefixedKey(string key)
        {
            return string.IsNullOrWhiteSpace(PrefixKey) ? key : $"{PrefixKey}{key}";
        }


        public bool AddExpireTime(string key, TimeSpan timeSpan)
        {
            return DB.KeyExpire(key, timeSpan);
        }
       public bool Lock(string key, string value, TimeSpan expiry)
       {
           return DB.LockTake(key, value, expiry);
       }

        public bool UnLock(string key, string value)
        {
            return DB.LockRelease(key, value);
        }

        public TimeSpan? KeyTimeToLive(string key)
        {
            var tkey = GetPrefixedKey(key);
            return DB.KeyTimeToLive(tkey);
        }

        #region String
        public string StringGet(string key)
        {
            var tkey = GetPrefixedKey(key);
            return DB.StringGet(tkey);
        }

        public async Task<string> StringGetAsync(string key)
        {
            var tkey = GetPrefixedKey(key);
            return await DB.StringGetAsync(tkey);
        }
    

        public T StringGet<T>(string key)
        {
            var value = StringGet(key);
            if (string.IsNullOrEmpty(value))
                return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }

        public async Task<T> StringGetAsync<T>(string key)
        {
            var value =await StringGetAsync(key);
            if (string.IsNullOrEmpty(value))
                return default(T);
            return JsonConvert.DeserializeObject<T>(value);
        }

        public bool StringSet(string key, string value, TimeSpan? timeSpan = null)
        {
            var tkey = GetPrefixedKey(key);
            return DB.StringSet(tkey, value, timeSpan);
        }

        public async Task<bool> StringSetAsync(string key, string value, TimeSpan? timeSpan = null)
        {
            var tkey = GetPrefixedKey(key);
            return await DB.StringSetAsync(tkey, value, timeSpan);
        }

        public bool StringSet<T>(string key, T entity, TimeSpan? timeSpan = null)
        {
            string value = JsonConvert.SerializeObject(entity);
            return StringSet(key, value, timeSpan);
        }

        public Dictionary<string, string> StringBatchGetAsync(List<string> keys)
        {
            var result = new Dictionary<string, Task<RedisValue>>();
            var valueList = new Dictionary<string, string>();

            var batch = DB.CreateBatch();
            foreach (var key in keys)
            {
                var tkey = GetPrefixedKey(key);
                result.Add(key, batch.StringGetAsync(tkey));
            }
            batch.Execute();
            foreach (var item in result)
            {
                valueList.Add(item.Key, item.Value.Result);
            }

            return valueList;
        }

        public Dictionary<string, T> StringBatchGetAsync<T>(List<string> keys)
        {
            var objectList = new Dictionary<string, T>();

            var stringResult = StringBatchGetAsync(keys);
            foreach (var stringItem in stringResult)
            {
                objectList.Add(stringItem.Key, JsonConvert.DeserializeObject<T>(stringItem.Value));
            }

            return objectList;
        }

        public void StringBatchSetAsync(Dictionary<string, string> dic, TimeSpan? timeSpan = null)
        {
            var batch = DB.CreateBatch();
            foreach (var item in dic)
            {
                var tkey = GetPrefixedKey(item.Key);
                batch.StringSetAsync(tkey, item.Value, timeSpan);
            }
            batch.Execute();
        }

        public void StringBatchSetAsync<T>(Dictionary<string, T> list, TimeSpan? timeSpan = null)
        {
            var stringList = new Dictionary<string, string>();
            foreach (var item in list)
            {
                stringList.Add(item.Key, JsonConvert.SerializeObject(item.Value));
            }
            StringBatchSetAsync(stringList, timeSpan);
        }

        public long StringAppend(string key, string value)
        {
            var tkey = GetPrefixedKey(key);
            return DB.StringAppend(key, value);
        }

        public long StringIncrement(string key)
        {
            return StringIncrementCount(key, 1);
        }

        public long StringIncrementCount(string key, long value = 1)
        {
            var tkey = GetPrefixedKey(key);
            return DB.StringIncrement(tkey, value);
        }

        public double StringIncrementCount(string key, double value = 1)
        {
            var tkey = GetPrefixedKey(key);
            return DB.StringIncrement(tkey, value);
        }

        public long StringDecrement(string key)
        {
            return StringDecrementCount(key, 1);
        }

        public long StringDecrementCount(string key, long value = 1)
        {
            var tkey = GetPrefixedKey(key);
            return DB.StringDecrement(tkey, value);
        }

        public double StringDecrement(string key, double value = 1)
        {
            var tkey = GetPrefixedKey(key);
            return DB.StringDecrement(tkey, value);
        }

        public long StringGetLength(string key)
        {
            var tkey = GetPrefixedKey(key);
            return DB.StringLength(tkey);
        }

        #endregion

        #region Hash

        public bool HashFieldExsits(string key, string fieldName)
        {
            var tkey = GetPrefixedKey(key);
            return DB.HashExists(tkey, fieldName);
        }

        public string HashGet(string key, string hashField)
        {
            var tkey = GetPrefixedKey(key);
            return DB.HashGet(tkey, hashField);
        }

        public async Task<string> HashGetAsync(string key, string hashField)
        {
            var tkey = GetPrefixedKey(key);
            return await DB.HashGetAsync(tkey, hashField);
        }

        public Dictionary<string, string> HashGetAll(string key)
        {
            var tkey = GetPrefixedKey(key);
            var hashEntities = DB.HashGetAll(tkey).ToDictionary();
            var result = new Dictionary<string, string>();
            foreach (var entity in hashEntities)
            {
                result.Add(entity.Key, entity.Value);
            }
            return result;
        }

        public async Task<Dictionary<string, string>> HashGetAllAsync(string key)
        {
            var tkey = GetPrefixedKey(key);
            var hashEntities =(await DB.HashGetAllAsync(tkey)).ToDictionary();
            var result = new Dictionary<string, string>();
            foreach (var entity in hashEntities)
            {
                result.Add(entity.Key, entity.Value);
            }
            return result;
        }

        public T HashGetAll<T>(string key) where T : class, new()
        {
            var tkey = GetPrefixedKey(key);
            var hashEntities = DB.HashGetAll(tkey);
            if (hashEntities.Length <= 0)
            {
                return null;
            }
            var entity = new T();
            var type = entity.GetType();
            foreach (var hashEntity in hashEntities)
            {
                var property = type.GetProperty(hashEntity.Name);
                if (property == null || !property.CanWrite)
                {
                    continue;
                }
                object value = hashEntity.Value;
                //TODO:need to check that if the value is a Struct
                if (property.PropertyType.IsClass)
                {
                    value = JsonConvert.DeserializeObject(value.ToString(), property.PropertyType);
                }
                property.SetValue(entity, Convert.ChangeType(value, property.PropertyType));
            }
            return entity;
        }

        public bool HashSet(string key, string hashField, string value)
        {
            var tkey = GetPrefixedKey(key);
            return DB.HashSet(tkey, hashField, value);
        }

        public void HashSet(string key, Dictionary<string, string> hashFields)
        {
            var hashEntities = new List<HashEntry>();
            foreach (var hashField in hashFields)
            {
                hashEntities.Add(new HashEntry(hashField.Key, hashField.Value));
            }
            var tkey = GetPrefixedKey(key);
            DB.HashSet(tkey, hashEntities.ToArray());
        }

        public async Task HashSetAsync(string key, Dictionary<string, string> hashFields)
        {
            var hashEntities = new List<HashEntry>();
            foreach (var hashField in hashFields)
            {
                hashEntities.Add(new HashEntry(hashField.Key, hashField.Value));
            }
            var tkey = GetPrefixedKey(key);
            await DB.HashSetAsync(tkey, hashEntities.ToArray());
        }

        public void HashSetField(string key, string fieldName, string value)
        {
            var tkey = GetPrefixedKey(key);
            DB.HashSet(tkey, fieldName, value);
        }

        public void HashSetField<T>(string key, string fieldName, string value)
        {
            var tkey = GetPrefixedKey(key);
            var property = typeof(T).GetProperty(fieldName);
            if (property == null)
            {
                throw new Exception($"property missing");
            }
            DB.HashSet(tkey, property.Name, value);
        }

        public long HashIncr(string key, string hashField, long value = 1)
        {
            var tkey = GetPrefixedKey(key);
            return DB.HashIncrement(tkey, hashField, value);
        }

        public bool HashFieldRemove(string key, string fieldName)
        {
            var tkey = GetPrefixedKey(key);
            return DB.HashDelete(tkey, fieldName);
        }

        #endregion

        public bool KeyExsists(string key)
        {
          var tkey=  GetPrefixedKey(key);
           return DB.KeyExists(tkey);
        }

        public async Task<bool> KeyExsistsAsync(string key)
        {
            var tkey = GetPrefixedKey(key);
            return await DB.KeyExistsAsync(tkey);
        }

        public bool RemoveKey(string key)
        {
            var tkey = GetPrefixedKey(key);
            return DB.KeyDelete(tkey);
        }

        public async Task<bool> RemoveKeyAsync(string key)
        {

            var tkey = GetPrefixedKey(key);
            return await DB.KeyDeleteAsync(tkey);
        }

        public bool SetExpireTime(string key, TimeSpan timeSpan)
        {
            var tkey = GetPrefixedKey(key);
            return DB.KeyExpire(tkey, timeSpan);
        }

        public async Task<bool> SetExpireTimeAsync(string key, TimeSpan timeSpan)
        {
            var tkey = GetPrefixedKey(key);
            return await DB.KeyExpireAsync(tkey, timeSpan);
        }
    }
}
