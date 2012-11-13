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
        private DatabaseConnection aDatabaseConnection;
        private IExportListing aExportListing;
        private IMYOBExportString aMYOBExportString;
        private ConnectionManager aConnectionManager;
        private IHubContext theHubContext;
        private Timer aTimer;
                
        public void Initialise()
        {
            aDatabaseConnection = new DatabaseConnection();
            aExportListing = new ExportListing(aDatabaseConnection.connection);
            aMYOBExportString = new MYOBExportString(aDatabaseConnection.connection);
            aConnectionManager = new ConnectionManager();
            theHubContext = GlobalHost.ConnectionManager.GetHubContext<CaddyExportHub>();

            //IKernel kernel = new StandardKernel();
            //var aConnectionManager = kernel.Get<ConnectionManager>();
            //kernel.Bind<IConnectionManager>().To<ConnectionManager>();

            aTimer = new Timer(1000);
            aTimer.AutoReset = true;
            aTimer.Elapsed += new ElapsedEventHandler(TimerElapsed);
            aTimer.Start();
        }
        private void TimerElapsed(object source, ElapsedEventArgs e)
        {
            DoWork(this.aConnectionManager, this.aExportListing, this.aMYOBExportString, this.theHubContext);
        }

        public void DoWork( ConnectionManager aConnectionManager,
                            IExportListing aExportListing, 
                            IMYOBExportString aMYOBExportString,
                            IHubContext theHubContext)
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
                            var ClientConnectionID = aConnectionManager.GetConnectionIDFromClientGUID(ExportRecord.ClientGUID);
                            Console.WriteLine("{0}:{1}", ClientConnectionID, SingleExportString);
                            //theHubContext.Clients[ClientConnectionID].addMessage(SingleExportString);
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