using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudService.Common.Logging
{
    /// <summary>
    /// Pattern Microsot Implementando Factory e Singleton Static para poder utilizar outros tipos de logs 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class LoggerFactory<T> where T : ILogFactory, new()
    {
        #region "Singleton Implementation"
        private static T _loggerFactory = default(T);

        private static object _lockObj = new object();

        protected static ILogFactory _factory
        {
            get
            {
                if (_loggerFactory == null)
                {
                    lock (_lockObj)
                    {
                        if (_loggerFactory == null)
                        {
                            _loggerFactory = new T();
                        }
                    }
                }
                return _loggerFactory;
            }
        }
        #endregion
        //Implementacao especifica do NLog
        //public static void Initialize()
        //{
        //    if (_loggerFactory != null)
        //        _loggerFactory.Initialize();
        //}

        public static ILogger GetLogger<T>()
        {
            return _factory.Create(typeof(T).Name);
        }
    
        public static ILogger GetLogger()
        {
            return _factory.Create();
        }

        public static ILogger GetLogger(string logName)
        {
            return _factory.Create(logName);
        }    
    }
    }
}
