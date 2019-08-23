using System;
using AppSys.CoreCommon.RequestExtend.Errors;

namespace AppSys.CoreCommon.RequestExtend.Requester
{
    public class RequestTimedOutError : Error
    {
        public RequestTimedOutError(Exception exception) 
            : base($"Timeout making http request, exception: {exception.Message}", ErrorCode.RequestTimedOutError)
        {
        }
    }
}
