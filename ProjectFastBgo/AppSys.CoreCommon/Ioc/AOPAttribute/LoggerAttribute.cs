using System.Diagnostics;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace AppSys.CoreCommon.Ioc.AOPAttribute
{
    /// <summary>
    /// 日志属性
    /// </summary>
    public class LoggerAttribute : BaseAspectAttribute
    {

        public override async Task OnExcuting(IInvocation invocation)
        {
            Debug.WriteLine("日志执行前");
        }

        public override async Task OnExit(IInvocation invocation)
        {
            Debug.WriteLine("日志执行后");
        }
    }
}
