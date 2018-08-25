using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using ViewModelEnhancer;
using ViewModelEnhancer.Models;
using ViewModelEnhancer.Services.Augmenters;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace ViewModelEnhancer
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            //Bind any "simple" IAugmenters
            //kernel.Bind(x =>
            //    x.FromAssemblyContaining(typeof(IAugmenter))
            //        .SelectAllClasses()
            //        .InheritedFrom<IAugmenter>()
            //        .BindAllInterfaces()
            //);
            //
            // TODO: How can we enhance this to bind IAugmenters that take a type parameter??
            // What we want to achieve is a binding for new HourlyForecastAugmenter<IHourlyForecast>()
            // Not sure that this can be easily achieved...

            // But... if we explicitly bind multiple concrete types to the same interface, doesn't
            // Ninject interpret a constructor parameter of IEnumerable<IInterface> as a collection  
            // of all of the concrete types that are bound to the interface?
            kernel.Bind<IAugmenter>().To<CommentsAugmenter>();
            kernel.Bind<IAugmenter>().To<WeatherAugmenter>();
            kernel.Bind<IAugmenter>().To<HourlyForecastAugmenter<HourlyForecast>>();

            kernel.Bind<IMasterAugmenter>().To<MasterAugmenter>();
        }
    }
}