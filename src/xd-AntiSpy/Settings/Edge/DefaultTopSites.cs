﻿using Microsoft.Win32;
using System;
using System.Drawing;

using xdAntiSpy;

namespace Settings.Edge
{
    public class DefaultTopSites : SettingsBase
    {
        public DefaultTopSites(Logger logger) : base(logger)
        {
        }

        private const string keyName = @"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Edge";
        private const int desiredValue = 0;

        public override string ID() => "Don't Show Sponsored links in new tab page";

        public override string Info() => "Hide default top sites from the new tab page in Microsoft Edge";

        public override bool CheckFeature()
        {
            return Utils.IntEquals(keyName, "NewTabPageHideDefaultTopSites", desiredValue);
        }

        public override bool DoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "NewTabPageHideDefaultTopSites", 0, Microsoft.Win32.RegistryValueKind.DWord);

                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Code red in " + ex.Message, Color.Red);
            }

            return false;
        }

        public override bool UndoFeature()
        {
            try
            {
                Registry.SetValue(keyName, "NewTabPageHideDefaultTopSites", 1, Microsoft.Win32.RegistryValueKind.DWord);

                return true;
            }
            catch (Exception ex)
            {
                logger.Log("Code red in " + ex.Message, Color.Red);
            }

            return false;
        }
    }
}