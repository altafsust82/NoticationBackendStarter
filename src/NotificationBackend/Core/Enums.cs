using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationBackend.Core
{
    public class Enums
    {
        public enum ObjectState
        {
            Unchanged,
            Added,
            Modified,
            Deleted,
            Detached
        }
    }
}
