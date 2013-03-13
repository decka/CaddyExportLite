using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite.Domain
{
    public class PurchaseTask : ExportTask
    {
        public PurchaseTask(int ExportID, int CaddyID, int PurchaseID) : base(ExportID, CaddyID)
        {
            this.PurchaseID = PurchaseID;
        }
        public int PurchaseID { get; set; }
        public override int TaskID { get { return this.PurchaseID; } }
    }
}
