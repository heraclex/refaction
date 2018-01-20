using Autofac.Integration.WebApi;
using System.Web.Http;
using RefactorMe.Core.Infrastructure;

namespace refactor_me
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Engine Start
            EngineContext.Initialize();

            // Register DI Resolver
            GlobalConfiguration.Configuration.DependencyResolver = 
                new AutofacWebApiDependencyResolver(
                    EngineContext.Current.ContainerManager.Container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error()
        {
            //var exception = Server.GetLastError();

            //Debug.WriteLine(exception);
        }
    }
}
