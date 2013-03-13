using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaddyExportLite.Domain.Interfaces;

namespace CaddyExportLite.Domain
{
    public abstract class ExportTask : IExportTask
    {
        public ExportTask(int ExportID, int CaddyID)
        {
            this.ExportID = ExportID;
            this.CaddyID = CaddyID;
        }
        public int ExportID { get; private set; }
        public int CaddyID { get; private set; }
        public abstract int TaskID { get; }
    }
}
