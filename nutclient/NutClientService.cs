using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace nutclient
{
    class NutClientService: ServiceBase
    {
        NutServiceThread nt;

        public NutClientService()
        {
            this.CanHandlePowerEvent = true;
        }

        protected override void OnStart(string[] args)
        {
            nt = new NutServiceThread();
            nt.Start();
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            nt.Stop();
            base.OnStop();
        }

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            nutlib.NutLog.Log($"OnPowerEvent {powerStatus}", nutlib.NutLog.ELogLevel.Debug);

            if (powerStatus == PowerBroadcastStatus.Suspend)
                nt.PowerEvent(true);
            else if (powerStatus == PowerBroadcastStatus.ResumeSuspend)
                nt.PowerEvent(false);

            return base.OnPowerEvent(powerStatus);
        }
    }
}
