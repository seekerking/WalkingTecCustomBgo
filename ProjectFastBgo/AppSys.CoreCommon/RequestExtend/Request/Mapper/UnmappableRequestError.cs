using System;
using AppSys.CoreCommon.RequestExtend.Errors;

namespace AppSys.CoreCommon.RequestExtend.Request.Mapper
{
    public class UnmappableRequestError : Error
    {
        public UnmappableRequestError(Exception ex) : base($"Error when parsing incoming request, exception: {ex.Message}", ErrorCode.UnmappableRequestError)
        {
        }
    }
}
