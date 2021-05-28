using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using nutlib;

namespace nutclient
{
    class NutServiceThread
    {
        static Thread thread;
        static nutlib.NutControl nut;

        public static void ThreadProc()
        {
            nut = new nutlib.NutControl(false);
            nut.Start();

            thread.Join();
        }

        public NutServiceThread()
        {
            thread = new Thread(new ThreadStart(ThreadProc));
        }

        public void Start()
        {
            thread.Start();
        }

        internal void PowerEvent(bool suspend)
        {
            if (nut != null)
                nut.PowerEvent(suspend);
        }

        public void Stop()
        {
            thread.Interrupt();
            nut.Stop();
            nut = null;
        }
    }
}
