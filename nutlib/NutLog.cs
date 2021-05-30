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
            Trace,
            Event,
            Exception
        };
        static public ELogLevel logLevel { get; set; }

        public delegate void LogMsgDelegate(string msg);
        public static event LogMsgDelegate LogEvent = null;
        public static string LogFilePath = null;

        static NutLog()
        {
            logLevel = ELogLevel.Trace;
            LogFilePath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + System.IO.Path.DirectorySeparatorChar + "NutClient.log";
        }

        public static void Log(string msg, ELogLevel level = ELogLevel.Trace)
        {
            string s = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + msg;

            System.Diagnostics.Debug.WriteLine(s);

            if (level >= logLevel)
            {
                try
                {
                    System.IO.File.AppendAllText(LogFilePath, s + "\r\n");
                }
                catch (Exception)
                {
                }

                if (LogEvent != null)
                {
                    try
                    {
                        LogEvent(s);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
