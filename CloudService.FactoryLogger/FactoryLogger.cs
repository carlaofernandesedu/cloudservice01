using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudService.Common.Logging;

namespace CloudService.FactoryLogger
{
    public class FactoryLogger : ILogFactory
    {
        public ILogger Create()
        {
            return new CloudService.GenericLog.GenericLogger();
        }

        public ILogger Create(string name)
        {
            throw new NotImplementedException();
        }
    }
}
