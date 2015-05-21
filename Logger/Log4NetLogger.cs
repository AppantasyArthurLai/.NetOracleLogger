using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "Logger/log4net.config")]
namespace DotNetOracleLogger.Logger
{

    public class Log4NetLogger
    {

        public static void LoggerMsg(Log4NetLoggerLevel legLevel, string logger, string msg)
        {
            log4net.ILog log = GetLogger(logger);
            switch (legLevel)
            {
                case Log4NetLoggerLevel.Debug: log.Debug(msg); break;//Debug
                case Log4NetLoggerLevel.Error: log.Error(msg); break;//Error
                case Log4NetLoggerLevel.Fatal: log.Fatal(msg); break;//Fatal
                case Log4NetLoggerLevel.Info: log.Info(msg); break;//Info
                case Log4NetLoggerLevel.Warn: log.Warn(msg); break;//Warn
                default: break;
            }
        }

        public static void LoggerMsgException(Log4NetLoggerLevel legLevel, string logger, string msg, Exception e)
        {
            log4net.ILog log = GetLogger(logger);
            switch (legLevel)
            {
                case Log4NetLoggerLevel.Debug: log.Debug(msg, e); break;//Debug
                case Log4NetLoggerLevel.Error: log.Error(msg, e); break;//Error
                case Log4NetLoggerLevel.Fatal: log.Fatal(msg, e); break;//Fatal
                case Log4NetLoggerLevel.Info: log.Info(msg, e); break;//Info
                case Log4NetLoggerLevel.Warn: log.Warn(msg, e); break;//Warn
                default: break;
            }
        }

        public static log4net.ILog GetLogger(string logger)
        {
            //var methodInfo = System.Reflection.MethodBase.GetCurrentMethod();
            //var fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name;
            //log4net.NDC.Push(fullName);
            return log4net.LogManager.GetLogger(logger);
        }

    }

    public enum Log4NetLoggerLevel
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal,
    }

}