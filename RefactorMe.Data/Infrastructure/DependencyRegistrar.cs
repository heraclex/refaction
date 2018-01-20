using Autofac;
using RefactorMe.Core.Data;
using RefactorMe.Core.Infrastructure;
using RefactorMe.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Data.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            // TODO: move to config file
            //const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DataDirectory}\Database.mdf;Integrated Security=True";
            //const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\_MyProjects\github\refaction\refactor-me\App_Data\Database.mdf;Integrated Security=True";
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
