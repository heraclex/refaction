using Autofac;
using RefactorMe.Core.Data;
using RefactorMe.Core.Infrastructure;
using System.Configuration;

namespace RefactorMe.Data.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            var connStr = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ToString();
            builder.Register<IDbContext>(c => new ApplicationDbContext(connStr)).InstancePerLifetimeScope();
            
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
