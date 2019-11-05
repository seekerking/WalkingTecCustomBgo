using System.Net.Http;
using AppSys.CoreCommon.RequestExtend.Requester;
using AppSys.CoreCommon.RequestExtend.Responses;

namespace AppSys.CoreCommon.RequestExtend
{
    public static class WebRequestFactory
    {
        private static IHttpRequester _requester;

        private static IHttpClientCache _clientCache;

        static WebRequestFactory()
        {
            _clientCache = new MemoryHttpClientCache();
            _requester = new HttpClientHttpRequester(_clientCache);
        }

        public static Response<HttpResponseMessage> GetResponse(Request.Request request)
        {
            return _requester.GetResponse(request).Result;
        }
    }
}
