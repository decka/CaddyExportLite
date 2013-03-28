using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite.DAL
{
    public interface IExportRepository
    {
        IEnumerable<dynamic> FetchExportListing();
        IEnumerable<string> FetchPurchaseExportStrings(int PurchaseID);
        void MarkExportAsComplete(int exportID, string result);
    }
}
