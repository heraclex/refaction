using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace RefactorMe.Core.Infrastructure
{
    public class EngineContext
    {

        private static IEngine _instance;

        #region Methods

        /// <summary>
        /// Initializes a static instance of the engine factory.
        /// </summary>
        /// <param name="forceRecreate">Creates a new factory instance even though the factory has been previously initialized.</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize()
        {
            if (_instance == null)
            {
                _instance = new Engine();
                _instance.Initialize();
            }
            return _instance;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the singleton engine used to access services.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (_instance == null)
                {
                    Initialize();
                }
                return _instance;
            }
        }

        #endregion

    }
}
