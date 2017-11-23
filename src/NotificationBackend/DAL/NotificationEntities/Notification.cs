using System;
using System.Collections.Generic;

namespace NotificationBackend.DAL.NotificationEntities
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public int NotificationCategoryId { get; set; }
        public int NotificationGroupId { get; set; }
        public int NotificationItemId { get; set; }
        public int UserAccountId { get; set; }
        public int? ArtistId { get; set; }
        public int? AlbumId { get; set; }
        public int? SongId { get; set; }
        public int? TourId { get; set; }
        public int? TourLineupId { get; set; }
        public int? LegId { get; set; }
        public int? LegLineupId { get; set; }
        public int? ScheduleLineupId { get; set; }
        public int? ScheduleItemId { get; set; }
        public int? EntityId { get; set; }
        public int? ContactId { get; set; }
        public int? CargoNoticeId { get; set; }
        public int? OriginatingUserAccountId { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsDeclined { get; set; }
        public DateTime? ActionDate { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadOnDate { get; set; }
        public DateTime NotificationDateTime { get; set; }

        public virtual Category NotificationCategory { get; set; }
    }
}
