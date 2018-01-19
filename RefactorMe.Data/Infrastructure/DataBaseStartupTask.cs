using RefactorMe.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Data.Infrastructure
{
    public class DataBaseStartupTask : IStartupTask
    {
        public void Execute()
        {
            // Running Startup task here
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
