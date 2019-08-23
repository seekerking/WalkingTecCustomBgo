using System.Net.Http;
using System.Threading.Tasks;
using AppSys.CoreCommon.RequestExtend.Responses;
using Microsoft.AspNetCore.Http;

namespace AppSys.CoreCommon.RequestExtend.Request.Mapper
{
    public interface IRequestMapper
    {
        Task<Response<HttpRequestMessage>> Map(HttpRequest request);
    }
}
