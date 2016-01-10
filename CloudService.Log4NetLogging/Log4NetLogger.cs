using System;
using System.Text;
using System.Diagnostics;
using CloudService.Common.Logging;
using log4net.Util;


namespace CloudService.Log4NetLog
{
    /// <summary>
    /// Classe implementa o Log baseado no artigo de praticas de monitoramento
    /// http://www.asp.net/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/monitoring-and-telemetry
    /// </summary>
    public class Log4NetLogger : ILogger
    {

        private log4net.ILog _logger;

     
        public Log4NetLogger()
        {
            
        }

        public Log4NetLogger(log4net.ILog logger)
        {
            _logger = logger;
        }

        #region "Implementacao Interface ILogger"
        public void Information(object message, string memberName = "", string sourceFilePath = "")
        {
            _logger.Info(message);
        }

        public void Information(string fmt, params object[] vars)
        {
            _logger.InfoFormat(fmt, vars);
        }

        public void Information(Exception exception,  string fmt, params object[] vars)
        {
            throw new NotImplementedException();      
        }

        public void Warning(object message, string memberName = "", string sourceFilePath = "")
        {
            _logger.Warn(message);
        }

        public void Warning(string fmt, params object[] vars)
        {
            _logger.WarnFormat(fmt, vars);
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            throw new NotImplementedException();  
        }

        public void Error(object message, string memberName = "", string sourceFilePath = "")
        {
            _logger.Error(message);
        }

        public void Error(string fmt, params object[] vars)
        {
            _logger.ErrorFormat(fmt, vars);
        }

        public void Error(Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            Trace.TraceError(FormatExceptionMessage(exception, fmt, vars));   
        }

        public void TraceApi(string componentName, string method, TimeSpan timespan)
        {
            TraceApi(componentName,method,timespan,"");
        }
        public void TraceApi(string componentName, string method, TimeSpan timespan, string fmt, params object[] vars)
        {
            TraceApi(componentName, method, timespan, string.Format(fmt, vars));
        }
        public void TraceApi(string componentName, string method, TimeSpan timespan, string properties)
        {
            string message = String.Concat("Component:", componentName, ";Method:", method, ";Timespan:", timespan.ToString(), ";Properties:", properties);
            _logger.Info(message);
        }
        #endregion

        #region "Suporte tratamento mensagens"
        private static string TratarMensagem(string message, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var retorno = message;
            if (!String.IsNullOrWhiteSpace(memberName))
                retorno = retorno + ";Member:" + memberName;
            if (!String.IsNullOrWhiteSpace(sourceFilePath))
                retorno = retorno + ";SourceFile:" + sourceFilePath;
            if (sourceLineNumber > 0)
                retorno = retorno + ";SourceLine:" + sourceLineNumber.ToString();

            return retorno;
        }

        private static string FormatExceptionMessage(Exception exception, string fmt, object[] vars)
        {
            // Simple exception formatting: for a more comprehensive version see 
            // http://code.msdn.microsoft.com/windowsazure/Fix-It-app-for-Building-cdd80df4
            var msg = string.Format(fmt, vars);
            var msgfinal = string.Format(";Exception Details={0}",ExceptionUtils.FormatException(exception, includeContext:true));
            return (msg + msgfinal);
        }

        private static string FormatExceptionMessage(Exception exception, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var sb = new StringBuilder();
            sb.Append(TratarMensagem("",memberName,sourceFilePath,sourceLineNumber));
            sb.Append(" Exception: ");
            sb.Append(exception.ToString());
            var errorinner = exception.InnerException == null ? "" : exception.InnerException.ToString();
            sb.Append(" StackTrace:" + errorinner);
            return sb.ToString();
        }
        #endregion
    }
}
