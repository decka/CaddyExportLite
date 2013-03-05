using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite.Transport
{
    public interface IExportRepository
    {
        IEnumerable<dynamic> FetchExportListing();
        IEnumerable<string> FetchExportStringsForID(int ID);
        void MarkExportAsComplete(int exportID, string result);
    }
}
