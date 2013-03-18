using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite.Domain.Interfaces
{
    public interface IExportTask
    {
        IEnumerable<string> GetExportStrings();
        int ExportID { get; }
        int CaddyID { get; }
    }
}
