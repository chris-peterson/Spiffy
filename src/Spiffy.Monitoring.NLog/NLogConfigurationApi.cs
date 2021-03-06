﻿using System;

namespace Spiffy.Monitoring.NLog
{
    public class NLogConfigurationApi
    {
        internal NLogTargetsConfigurationApi TargetsConfiguration { get; private set; }
        internal bool EnableAsyncLogging { get; private set; } = true;

        public NLogConfigurationApi Targets(Action<NLogTargetsConfigurationApi> customize)
        {
            TargetsConfiguration = new NLogTargetsConfigurationApi();
            if (customize != null)
            {
                customize(TargetsConfiguration);
            }
            return this;
        }

        internal Level MinimumLogLevel { get; private set; } = Level.Info;

        public NLogConfigurationApi DisableAsyncLogging()
        {
            EnableAsyncLogging = false;
            return this;
        }

        public NLogConfigurationApi MinLevel(Level minLevel)
        {
            MinimumLogLevel = minLevel;
            return this;
        }
    }
}