using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaddyExportLite.DAL;

namespace CaddyExportLite.Domain
{
    public class PurchaseTask : ExportTask
    {
        public PurchaseTask(int ExportID, int CaddyID, int PurchaseID, IExportRepository Repo) : base(ExportID, CaddyID, Repo)
        {
            this.PurchaseID = PurchaseID;
        }
        public override IEnumerable<string> GetExportStrings()
        {
            if (PurchaseID > 0)
            {
                return base.Repo.FetchPurchaseExportStrings(PurchaseID);
            }
            else
            {
                throw new ArgumentException("PurchaseID must be greater than zero.");
            }
        }
        public int PurchaseID { get; set; }
    }
}
