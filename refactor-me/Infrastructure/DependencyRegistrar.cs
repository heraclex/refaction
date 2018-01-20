using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using RefactorMe.Core.Data;
using RefactorMe.Core.Infrastructure;
using RefactorMe.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
