[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ChurrasTrinca.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ChurrasTrinca.App_Start.NinjectWebCommon), "Stop")]

namespace ChurrasTrinca.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using System.Data.Entity;
    using ChurrasTrinca.DataAccess;
    using ChurrasTrinca.DataAccess.Contracts;
    using ChurrasTrinca.Business.Contracts;
    using ChurrasTrinca.Business;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new LocalNinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<DbContext>()
                .To<ChurrasTrincaContext>()
                .InRequestScope();

            kernel.Bind<IBarbecueRepository>()
                .To<BarbecueRepository>()
                .WithConstructorArgument("dbContext", kernel.Get<DbContext>());

            kernel.Bind<IParticipantRepository>()
                .To<ParticipantRepository>()
                .WithConstructorArgument("dbContext", kernel.Get<DbContext>());

            kernel.Bind<IBarbecueDomain>()
                .To<BarbecueDomain>()
                .WithConstructorArgument("barbecueRepository", kernel.Get<IBarbecueRepository>());

            kernel.Bind<IParticipantDomain>()
                .To<ParticipantDomain>()
                .WithConstructorArgument("participantRepository", kernel.Get<IParticipantRepository>());
        }        
    }
}
