using System.Net.Http;

namespace AppSys.CoreCommon.RequestExtend.Request
{
    public class Request
    {
        public Request(HttpRequestMessage httpRequestMessage, bool allowAutoRedirect,
            bool useCookieContainer)
        {
            HttpRequestMessage = httpRequestMessage;
            AllowAutoRedirect = allowAutoRedirect;
            UseCookieContainer = useCookieContainer;
        }

        public HttpRequestMessage HttpRequestMessage { get; private set; }
        public bool AllowAutoRedirect { get; private set; }
        public bool UseCookieContainer { get; private set; }
    }
}
