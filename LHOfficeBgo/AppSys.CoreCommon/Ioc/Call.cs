using System.Threading.Tasks;
using AppSys.CoreCommon.Ioc.AOPAttribute;
using Castle.DynamicProxy;

namespace AppSys.CoreCommon.Ioc
{
    /// <summary>
    /// 拦截器 需要实现 IInterceptor接口 Intercept方法
    /// </summary>
    public class Call : IInterceptor
    {

        /// <summary>
        /// 单一,只会执行和一次
        /// </summary>
        public Call()
        {
        }

        /// <summary>
        /// 拦截方法 打印被拦截的方法执行前的名称、参数和方法执行后的 返回结果
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            //Debug.WriteLine("你正在调用方法 \"{0}\"  参数是 {1}... " +
            //     invocation.Method.Name +
            //     string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray()));
            //获取arrts属性
            var attrs = invocation.GetConcreteMethodInvocationTarget().GetCustomAttributes(typeof(BaseAspectAttribute),true);
            if (attrs.Length == 0)
            {
                invocation.Proceed();
                return;
            }
            //指定Attribute执行方法
           Task task=  AttributeRecursionIntercept(invocation, attrs);
           task.Wait();

            //在被拦截的方法执行完毕后 继续执行

            //Debug.WriteLine("方法执行完毕，返回结果：{0}", invocation.ReturnValue);
        }

        public  async Task AttributeRecursionIntercept(IInvocation invocation, object[] attrs, int i = 0)
        {
            var h = ((BaseAspectAttribute)attrs[i]);
            await h.OnExcuting(invocation);

            if (invocation.ReturnValue != null) return;

            if (++i < attrs.Length) await AttributeRecursionIntercept(invocation, attrs, i);

            if (i == attrs.Length && invocation.ReturnValue == null) invocation.Proceed();
            await h.OnExit(invocation);
        }
    }
}
