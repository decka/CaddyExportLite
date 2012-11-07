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
        private ExportListing aExportListing;
        private MYOBExportString aMYOBExportString;
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
            aTimer.Elapsed += new ElapsedEventHandler(DoWork);
            aTimer.Start();
        }

        private void DoWork(object source, ElapsedEventArgs e)
        {
            var ExportListing = aExportListing.FetchExportListing();

            foreach (var ExportRecord in ExportListing)
            {
                if (ExportRecord.ExportID != null)
                {
                    var ExportStrings = aMYOBExportString.FetchExportStringsForID((int)ExportRecord.ExportID);
                    if (ExportRecord.ClientGUID != null)
                    {
                        foreach (var SingleExportString in ExportStrings)
                            theHubContext.Clients[ExportRecord.ClientGUID].addMessage(SingleExportString);
                    }
                }
            }
        }
    }
}