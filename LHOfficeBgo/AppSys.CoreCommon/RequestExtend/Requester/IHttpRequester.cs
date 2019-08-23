using System.Net.Http;
using System.Threading.Tasks;
using AppSys.CoreCommon.RequestExtend.Responses;

namespace AppSys.CoreCommon.RequestExtend.Requester
{
    public interface IHttpRequester
    {
        Task<Response<HttpResponseMessage>> GetResponse(Request.Request request);
    }
}
