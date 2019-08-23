using System.Net.Http;
using System.Threading.Tasks;
using AppSys.CoreCommon.RequestExtend.Responses;

namespace AppSys.CoreCommon.RequestExtend.Request.Builder
{
    public interface IRequestCreator
    {
        Task<Response<global::AppSys.CoreCommon.RequestExtend.Request.Request>> Build(
            HttpRequestMessage httpRequestMessage,
            bool useCookieContainer,
            bool allowAutoRedirect);
    }
}
