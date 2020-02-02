using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    /**
     * How to make changes to the database - not used for reading
     */
    interface IDBUpdatable
    {
        bool UpdateSelf();
        bool InsertNew();
        bool InsertUpdateDelete(string query);
    }
}
