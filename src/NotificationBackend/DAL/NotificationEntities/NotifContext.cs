using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data.Common;

namespace NotificationBackend.DAL.NotificationEntities
{
    public partial class NotifContext : DbContext
    {
        private DbConnection _connection;

        public NotifContext(DbConnection connection)
        {
            _connection = connection;
        }

        public NotifContext(DbContextOptions<NotifContext> options)
            : base(options)

        { }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<NotificationGroup> NotificationGroup { get; set; }
        public virtual DbSet<NotificationItem> NotificationItem { get; set; }
        public virtual DbSet<UserDevices> UserDevices { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=ALTAF-ASUS;Database=Notif;Trusted_Connection=false; User Id=CE; Password=CE1234");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryDescription)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.ActionDate).HasColumnType("datetime");

                entity.Property(e => e.IsAccepted).HasDefaultValueSql("0");

                entity.Property(e => e.IsDeclined).HasDefaultValueSql("0");

                entity.Property(e => e.IsRead).HasDefaultValueSql("0");

                entity.Property(e => e.NotificationDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ReadOnDate).HasColumnType("datetime");

                entity.HasOne(d => d.NotificationCategory)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.NotificationCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Notification_Category");
            });

            modelBuilder.Entity<NotificationGroup>(entity =>
            {
                entity.Property(e => e.NotificationGroupDescription)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<NotificationItem>(entity =>
            {
                entity.HasKey(e => new { e.NotificationGroupId, e.NotificationItemId })
                    .HasName("PK_NotificationItemId");

                entity.Property(e => e.NotificationItemId).ValueGeneratedOnAdd();

                entity.Property(e => e.IsActionable).HasDefaultValueSql("0");

                entity.Property(e => e.NotificationItemDescription)
                    .IsRequired()
                    .HasColumnType("varchar(1024)");

                entity.HasOne(d => d.NotificationGroup)
                    .WithMany(p => p.NotificationItem)
                    .HasForeignKey(d => d.NotificationGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_NotificationItem_NotificationGroup");
            });

            modelBuilder.Entity<UserDevices>(entity =>
            {
                entity.HasKey(e => new { e.UserAccountId, e.DeviceToken })
                    .HasName("PK_UserDevices");

                entity.Property(e => e.DeviceToken).HasMaxLength(100);

                entity.HasOne(d => d.UserAccount)
                    .WithMany(p => p.UserDevices)
                    .HasForeignKey(d => d.UserAccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserDevices_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserAccountId)
                    .HasName("PK_Users");

                entity.Property(e => e.UserAccountId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}