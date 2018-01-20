using Autofac.Integration.WebApi;
using RefactorMe.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RefactorMe.Data.Infrastructure
{
    public class AppStartupTask : IStartupTask
    {
        public void Execute()
        {
            // Rung Start Up task if needed
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
