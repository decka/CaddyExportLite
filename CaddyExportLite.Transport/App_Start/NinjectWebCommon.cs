[assembly: WebActivator.PreApplicationStartMethod(typeof(CaddyExportLite.Transport.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(CaddyExportLite.Transport.App_Start.NinjectWebCommon), "Stop")]

namespace CaddyExportLite.Transport.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Data;
    using System.Data.SqlClient;
    using CaddyExportLite.Domain;

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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            string connectionString = Properties.Settings.Default.connectionString;
            if (connectionString != null)
            {
                kernel.Bind<IDbConnection>().To<SqlConnection>().InSingletonScope().WithConstructorArgument("connectionString", connectionString);
                kernel.Bind<IExportRepository>().To<ExportRepository>().InSingletonScope();
                kernel.Bind<IConnectionManager>().To<ConnectionManager>().InSingletonScope();
                kernel.Bind<ICanSendStringToClient>().To<HubStringSender>().InSingletonScope();
                kernel.Bind<ICanMarkExportAsComplete>().To<Worker>().InSingletonScope();

                SignalR.GlobalHost.DependencyResolver = new SignalR.Ninject.NinjectDependencyResolver(kernel);

                var theWorker = kernel.Get<Worker>();
                theWorker.Initialise();
            }
            else
            {
                throw new ArgumentException("connectionString Setting cannot be null");
            }
        }        
    }
}
