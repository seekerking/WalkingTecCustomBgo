using AppSys.CoreCommon.RequestExtend.Errors;

namespace AppSys.CoreCommon.RequestExtend.Requester.QoS
{
    public class UnableToFindQoSProviderError : Error
    {
        public UnableToFindQoSProviderError(string message) 
            : base(message, ErrorCode.UnableToFindQoSProviderError)
        {
        }
    }
}
