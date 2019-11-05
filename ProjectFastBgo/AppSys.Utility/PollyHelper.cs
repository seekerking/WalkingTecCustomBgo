using System;
using System.Threading.Tasks;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using Polly.Wrap;

namespace AppSys.Utility
{
    public class PollyHelper
    {
        private int _retry = 2; //重试次数
        private int _waitRetry = 100;//重试延时 豪秒

        private double _failureThreshold = 0.9;//概率
        private int _minimumThroughput = 10; //最小值
        private int _samplingDuration = 30;//采样时间 秒
        private int _durationOfBreak = 30;//熔断时间 秒

        private RetryPolicy _policyRetry; //重试
        private RetryPolicy _policyRetryAsync; //异步重试
        private PolicyWrap _policyRetryBreaker; //重试并熔断
        private PolicyWrap _policyRetryBreakerAsync; //异步重试并熔断

        public PollyHelper()
        {
            Init();
        }

        public object ExecRetry<T>(T dictionary)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="retry">重试次数</param>
        /// <param name="waitRetry">重试间隔（豪秒）</param>
        public PollyHelper(int retry, int waitRetry)
        {
            _retry = retry;
            _waitRetry = waitRetry;
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="retry">重试次数</param>
        /// <param name="waitRetry">重试间隔 豪秒</param>
        /// <param name="failureThreshold">熔断概率</param>
        /// <param name="minimumThroughput">最小值</param>
        /// <param name="samplingDuration">采样时间 秒</param>
        /// <param name="durationOfBreak">熔断时间 秒</param>
        public PollyHelper(int retry, int waitRetry, double failureThreshold, int minimumThroughput, int samplingDuration, int durationOfBreak)
        {
            _retry = retry;
            _waitRetry = waitRetry;

            _failureThreshold = failureThreshold;
            _minimumThroughput = minimumThroughput;
            _samplingDuration = samplingDuration;
            _durationOfBreak = durationOfBreak;
            Init();
        }

        private void Init()
        {
            //定义重试延时策略
            var tsList = new TimeSpan[_retry];
            for (int i = 0; i < tsList.Length; i++)
                tsList[i] = TimeSpan.FromMilliseconds(_waitRetry);
           var policy= Policy.Handle<Exception>();
            //重试
            _policyRetry = policy.WaitAndRetry(tsList);
            _policyRetryAsync = policy.WaitAndRetryAsync(tsList);

            //重试并熔断
            //默认：分布式锁熔断器 30秒内，超过10个异常，概率大于0.9，则熔断30秒
            var retryPolicy =policy.WaitAndRetry(tsList);
            var retryPolicyAsync = policy.WaitAndRetryAsync(tsList);
            var cbPolicy = policy
                 .AdvancedCircuitBreaker(
                failureThreshold: _failureThreshold,
                samplingDuration: TimeSpan.FromSeconds(_samplingDuration),
                minimumThroughput: _minimumThroughput,
                durationOfBreak: TimeSpan.FromSeconds(_durationOfBreak));
            _policyRetryBreaker = Policy.Wrap(cbPolicy, retryPolicy);
            _policyRetryBreakerAsync = Policy.WrapAsync(cbPolicy, retryPolicyAsync);
        }

        /// <summary>
        /// 重试
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <returns></returns>
        public T ExecRetry<T>(Func<T> fun)
        {
            return _policyRetry.Execute(fun);
        }

        public async Task<T> ExecRetryAsync<T>(Func<Task<T>> fun)
        {
            return  await _policyRetryAsync.ExecuteAsync(fun);
        }

        /// <summary>
        /// 重试并熔断
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <returns></returns>
        public T ExecRetryBreaker<T>(Func<T> fun)
        {
            var cb = _policyRetryBreaker.GetPolicy<CircuitBreakerPolicy>();

            if (cb.CircuitState.HasFlag(CircuitState.Open))
                throw new Exception("处于熔断状态");

            return _policyRetryBreaker.Execute(fun);
        }

        /// <summary>
        /// 重试并熔断
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fun"></param>
        /// <returns></returns>
        public async Task<T> ExecRetryBreakerAsync<T>(Func<Task<T>> fun)
        {
            var cb = _policyRetryBreakerAsync.GetPolicy<CircuitBreakerPolicy>();

            if (cb.CircuitState.HasFlag(CircuitState.Open))
                throw new Exception("处于熔断状态");

            return await _policyRetryBreaker.ExecuteAsync(fun);
        }
    }
}
