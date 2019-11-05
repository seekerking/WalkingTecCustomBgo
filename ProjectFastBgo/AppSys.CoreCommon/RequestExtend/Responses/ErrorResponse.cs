using System.Collections.Generic;
using AppSys.CoreCommon.RequestExtend.Errors;

namespace AppSys.CoreCommon.RequestExtend.Responses
{
    public class ErrorResponse : Response
    {
        public ErrorResponse(Error error) : base(new List<Error>{error})
        {
        }
        public ErrorResponse(List<Error> errors) : base(errors)
        {
        }
    }
}