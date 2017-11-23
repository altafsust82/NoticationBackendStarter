using System;
using System.Collections.Generic;

namespace NotificationBackend.DAL.NotificationEntities
{
    public partial class Users
    {
        public Users()
        {
            UserDevices = new HashSet<UserDevices>();
        }

        public int UserAccountId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserDevices> UserDevices { get; set; }
    }
}
