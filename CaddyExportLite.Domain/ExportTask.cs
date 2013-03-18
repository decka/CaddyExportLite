using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaddyExportLite.Domain.Interfaces;
using CaddyExportLite.DAL;

namespace CaddyExportLite.Domain
{
    public abstract class ExportTask : IExportTask
    {
        public ExportTask(IExportRepository Repo)
        {
            this.Repo = Repo;
        }
        public ExportTask(int ExportID, int CaddyID, IExportRepository Repo) : this(Repo)
        {
            this.ExportID = ExportID;
            this.CaddyID = CaddyID;
        }
        public abstract IEnumerable<string> GetExportStrings();

        public int ExportID { get; private set; }
        public int CaddyID { get; private set; }
        protected IExportRepository Repo;
    }
}
