using System.Net.Http;
using System.Threading.Tasks;
using AppSys.CoreCommon.RequestExtend.Responses;

namespace AppSys.CoreCommon.RequestExtend.Request.Builder
{
    public sealed class HttpRequestCreator : IRequestCreator
    {
        public async Task<Response<global::AppSys.CoreCommon.RequestExtend.Request.Request>> Build(
            HttpRequestMessage httpRequestMessage,
            bool useCookieContainer,
            bool allowAutoRedirect)
        {
            return new OkResponse<global::AppSys.CoreCommon.RequestExtend.Request.Request>(new global::AppSys.CoreCommon.RequestExtend.Request.Request(httpRequestMessage, useCookieContainer, allowAutoRedirect));
        }
    }
}