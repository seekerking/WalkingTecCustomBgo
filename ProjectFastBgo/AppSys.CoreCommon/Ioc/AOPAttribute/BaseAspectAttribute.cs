using System;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace AppSys.CoreCommon.Ioc.AOPAttribute
{
    public class BaseAspectAttribute : Attribute
    {
        public virtual async Task OnExcuting(IInvocation invocation)
        {
           
        }

        public virtual async Task OnExit(IInvocation invocation)
        {
        }
    }
}
