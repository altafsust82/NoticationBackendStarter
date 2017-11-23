using System;
using System.Collections.Generic;

namespace NotificationBackend.DAL.NotificationEntities
{
    public partial class NotificationGroup
    {
        public NotificationGroup()
        {
            NotificationItem = new HashSet<NotificationItem>();
        }

        public int NotificationGroupId { get; set; }
        public string NotificationGroupDescription { get; set; }

        public virtual ICollection<NotificationItem> NotificationItem { get; set; }
    }
}
