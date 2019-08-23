using System;
using AppSys.CoreCommon.RequestExtend.Errors;

namespace AppSys.CoreCommon.RequestExtend.Requester
{
    public class UnableToCompleteRequestError : Error
    {
        public UnableToCompleteRequestError(Exception exception) 
            : base($"Error making http request, exception: {exception.Message}",ErrorCode.UnableToCompleteRequestError)
        {
        }
    }
}
