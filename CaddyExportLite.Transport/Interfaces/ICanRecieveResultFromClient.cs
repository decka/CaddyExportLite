using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite.Transport
{
    public interface ICanMarkExportAsComplete
    {
        void MarkExportAsComplete(int exportID, string result);
    }
}
