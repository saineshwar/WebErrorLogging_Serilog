using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Serilog;
using Serilog.Events;

namespace WebErrorLogging.Utilities
{
    public static class HelperStoreSqlLog
    {
        private static readonly ILogger Errorlog;
        private static readonly ILogger Warninglog;
        private static readonly ILogger Debuglog;
        private static readonly ILogger Verboselog;
        private static readonly ILogger Fatallog;
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringLogging"].ToString();

        static HelperStoreSqlLog()
        {

            Errorlog = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.MSSqlServer(ConnectionString, "Serilogs")
                .CreateLogger();

            Warninglog = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.MSSqlServer(ConnectionString, "Serilogs")
                .CreateLogger();

            Debuglog = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.MSSqlServer(ConnectionString, "Serilogs")
                .CreateLogger();

            Verboselog = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.MSSqlServer(ConnectionString, "Serilogs")
                .CreateLogger();

            Fatallog = new LoggerConfiguration()
                .MinimumLevel.Fatal()
                .WriteTo.MSSqlServer(ConnectionString, "Serilogs")
                .CreateLogger();

        }

        public static void WriteError(Exception ex, string message)
        {
            //Error - indicating a failure within the application or connected system
            Errorlog.Write(LogEventLevel.Error, ex, message);
        }

        public static void WriteWarning(Exception ex, string message)
        {
            //Warning - indicators of possible issues or service / functionality degradation
            Warninglog.Write(LogEventLevel.Warning, ex, message);
        }

        public static void WriteDebug(Exception ex, string message)
        {
            //Debug - internal control flow and diagnostic state dumps to facilitate pinpointing of recognised problems
            Debuglog.Write(LogEventLevel.Debug, ex, message);
        }

        public static void WriteVerbose(Exception ex, string message)
        {
            // Verbose - tracing information and debugging minutiae; generally only switched on in unusual situations
            Verboselog.Write(LogEventLevel.Verbose, ex, message);
        }

        public static void WriteFatal(Exception ex, string message)
        {
            //Fatal - critical errors causing complete failure of the application
            Fatallog.Write(LogEventLevel.Fatal, ex, message);
        }

        public static void WriteInformation(Exception ex, string message)
        {
            //Fatal - critical errors causing complete failure of the application
            Fatallog.Write(LogEventLevel.Fatal, ex, message);
        }
    }
}