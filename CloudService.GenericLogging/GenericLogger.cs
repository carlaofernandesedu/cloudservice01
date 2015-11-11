using System;
using System.Text;
using System.Diagnostics;


namespace CloudService.Common.Logging
{
    /// <summary>
    /// Classe implementa o Log baseado no artigo de praticas de monitoramento
    /// http://www.asp.net/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/monitoring-and-telemetry
    /// </summary>
    public class GenericLogger : ILogger
    {
        #region "Implementacao Interface ILogger"
        public void Information(object message, string memberName = "", string sourceFilePath = "")
        {
            Trace.TraceInformation(TratarMensagem(Convert.ToString(message),memberName,sourceFilePath,0));
        }

        public void Information(string fmt, params object[] vars)
        {
            Trace.TraceInformation(fmt, vars);
        }

        public void Information(Exception exception,  string fmt, params object[] vars)
        {
            Trace.TraceInformation(FormatExceptionMessage(exception, fmt, vars));
        }

        public void Warning(object message, string memberName = "", string sourceFilePath = "")
        {
            Trace.TraceWarning(TratarMensagem(Convert.ToString(message), memberName, sourceFilePath, 0));
        }

        public void Warning(string fmt, params object[] vars)
        {
            Trace.TraceWarning(fmt, vars);
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            Trace.TraceWarning(FormatExceptionMessage(exception, fmt, vars));   
        }

        public void Error(object message, string memberName = "", string sourceFilePath = "")
        {
            Trace.TraceError(TratarMensagem(Convert.ToString(message), memberName, sourceFilePath, 0));
        }

        public void Error(string fmt, params object[] vars)
        {
            Trace.TraceError(fmt, vars);
        }

        public void Error(Exception exception, string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            Trace.TraceError(FormatExceptionMessage(exception, memberName, sourceFilePath, sourceLineNumber));
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
            Trace.TraceInformation(message);
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
            var sb = new StringBuilder();
            sb.Append(string.Format(fmt, vars));
            sb.Append(" Exception: ");
            sb.Append(exception.ToString());
            return sb.ToString();
        }

        private static string FormatExceptionMessage(Exception exception, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            var sb = new StringBuilder();
            sb.Append(TratarMensagem("",memberName,sourceFilePath,sourceLineNumber));
            sb.Append(" Exception: ");
            sb.Append(exception.ToString());
            var errorinner = exception.InnerException == null ? "" : exception.InnerException.ToString();
            sb.AppendLine(errorinner);
            return sb.ToString();
        }
        #endregion
    }
}
