using System;
using System.Collections.Generic;

namespace NotificationBackend.DAL.NotificationEntities
{
    public partial class UserDevices
    {
        public int UserAccountId { get; set; }
        public string DeviceToken { get; set; }

        public virtual Users UserAccount { get; set; }
    }
}
