using System;
using System.Reflection;

namespace AppSys.Utility
{
   public static class AttributeHelper
    {
        public static T GetCustomAttr<T>(this Type type) where T : Attribute
        {
          var attribute =(T)type.GetCustomAttribute(typeof(T));
           return attribute;
        }
    }
}
