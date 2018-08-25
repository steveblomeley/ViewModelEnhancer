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
            
            // TODO: How can we enhance this to auto-wire IAugmenters that take a type parameter??
            // What we want to achieve is a binding for new HourlyForecastAugmenter<IHourlyForecast>()
            // Not sure that this can be achieved without some fairly deep use of Reflection, that 
            // would quickly get out of hand if there were multiple type parameters, nested type
            // parameters, multiple type constraints, etc.

            // But... if we explicitly bind multiple concrete types to the same interface, Ninject
            // will interpret a constructor parameter of IEnumerable<IInterface> as a collection  
            // of all of the concrete types that are bound to the interface. So although not as neat
            // as "auto-wiring" the Augmenters in, this nearly achieves the same end, i.e. wiring
            // them in with minimal changes to application code.
            kernel.Bind<IAugmenter>().To<CommentsAugmenter>();
            kernel.Bind<IAugmenter>().To<WeatherAugmenter>();
            kernel.Bind<IAugmenter>().To<DescriptionAugmenter>();
            kernel.Bind<IAugmenter>().To<HourlyForecastAugmenter<HourlyForecast>>(); // <<- the problem child!

            kernel.Bind<IMasterAugmenter>().To<MasterAugmenter>();
        }
    }
}