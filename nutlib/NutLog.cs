using System;
using System.Collections.Generic;
using System.Text;

namespace nutlib
{
    public class NutLog
    {
        public enum ELogLevel
        {
            Debug,
            Trace
        };
        const ELogLevel logLevel = ELogLevel.Trace;

        public delegate void LogMsgDelegate(string msg);
        public static event LogMsgDelegate LogEvent = null;
        public static string LogFilePath = null;

        static NutLog()
        {
            LogFilePath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + System.IO.Path.DirectorySeparatorChar + "NutClient.log";
        }

        public static void Log(string msg, ELogLevel level = ELogLevel.Trace)
        {
            string s = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + msg;

            System.Diagnostics.Debug.WriteLine(s);

            if (level >= logLevel)
            {
                System.IO.File.AppendAllText(LogFilePath, s + "\r\n");
            }

            if (level >= logLevel && LogEvent != null)
            {
                LogEvent(s);
            }
        }
    }
}
