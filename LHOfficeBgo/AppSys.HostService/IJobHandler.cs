using Quartz;

namespace AppSys.HostService
{
    /// <summary>
    /// 任务处理
    /// </summary>
    public interface IJobHandler
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        string JobName { get; }

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <returns></returns>
        IJobDetail CreateJobDetail();

        /// <summary>
        /// 创建任务触发器
        /// </summary>
        /// <returns></returns>
        ITrigger CreateTigger();
    }
}
