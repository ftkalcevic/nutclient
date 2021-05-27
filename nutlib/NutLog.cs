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
        public delegate void LogMsgDelegate(string msg);

        public static event LogMsgDelegate LogEvent = null;

        public static void Log(string msg, ELogLevel level = ELogLevel.Trace)
        {
            string s = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss ") + msg;
            System.Diagnostics.Debug.WriteLine(s);

            if (level > ELogLevel.Debug && LogEvent != null)
                LogEvent(s);
        }
    }
}
