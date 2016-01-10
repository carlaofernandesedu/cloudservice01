using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CloudService.Common.Logging;

namespace CloudService.GenericLog
{
    public class FactoryGenericLogger : ILogFactory
    {
        public ILogger Create()
        {
            return new GenericLogger();
        }

        public ILogger Create(string name)
        {
            throw new NotImplementedException();
        }
    }
}
