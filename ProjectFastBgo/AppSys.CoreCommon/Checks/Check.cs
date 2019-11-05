using System;
using AppSys.CoreCommon.Exceptions;

namespace AppSys.CoreCommon.Checks
{
    public sealed class Check
    {
        public static void CheckCondition(Func<bool> condition,string parameters)
        {
            if (condition.Invoke())
            {
                throw new ChecksException(parameters);
            }
        }

        public static void CheckCondition(Func<bool> condition, int code, string parameters)
        {
            if (condition.Invoke())
            {
                throw new ChecksException(parameters) { Code = code };
            }
        }
    }
}
