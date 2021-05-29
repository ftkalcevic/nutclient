using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace nutlib
{
    public class NutControl
    {
        public Nut nut;
        public NutConfig cfg;
        private DateTime? onBatteryStartTime;
        private bool isApplication { get; set; }

        // true if we are the active - we will shutdown if we are on battery power
        public bool isActive
        {
            get
            {
                return (isApplication && cfg.runAs == NutConfig.ERunAs.Application) ||
                       (!isApplication && cfg.runAs == NutConfig.ERunAs.Service);
            }
        }

        public void Start()
        {
            NutLog.Log("Starting NUTClient communications");
            NutLog.Log($"hostname={cfg.hostname}");
            NutLog.Log($"port={cfg.port}");
            NutLog.Log($"username={cfg.username}");
            NutLog.Log($"upsDevice={cfg.upsDevice}");

            nut.Init(isApplication, cfg.hostname, cfg.port, cfg.username, cfg.password, cfg.upsDevice);
            NutLog.Log($"Started", NutLog.ELogLevel.Debug);
        }

        public void PowerEvent(bool suspend)
        {
            nut.PowerEvent(suspend);
        }

        public void Stop()
        {
            nut.Stop();
        }

        public NutControl(bool application)
        {
            NutLog.Log("Initialising NutControl", NutLog.ELogLevel.Debug);
            isApplication = application;

            cfg = new NutConfig();
            cfg.read();

            nut = new Nut(cfg.pollPeriod);
            nut.update += Nut_update;

            onBatteryStartTime = null;
            NutLog.Log("Initialised", NutLog.ELogLevel.Debug);
        }

        private void Nut_update(Nut.EUPSStatus status, in Dictionary<string, string> vars)
        {
            try
            {
                NutLog.Log($"status='{vars["ups.status"]}' charge={vars["battery.charge"]} runtime={vars["battery.runtime"]}");
                if (isActive)
                {

                    // regardless of other settings - if we are in FSD, time to stop
                    if ((status & Nut.EUPSStatus.FSD) == Nut.EUPSStatus.FSD)
                    {
                        NutLog.Log("Received FSD message.  Shutting down now.");
                        Shutdown();
                    }
                    else
                    {
                        // on battery
                        if ((status & Nut.EUPSStatus.OB) == Nut.EUPSStatus.OB)
                        {
                            switch (cfg.shutdownCondition)
                            {
                                case NutConfig.EShutdownCondition.afterNSeconds:
                                    ProcessShutdownAfterNSeconds();
                                    break;

                                case NutConfig.EShutdownCondition.belowNPercent:
                                    ProcessShutdownBelowPercent(vars);
                                    break;

                                case NutConfig.EShutdownCondition.nSecondsRemaining:
                                    ProcessShutdownSecondsRemaining(vars);
                                    break;
                            }
                        }
                        else
                        {
                            onBatteryStartTime = DateTime.Now;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                NutLog.Log(e.ToString());
            }
        }

        private void ProcessShutdownSecondsRemaining(Dictionary<string, string> vars)
        {
            int runtime = int.Parse(vars["battery.runtime"]);
            if (runtime < cfg.secondsRemaining)
            {
                NutLog.Log($"Battery remaining runtime {runtime}s is below threshold {cfg.secondsRemaining}s.  Shutting down.");
                Shutdown();
            }
            else
            {
                NutLog.Log($"Battery remaining runtime {runtime}s > {cfg.secondsRemaining}s.");
            }
        }

        private void ProcessShutdownBelowPercent(Dictionary<string, string> vars)
        {
            int charge = int.Parse(vars["battery.charge"]);
            if (charge < cfg.percentRemaining)
            {
                NutLog.Log($"Battery charge {charge}% is below threshold {cfg.percentRemaining}%.  Shutting down.");
                Shutdown();
            }
            else
            {
                NutLog.Log($"Battery charge {charge}% > {cfg.percentRemaining}%.");
            }
        }

        private void ProcessShutdownAfterNSeconds()
        {
            if (onBatteryStartTime == null)
            {
                onBatteryStartTime = DateTime.Now;
            }
            else
            {
                int elapsedSeconds = (int)DateTime.Now.Subtract((DateTime)onBatteryStartTime).TotalSeconds;
                if (elapsedSeconds > cfg.afterSeconds)
                {
                    NutLog.Log($"On battery charge for {elapsedSeconds}s.  This has exceeded the threshold of {cfg.afterSeconds}s.  Shutting down.");
                    Shutdown();
                }
                else
                {
                    NutLog.Log($"On battery charge for {elapsedSeconds}s/{cfg.afterSeconds}s.");
                }
            }
        }

        public void Shutdown()
        {
            if (cfg.shutdownAction == NutConfig.EShutdownAction.Hibernate)
            {
                NutLog.Log("Hibernating");
                Process.Start("shutdown.exe", "/h");
            }
            else // if (cfg.shutdownAction == NutConfig.EShutdownAction.Shutdown)
            {
                NutLog.Log("Shutting down");
                Process.Start("shutdown.exe", "/s /t 0");
            }
        }
    }
}

/*
 * TODO - keep track of time since on battery - be smart about it.  Count pollperiod chunks, resetting after n somethings
 */

