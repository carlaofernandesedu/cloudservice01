using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CloudService.Common.Logging
{
    /// <summary>
    /// Classe implementa o Log baseado no artigo de praticas de monitoramento
    /// http://www.asp.net/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/monitoring-and-telemetry
    /// </summary>
    public class GenericLogger : ILogger
    {
        public void Information(object message)
        {
            Trace.TraceInformation(Convert.ToString(message));
        }

        public void Information(string fmt, params object[] vars)
        {
            throw new NotImplementedException();
        }

        public void Information(Exception exception, string fmt, params object[] vars)
        {
            throw new NotImplementedException();
        }

        public void Warning(object message)
        {
            throw new NotImplementedException();
        }

        public void Warning(string fmt, params object[] vars)
        {
            throw new NotImplementedException();
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            throw new NotImplementedException();
        }

        public void Error(object message)
        {
            throw new NotImplementedException();
        }

        public void Error(string fmt, params object[] vars)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            throw new NotImplementedException();
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan)
        {
            throw new NotImplementedException();
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string properties)
        {
            throw new NotImplementedException();
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars)
        {
            throw new NotImplementedException();
        }
    }
}
