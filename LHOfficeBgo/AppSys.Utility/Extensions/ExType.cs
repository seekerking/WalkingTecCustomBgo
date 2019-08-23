using System;
using System.Collections.Generic;
using System.Reflection;

namespace AppSys.Utility.Extensions
{
    static public class ExType
    {
        public static Type[] GetChildTypes(this Type parentType)
        {
            List<Type> lstType = new List<Type>();
            Assembly assem = Assembly.GetAssembly(parentType);
            foreach (Type tChild in assem.GetTypes())
            {
                if (tChild.BaseType == parentType)
                {
                    lstType.Add(tChild);
                }
            }
            return lstType.ToArray();
        }
    }
}
