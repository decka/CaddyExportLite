using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite.Domain
{
    public class ExportTask
    {
        public ExportType TaskType { get; set; }
        public Guid CaddyGUID { get; set; }
    }
}
