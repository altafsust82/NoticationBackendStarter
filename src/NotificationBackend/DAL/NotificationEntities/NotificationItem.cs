using System;
using System.Collections.Generic;

namespace NotificationBackend.DAL.NotificationEntities
{
    public partial class NotificationItem
    {
        public int NotificationGroupId { get; set; }
        public int NotificationItemId { get; set; }
        public string NotificationItemDescription { get; set; }
        public bool IsActionable { get; set; }

        public virtual NotificationGroup NotificationGroup { get; set; }
    }
}
