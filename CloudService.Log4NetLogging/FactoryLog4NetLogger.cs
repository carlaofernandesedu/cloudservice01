using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudService.Common.Logging;
using log4net;

namespace CloudService.Log4NetLog
{
    public class FactoryLog4NetLogger : ILogFactory
    {
        public ILogger Create()
        {
            return this.Create("LogDefault");
        }

        public ILogger Create(string name)
        {
            log4net.Config.BasicConfigurator.Configure();
            return new Log4NetLogger(log4net.LogManager.GetLogger(name));
        }
    }
}
