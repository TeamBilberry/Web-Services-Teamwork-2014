
using Microsoft.Owin;

[assembly: OwinStartup(typeof(FeedbackSystem.Web.Startup))]

namespace FeedbackSystem.Web
{
    using System.Reflection;
    
    using Ninject;
    using Owin;
    using System.Web.Http;

    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;

    using Data;
    using Data.Contracts;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IFeedbackSystemData>().To<FeedbackSystemData>()
                .WithConstructorArgument("context",
                    c => new FeedbackSystemDbContext());
        }
    }
}
