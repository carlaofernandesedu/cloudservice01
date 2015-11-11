using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudService.Common.Logging
{
    public interface ILogFactory
    {
        ILogger Create();
        ILogger Create(string name);
    }
}
