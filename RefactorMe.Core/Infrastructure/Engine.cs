using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe.Core.Infrastructure
{
    public class Engine : IEngine
    {
        #region Fields
        
        private ContainerManager _containerManager;

        #endregion

        #region Utilities

        /// <summary>
        /// Run startup tasks
        /// </summary>
        protected virtual void RunStartupTasks()
        {
            //GlobalConfiguration.Configuration.UseSqlServerStorage(AppConfigManager.ConnectionString);
            //GlobalConfiguration.Configuration.UseAutofacActivator(ContainerManager.Container);
           
            var typeFinder = this._containerManager.Resolve<ITypeFinder>();
            var startUpTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var startUpTasks = new List<IStartupTask>();
            foreach (var startUpTaskType in startUpTaskTypes)
                startUpTasks.Add((IStartupTask)Activator.CreateInstance(startUpTaskType));

            //sort
            startUpTasks = startUpTasks.AsQueryable().OrderBy(st => st.Order).ToList();
            foreach (var startUpTask in startUpTasks)
                startUpTask.Execute();
        }        

        /// <summary>
        /// Register dependencies
        /// </summary>
        protected virtual void RegisterDependencies()
        {
            //dependencies
            var typeFinder = new WebAppTypeFinder();
            var builder = new Autofac.ContainerBuilder();

            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.RegisterInstance(typeFinder).As<ITypeFinder>().SingleInstance();

            //register dependencies provided by other assemblies
            var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var drInstances = new List<IDependencyRegistrar>();
            foreach (var drType in drTypes)
            {
                // get all instances of implementation for IDependencyRegistrar
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            }                
            
            //sort base on order of registratrion
            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
            {
                // Start Register
                dependencyRegistrar.Register(builder, typeFinder);
            }

            var container = builder.Build();

            // Set ContainerManager for further usage across application
            this._containerManager = new ContainerManager(container);

            //set dependency resolver for  ASP.Net MVC
            // NOTE: dont need it because we almost use web API
            //System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initialize components and plugins in the core environment.
        /// </summary>
        public void Initialize()
        {
            //register dependencies
            this.RegisterDependencies();

            RunStartupTasks();
        }

        /// <summary>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return this.ContainerManager.Resolve<T>();
        }

        /// <summary>
        ///  Resolve dependency
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return this.ContainerManager.Resolve(type);
        }

        /// <summary>
        /// Resolve dependencies
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T[] ResolveAll<T>()
        {
            return this.ContainerManager.ResolveAll<T>();
        }
        
        #endregion

        #region Properties

        /// <summary>
        /// Container manager
        /// </summary>
        public ContainerManager ContainerManager
        {
            get { return this._containerManager; }
        }

        #endregion
    }
}
