using System;
using System.Linq;
using System.Reflection;
using AppSys.CoreCommon.CacheOperation;
using AppSys.Utility;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace AppSys.CoreCommon.Ioc
{
    /// <summary>
    /// Ioc 
    /// 使用前请初始化
    /// 最后 _builder.Build() 更新
    /// </summary>
    public class IocContainer
    {
        private static ContainerBuilder _builder = new ContainerBuilder();

        private static IContainer _container;

        public static IocContainer Container = new IocContainer();
        public IContainer Build(IServiceCollection services)
        {
            //注册AOP
            _builder.Register(c => new Call()).Named<IInterceptor>("aspect").AsSelf().InstancePerLifetimeScope();
            _builder.Populate(services);
            _builder.RegisterType<PollyHelper>().SingleInstance();
            _builder.RegisterType<RedisCache>().SingleInstance().As<ICache>();
            _container = _builder.Build();
            return _container;
        }

   

        /// <summary>
        /// 注册应用项目
        /// </summary>
        /// <param name="interfaceAssem">项目接口实现</param>
        /// <param name="implAssem">项目实现</param>
        public void RegisterAssembly(string implAssem, string interfaceAssem)

        {
            try
            {
                RegisterAssembly(Assembly.Load(interfaceAssem),Assembly.Load(implAssem));
            }
            catch (Exception ex)
            {
                throw new Exception("注册失败" + implAssem + ex.Message);
            }
        }


        public void RegisterAssembly(string[] implAndInterfaceAssem)
        {
            if (implAndInterfaceAssem != null)
            {
                foreach (var asem in implAndInterfaceAssem)
                {
                    try
                    {
                        RegisterAssembly(Assembly.Load(asem));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("注册失败" + asem + ex.Message);
                    }
                }
            }
        }



        private static void RegisterAssembly(Assembly interfaceAssembly, Assembly impAssembly)
        {
            foreach (TypeInfo implType in impAssembly .DefinedTypes)
            {
                foreach (TypeInfo interfaceType in interfaceAssembly.DefinedTypes)
                {
                    if (interfaceType.IsAssignableFrom(implType))
                    {
                        _builder.RegisterType(implType).InstancePerLifetimeScope().As(interfaceType).EnableInterfaceInterceptors().InterceptedBy(typeof(Call));
                    }
                }
            }
        }

        /// <summary>
        /// 一个dll里面接口和实现方法都放在一起的
        /// </summary>
        /// <param name="assembly"></param>
        private static void RegisterAssembly(Assembly assembly)
        {
            var interfaceTypes = assembly.DefinedTypes.Where(x => x.IsInterface == true).ToList();
            var impleTypes = assembly.DefinedTypes.Where(x => x.IsClass==true).ToList();


            foreach (TypeInfo implType in impleTypes)
            {
                foreach (TypeInfo interfaceType in interfaceTypes)
                {
                    if (interfaceType.IsAssignableFrom(implType))
                    {
                        _builder.RegisterType(implType).InstancePerLifetimeScope().As(interfaceType).EnableInterfaceInterceptors().InterceptedBy(typeof(Call));
                    }
                }
            }
        }


        public T Get<T>()
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("Ioc 配置失败:" + typeof(T).Namespace +" "+ex.ToString());
            }
        }
    }
}
