using System.Collections.Generic;
using AppSys.CoreCommon.RequestExtend.Errors;

namespace AppSys.CoreCommon.RequestExtend.Responses
{
    public abstract class Response<T> : Response
    {
        protected Response(T data)
        {
            Data = data;
        }

        protected Response(List<Error> errors) : base(errors)
        {
        }

        public T Data { get; private set; }
        
    }
} 