using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite
{
    public interface IExportHandler
    {
        IEnumerable<dynamic> FetchExportListing();
        IEnumerable<string> FetchExportStringsForID(int ID);
    }
}
