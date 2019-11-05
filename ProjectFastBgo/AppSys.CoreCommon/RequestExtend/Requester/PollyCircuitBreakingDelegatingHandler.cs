using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AppSys.CoreCommon.RequestExtend.Requester.QoS;
using Polly;
using Polly.CircuitBreaker;

namespace AppSys.CoreCommon.RequestExtend.Requester
{
    public class PollyCircuitBreakingDelegatingHandler : DelegatingHandler
    {
        PollyQoSProvider pollyQoS = new PollyQoSProvider();
        public PollyCircuitBreakingDelegatingHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                
                return await Policy
                    .WrapAsync(pollyQoS.CircuitBreaker.CircuitBreakerPolicy, pollyQoS.CircuitBreaker.TimeoutPolicy)
                    .ExecuteAsync(() => base.SendAsync(request, cancellationToken));
            }
            catch (BrokenCircuitException ex)
            {
                throw;
            }
            catch (HttpRequestException ex)
            {
                throw;
            }
        }
    }
}
