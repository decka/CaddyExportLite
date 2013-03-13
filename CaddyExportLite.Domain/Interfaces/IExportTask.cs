using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite.Domain.Interfaces
{
    public interface IExportTask
    {
        int ExportID { get; }
        int CaddyID { get; }
        int TaskID { get; }
    }
}
