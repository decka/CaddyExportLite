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
    public class Worker : ICanMarkExportAsComplete
    {
        private IExportHandler aExportHandler;
        private IConnectionManager aConnectionManager;
        private ICanSendStringToClient aStringSender;
        private Timer aTimer;

        public Worker(  IConnectionManager aConnectionManager,
                        IExportHandler aExportHandler,
                        ICanSendStringToClient stringSender)
        {
            this.aConnectionManager = aConnectionManager;
            this.aExportHandler = aExportHandler;
            this.aStringSender = stringSender;
        }
        public void Initialise()
        {
            var PollingTime = Properties.Settings.Default.PollingTime;
            if (PollingTime > 0)
            {
                aTimer = new Timer(PollingTime);
                aTimer.AutoReset = true;
                aTimer.Elapsed += new ElapsedEventHandler(TimerElapsed);
                aTimer.Start();
            }
            else
            {
                throw new ArgumentException("pollingTime Setting cannot be less than or equal to 0.");
            }
        }
        private void TimerElapsed(object source, ElapsedEventArgs e)
        {
            DoWork();
        }

        public void DoWork()
        {
            var ItemsToExport = aExportHandler.FetchExportListing();

            foreach (var ExportRecord in ItemsToExport)
            {
                if (ExportRecord.taskid != null && ExportRecord.ClientGUID != null)
                {
                    if (aConnectionManager.IsClientGUIDConnected((string)ExportRecord.ClientGUID))
                    {
                        var ExportStringsForClient = aExportHandler.FetchExportStringsForID((int)ExportRecord.taskid);

                        foreach (var SingleExportString in ExportStringsForClient)
                        {
                            var ClientConnectionID = (string)aConnectionManager.GetConnectionIDFromClientGUID(ExportRecord.ClientGUID);
                            aStringSender.SendDataToClient(ClientConnectionID, SingleExportString);
                        }
                    }
                }
            }
        }

        public void MarkExportAsComplete(int exportID, string result)
        {
            aExportHandler.MarkExportAsComplete(exportID, result);
        }
    }
}