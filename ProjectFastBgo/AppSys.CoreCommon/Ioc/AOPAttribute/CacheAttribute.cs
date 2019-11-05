using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AppSys.CoreCommon.CacheOperation;
using AppSys.Utility;
using AppSys.Utility.Extensions;
using Castle.DynamicProxy;

namespace AppSys.CoreCommon.Ioc.AOPAttribute
{
    /// <summary>
    /// 缓存AOP
    /// </summary>
    public class CacheAttribute : BaseAspectAttribute
    {
        /// <summary>
        /// 缓存Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 是否是本地缓存
        /// </summary>
        public bool isLocal { get; set; }

        /// <summary>
        /// 是否是滑动过期
        /// </summary>
        public bool isSliding { get; set; }
        /// <summary>
        /// 过期时间秒 0=永久
        /// </summary>
        public int ExpiresAtSecond { get; set; }
        /// <summary>
        /// 缓存规则
        /// </summary>
        public string VaryByParam { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="local"></param>
        /// <param name="sliding"></param>
        /// <param name="expiresAtSecond"></param>
        /// <param name="varyByParam"></param>
        public CacheAttribute(string key = "Empty", bool local = false, bool sliding = false, int expiresAtSecond = 600, string varyByParam = "*")
        {
            Key = key+"_"+DateTime.Today.ToString("yyyyMMdd");
            isLocal = local;
            isSliding = sliding;
            ExpiresAtSecond = expiresAtSecond;
            VaryByParam = varyByParam;
        }

        public override async Task OnExcuting(IInvocation invocation)
        {
            string key = GetCacheKey(invocation);
            if (isLocal)
            {
                invocation.ReturnValue = MemoryCacheTime.GetCacheValue(key);
            }
            else
            {
                var cahceVaule = IocContainer.Container.Get<ICache>().StringGet(key);
                if (!cahceVaule.IsNullOrEmpty())
                {
                    invocation.ReturnValue = cahceVaule.ToModel(invocation.MethodInvocationTarget.ReturnType);
                }
            }
            Debug.WriteLine("缓存执行前");
        }

        public override async Task OnExit(IInvocation invocation)
        {
            string key = GetCacheKey(invocation);
            if (isLocal)
            {
                if (isSliding)
                {
                    MemoryCacheTime.SetSlidingChacheValue(key, invocation.ReturnValue, ExpiresAtSecond);
                }
                else
                {
                    MemoryCacheTime.SetChacheValue(key, invocation.ReturnValue, ExpiresAtSecond);
                }
            }
            else
            {
                //redis
                IocContainer.Container.Get<ICache>().StringSet(key, invocation.ReturnValue.ToJson(), TimeSpan.FromSeconds(ExpiresAtSecond));

            }
            Debug.WriteLine("缓存执行后");
        }

        private string GetCacheKey(IInvocation invocation)
        {
            string keyParams = VaryByParam;
            if (VaryByParam != "*")
            {
                foreach (var i in VaryByParam.Split(';'))
                {
                    keyParams += $":{invocation.Arguments[i.ConvertToIntSafe()-1]}";
                }
            }
            return $"{Key}:{ExpiresAtSecond}:{isSliding}:{invocation.Method.DeclaringType.Name}:{invocation.Method.Name}:{keyParams}";
        }
    }
}
