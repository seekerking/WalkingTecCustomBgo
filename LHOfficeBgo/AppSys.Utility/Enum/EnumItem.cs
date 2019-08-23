
namespace AppSys.Utility.Enum
{
    /// <summary>
    /// 枚举项
    /// </summary>
    /// <typeparam name="T">int 或 long</typeparam>
    public class EnumItem<T>
    {
        /// <summary>
        /// 枚举值
        /// </summary>        
        public T Value { get; internal set; }

        /// <summary>
        /// 枚举名称
        /// </summary>
        public string EnumName { get; internal set; }

        /// <summary>
        /// 枚举的描述
        /// </summary>
        public string Description { get; internal set; }
    }
}
