using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Core.Exceptions
{
    /// <summary>
    /// Represents errors that occur during application execution
    /// </summary>
    public class CoreException : Exception
    {
        public CoreException() : base()
        {

        }

        public CoreException(string err) : base(err)
        {

        }
    }
}
