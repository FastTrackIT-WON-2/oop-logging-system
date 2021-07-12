using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopLoggingSystem.Library
{
    public static class ApplicationLog
    {
        private static Logger logger;

        public static void Initialize(Logger logger)
        {
            ApplicationLog.logger = logger;
        }

        public static void WriteLog(Severity severity, string message)
        {
            if (ApplicationLog.logger != null)
            {
                ApplicationLog.logger.Write(severity, message);
            }
        }
    }
}
