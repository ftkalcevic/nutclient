using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace nutlib
{
    public class NutConfig
    {
        private const string registryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\FranksWorkshop\NUTClient";
        public enum EShutdownCondition
        {
            afterNSeconds,
            nSecondsRemaining,
            belowNPercent,
            finalShutdown
        };
        public enum EShutdownAction
        {
            Hibernate,
            Shutdown
        };
        public enum ERunAs
        {
            Service,
            Application
        };

        public EShutdownCondition shutdownCondition;
        public EShutdownAction shutdownAction;
        public ERunAs runAs;
        public int afterSeconds;
        public int secondsRemaining;
        public int percentRemaining;
        public bool startWithWindows;
        public bool minimiseToTray;

        public string hostname;
        public int port;
        public string username;
        public string password;
        public string upsDevice;
        public int pollPeriod;

        public NutConfig()
        {
            shutdownCondition = EShutdownCondition.finalShutdown;
            shutdownAction = EShutdownAction.Shutdown;
            runAs = ERunAs.Application;
            afterSeconds = 120;
            secondsRemaining = 300;
            percentRemaining = 40;
            startWithWindows = true;
            minimiseToTray = true;
            port = 3493;
            pollPeriod = 15;

            hostname = "nas2";
            username = "upsmon";
            password = "";
            upsDevice = "ups";
        }

        public void read()
        {
            port = ReadSettingInt("port", port);
            pollPeriod = ReadSettingInt("pollPeriod", pollPeriod);
            minimiseToTray = ReadSettingBool("minimiseToTray", minimiseToTray);
            startWithWindows = ReadSettingBool("startWithWindows", startWithWindows);
            percentRemaining = ReadSettingInt("percentRemaining", percentRemaining);
            secondsRemaining = ReadSettingInt("secondsRemaining", secondsRemaining);
            afterSeconds = ReadSettingInt("afterSeconds", afterSeconds);
            shutdownCondition = (EShutdownCondition)ReadSettingInt("shutdownCondition", (int)shutdownCondition);
            shutdownAction = (EShutdownAction)ReadSettingInt("shutdownAction", (int)shutdownAction);
            runAs = (ERunAs)ReadSettingInt("runAs", (int)runAs);
            hostname = ReadSettingString("hostname", hostname);
            username = ReadSettingString("username", username);
            password = ReadSettingString("password", password);
            upsDevice = ReadSettingString("upsDevice", upsDevice);
        }

        public void write()
        {
            WriteSetting("port", port);
            WriteSetting("pollPeriod", pollPeriod);
            WriteSetting("minimiseToTray", minimiseToTray);
            WriteSetting("startWithWindows", startWithWindows);
            WriteSetting("percentRemaining", percentRemaining);
            WriteSetting("secondsRemaining", secondsRemaining);
            WriteSetting("afterSeconds", afterSeconds);
            WriteSetting("shutdownCondition", (int)shutdownCondition);
            WriteSetting("shutdownAction", (int)shutdownAction);
            WriteSetting("runAs", (int)runAs);
            WriteSetting("hostname", hostname);
            WriteSetting("username", username);
            WriteSetting("password", password);
            WriteSetting("upsDevice", upsDevice);
        }

        private void WriteSetting(in string name, in int value )
        {
            Registry.SetValue(registryKey, name, value);
        }
        private void WriteSetting(in string name, in string value)
        {
            Registry.SetValue(registryKey, name, value);
        }
        private void WriteSetting(in string name, in bool value)
        {
            Registry.SetValue(registryKey, name, value ? 1 : 0);
        }
        private int ReadSettingInt(in string name, in int deflt )
        {
            return (int)Registry.GetValue(registryKey, name, deflt);
        }
        private string ReadSettingString(in string name, in string deflt )
        {
            return (string)Registry.GetValue(registryKey, name, deflt);
        }
        private bool ReadSettingBool(in string name, in bool deflt )
        {
            return (int)Registry.GetValue(registryKey, name, deflt?1:0) == 0 ? false : true;
        }

    }
}
