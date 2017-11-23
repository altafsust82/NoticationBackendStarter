using System;
using System.Collections.Generic;

namespace NotificationBackend.DAL.NotificationEntities
{
    public partial class Category
    {
        public Category()
        {
            Notification = new HashSet<Notification>();
        }

        public int CategoryId { get; set; }
        public int CategoryTypeId { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<Notification> Notification { get; set; }
    }
}
