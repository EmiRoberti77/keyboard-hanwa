using System;
using System.Reflection;
using NLog;
using NLog.Config;

namespace CommaBoard.Store.Static
{
    public static class Log
    {
        
        private static Logger commaLog = LogManager.GetCurrentClassLogger();

        public static string TraceBytes = "";

        public static string TraceType = "";

        public static MethodBase MBase;

        public static void InfoMessage(string msg, string method)
        {
            string message = $"Method: {method} \r\nMessage: {msg}";

            LogManager.Configuration = new XmlLoggingConfiguration("Nlog.config");

            commaLog.Info(message);
        }

        public static void InfoMessage(string msg)
        {
            LogManager.Configuration = new XmlLoggingConfiguration("Nlog.config");

            commaLog.Info(msg);
        }

        public static void InfoMessage(string msg, string prop, string data )
        {
            LogManager.Configuration = new XmlLoggingConfiguration("Nlog.config");

            string fullmsg = "{" + prop + "} " + msg + ", \"" + data + "\"";

            commaLog.Info(fullmsg);
        }

        public static void WarningMessage(string msg, string method)
        {
            string message = $"Method: {method} \r\nMessage: {msg}";

            LogManager.Configuration = new XmlLoggingConfiguration("Nlog.config");

            commaLog.Warn( message);
        }

        public static void WarningMessage(string msg)
        {

            LogManager.Configuration = new XmlLoggingConfiguration("Nlog.config");

            commaLog.Warn(msg);
        }

        public static void ErrorMessage(Exception ex, string msg, string method)
        {

            string message = $"Method: {method} \r\nMessage: {msg}";
            
            LogManager.Configuration = new XmlLoggingConfiguration("Nlog.config");

            commaLog.Error(ex, message);
        }

        public static void ErrorMessage(Exception ex, string msg)
        {
            LogManager.Configuration = new XmlLoggingConfiguration("Nlog.config");

            commaLog.Error(ex, msg);
        }

        public static void TraceMessage()
        {
            LogManager.Configuration = new XmlLoggingConfiguration("Nlog.config");

            commaLog.Trace("Incoming Type: " + TraceType + "\r\nIncoming Bytes: " + TraceBytes);
        }
    }
}
