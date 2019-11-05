using System.Net.Http;
using System.Threading.Tasks;

namespace AppSys.CoreCommon.RequestExtend.Requester
{
    public interface IHttpClient
    {
        HttpClient Client { get; }

        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
