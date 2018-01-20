using RefactorMe.Core.Infrastructure;
using RefactorMe.Services;
using System.Linq;

namespace RefactorMe.Data.Infrastructure
{
    public class ServiceStartupTask : IStartupTask
    {
        public void Execute()
        {
            // Get all types in the current assembly
            var types = typeof(IService).Assembly.GetTypes();
            var automapperProfiles = types.Where(x => x.IsSubclassOf(typeof(AutoMapper.Profile))).ToList();                                       

            // Here we call the static Mapper class and add each profile
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(automapperProfiles); // Initialise each Profile classe
            });
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
