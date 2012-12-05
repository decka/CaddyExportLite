using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaddyExportLite
{
    public interface ICanMarkExportAsComplete
    {
        void MarkExportAsComplete(int exportID, string result);
    }
}
