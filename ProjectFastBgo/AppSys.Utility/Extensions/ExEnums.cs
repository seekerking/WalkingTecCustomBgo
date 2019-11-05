using System.Collections.Concurrent;
using System.ComponentModel;

namespace AppSys.Utility.Extensions
{
    public static class ExEnums
    {
        private static ConcurrentDictionary<System.Enum, DescriptionAttribute> senumCache = new ConcurrentDictionary<System.Enum, DescriptionAttribute>();

        public static string GetEnumDescription(this System.Enum senum)
        {
            DescriptionAttribute descriptionAttribute = null;
            senumCache.TryGetValue(senum, out descriptionAttribute);
            if (descriptionAttribute != null)
            {
                return descriptionAttribute.Description;
            }
            var attris = senum.GetType().GetField(senum.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attris.Length > 0)
            {
                descriptionAttribute = ((DescriptionAttribute)attris[0]);
            }
            if (descriptionAttribute == null)
            {
                descriptionAttribute = new DescriptionAttribute();
            }
            senumCache.TryAdd(senum, descriptionAttribute);
            return descriptionAttribute.Description;
        }
    }
}
