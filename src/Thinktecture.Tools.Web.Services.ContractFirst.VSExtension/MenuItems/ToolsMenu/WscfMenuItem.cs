﻿using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;

namespace Thinktecture.Tools.Web.Services.ContractFirst.VSExtension.MenuItems.ToolsMenu
{
    internal class WscfMenuItem
    {
        private static void BeforeQueryStatus(object sender, EventArgs e)
        {
            var menu = sender as OleMenuCommand;
            if (null != menu) menu.Visible = IsVisible();
        }

        public static bool IsVisible()
        {
            return true;
        }

        private static void MenuItemCallbackHandler(object sender, EventArgs e)
        {
            VSPackage.ServiceFacade.ExecuteCommand(WscfCommand.GenerateWebServiceCode);
        }

        public static void Register(MenuCommandService mcs)
        {
            var cmdId = new CommandID(VSCommandTable.PackageGuids.VSPackageCmdSetGuid, VSCommandTable.CommandIds.ContractFirstCommand);
            var menu = new OleMenuCommand(MenuItemCallbackHandler, cmdId);
            menu.BeforeQueryStatus += BeforeQueryStatus;
            mcs.AddCommand(menu);
        }
    }
}