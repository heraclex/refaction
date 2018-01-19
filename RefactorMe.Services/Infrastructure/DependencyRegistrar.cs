using Autofac;
using RefactorMe.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Services.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // Register for Service
            // i assume your service interfaces inherit from IService
            Assembly ass = typeof(IService).GetTypeInfo().Assembly;

            // get all concrete types which implements IService
            var allServices = ass.GetTypes().Where(t =>
                t.GetTypeInfo().IsClass &&
                !t.GetTypeInfo().IsAbstract &&
                typeof(IService).IsAssignableFrom(t));

            foreach (var type in allServices)
            {
                var allInterfaces = type.GetInterfaces();
                var mainInterfaces = allInterfaces.Except
                        (allInterfaces.SelectMany(t => t.GetInterfaces()));
                foreach (var itype in mainInterfaces)
                {
                    if (allServices.Any(x => !x.Equals(type) && itype.IsAssignableFrom(x)))
                    {
                        throw new Exception("The " + itype.Name + " type has more than one implementations, please change your filter");
                    }
                    builder.RegisterType(type).As(itype).InstancePerLifetimeScope();
                }
            }
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
