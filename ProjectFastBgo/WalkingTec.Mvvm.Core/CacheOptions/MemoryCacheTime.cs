using System;
using Microsoft.Extensions.Caching.Memory;

namespace WalkingTec.Mvvm.Core.CacheOptions
{
    public static class MemoryCacheTime
    {
        static MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCacheValue(string key)
        {
            object val = null;
            if (key != null && cache.TryGetValue(key, out val))
            {

                return val;
            }
            else
            {
                return default(object);
            }
        }
        /// <summary>
        /// 删除缓存键
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveKey(string key)
        {
             cache.Remove(key);
        }
        /// <summary>
        /// 添加缓存内容(滑动过期)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetSlidingChacheValue(string key, object value, int ExpiresAtSecond)
        {
            if (key != null)
            {
                cache.Set(key, value, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(ExpiresAtSecond)
                });
            }
        }

        /// <summary>
        /// 添加缓存内容(定时过期)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetChacheValue(string key, object value, int ExpiresAtSecond,int SlideExpireAtSecond=240)
        {
            if (key != null)
            {
                cache.Set(key, value, new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(ExpiresAtSecond),
                    SlidingExpiration = TimeSpan.FromSeconds(SlideExpireAtSecond)
                });
            }
        }
    }
}
