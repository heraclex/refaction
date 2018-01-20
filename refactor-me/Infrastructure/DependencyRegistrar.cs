using Autofac;
using Autofac.Integration.WebApi;
using RefactorMe.Core.Infrastructure;
using System.Linq;

namespace refactor_me.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // ability to load API controllers.
            var controllerTypes = typeFinder.GetAssemblies().ToArray();

            // Register Controllers API
            builder.RegisterApiControllers(controllerTypes);
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
