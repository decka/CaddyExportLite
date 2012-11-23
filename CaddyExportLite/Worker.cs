using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;
using SignalR;
using SignalR.Hubs;
using Ninject;

namespace CaddyExportLite
{
    public class Worker
    {
        private IExportListing aExportListing;
        private IMYOBExportString aMYOBExportString;
        private IConnectionManager aConnectionManager;
        private ICanSendStringToClient aStringSender;
        private Timer aTimer;

        public Worker(  IConnectionManager aConnectionManager,
                        IExportListing aExportListing,
                        IMYOBExportString aMYOBExportString,
                        ICanSendStringToClient stringSender)
        {
            this.aConnectionManager = aConnectionManager;
            this.aExportListing = aExportListing;
            this.aMYOBExportString = aMYOBExportString;
            this.aStringSender = stringSender;
        }
        public void Initialise()
        {
            aTimer = new Timer(3000);
            aTimer.AutoReset = true;
            aTimer.Elapsed += new ElapsedEventHandler(TimerElapsed);
            aTimer.Start();
        }
        private void TimerElapsed(object source, ElapsedEventArgs e)
        {
            DoWork();
        }

        public void DoWork()
        {
            var ItemsToExport = aExportListing.FetchExportListing();

            foreach (var ExportRecord in ItemsToExport)
            {
                if (ExportRecord.taskid != null && ExportRecord.ClientGUID != null)
                {
                    if (aConnectionManager.IsClientGUIDConnected((string)ExportRecord.ClientGUID))
                    {
                        var ExportStringsForClient = aMYOBExportString.FetchExportStringsForID((int)ExportRecord.taskid);

                        foreach (var SingleExportString in ExportStringsForClient)
                        {
                            var ClientConnectionID = (string)aConnectionManager.GetConnectionIDFromClientGUID(ExportRecord.ClientGUID);
                            aStringSender.SendDataToClient(ClientConnectionID, SingleExportString);
                        }
                    }
                    else
                    {
                        Console.WriteLine("ClientGUID: {0} is not connected.", ExportRecord.ClientGUID);
                    }
                }
            }
        }
    }
}