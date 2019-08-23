using System;
using System.Collections.Generic;

namespace AppSys.Utility.Enumerable
{
    /// <summary>
    /// 扩展 IEqualityComparer( 暂不公开)
    /// </summary>
     internal static class CustomEqualityComparer
    {
        /// <summary>
        /// 创建对象的相等比较。
        /// </summary>
        /// <typeparam name="T">比较对象元素类型</typeparam>
        /// <typeparam name="V">比较器类型</typeparam>
        /// <param name="keySelector">比较方法</param>
        /// <returns></returns>
        public static IEqualityComparer<T> CreateComparer<T, V>(Func<T, V> keySelector)
        {
            return new CommonEqualityComparer<T, V>(keySelector);
        }

        /// <summary>
        /// 创建对象的相等比较
        /// </summary>
        /// <typeparam name="T">比较对象元素类型</typeparam>
        /// <typeparam name="V">比较器类型</typeparam>
        /// <param name="keySelector">比较方法</param>
        /// <param name="comparer">比较器</param>
        /// <returns></returns>
        public static IEqualityComparer<T> CreateComparer<T, V>(Func<T, V> keySelector, IEqualityComparer<V> comparer)
        {
            return new CommonEqualityComparer<T, V>(keySelector, comparer);
        }
        class CommonEqualityComparer<T, V> : IEqualityComparer<T>
        {
            private Func<T, V> keySelector;
            private IEqualityComparer<V> comparer;

            public CommonEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
            {
                this.keySelector = keySelector;
                this.comparer = comparer;
            }
            public CommonEqualityComparer(Func<T, V> keySelector)
                : this(keySelector, EqualityComparer<V>.Default)
            { }

            public bool Equals(T x, T y)
            {
                return comparer.Equals(keySelector(x), keySelector(y));
            }
            public int GetHashCode(T obj)
            {
                return comparer.GetHashCode(keySelector(obj));
            }
        }
    }
}
