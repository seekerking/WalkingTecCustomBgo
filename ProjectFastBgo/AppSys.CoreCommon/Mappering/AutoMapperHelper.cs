using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace AppSys.CoreCommon.Mappering
{
    /// <summary>
    /// AutoMapper扩展帮助类
    /// </summary>
    public static class AutoMapperHelper
    {
        public static void InitMapping(Action<IMapperConfigurationExpression> func)
        {
            Mapper.Initialize(func);
        }
        public static T MapTo<T>(this object obj)
        {
            if (obj == null) return default(T);
            var typePair = new TypePair(obj.GetType(), typeof(T));
            var typemap=Mapper.Instance.ConfigurationProvider.FindTypeMapFor(typePair);
            if (typemap == null)
            {
                MapperConfiguration confg=new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap(obj.GetType(), typeof(T));
                });
                var mapper = confg.CreateMapper();
              return  mapper.Map<T>(obj);
            }
            return Mapper.Map<T>(obj);
        }


        public static List<T> MapToList<T>(this IEnumerable<object> obj)
        {
            var enumerable = obj as object[] ?? obj.ToArray();
            if (!enumerable.Any()) return new List<T>();
            var objType = enumerable.FirstOrDefault()?.GetType();
            var typePair = new TypePair(objType, typeof(T));
            var typemap = Mapper.Instance.ConfigurationProvider.FindTypeMapFor(typePair);
            var result = new List<T>();
            if (typemap == null)
            {
                MapperConfiguration confg = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap(objType, typeof(T));
                });
                var mapper = confg.CreateMapper();
                foreach (var item in enumerable)
                {
                    result.Add(mapper.Map<T>(item));
                }
            }
            else
            {
                foreach (var item in enumerable)
                {
                    result.Add(Mapper.Map<T>(item));
                }
            }



            return result;
        }
    }
}
