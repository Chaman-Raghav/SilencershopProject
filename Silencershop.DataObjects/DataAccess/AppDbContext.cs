using Microsoft.EntityFrameworkCore;
using Silencershop.DataObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Silencershop.DataObjects.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserLoginHistory> UserLoginHistories { get; set; }
        public DbSet<NotificationEventType> NotificationEventTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<AuditStatus> AuditStatuses { get; set; }
        public DbSet<Audit> Audits { get; set; }
        public DbSet<Auditor> Auditors { get; set; }
       /* public DbSet<DocumentStatus> DocumentStatuses { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<FlaggedDocument> FlaggedDocuments { get; set; }
        public DbSet<AssignedUser> AssignedUsers { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<GlobalCorrectionLog> GlobalCorrectionLogs { get; set; }
        public DbSet<DocumentHistory> DocumentHistories { get; set; } */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    Role = "FFL/Admin"
                },
                new UserRole
                {
                    Id = 2,
                    Role = "FFL/User"
                },
                new UserRole
                {
                    Id = 3,
                    Role = "IOI/Admin"
                },
                new UserRole
                {
                    Id = 4,
                    Role = "IOI/User"
                });
            modelBuilder.Entity<UserStatus>().HasData(
                new UserStatus
                {
                    Id = 1,
                    Status = "Enable"
                },
                new UserStatus
                {
                    Id = 2,
                    Status = "Disable"
                });
            modelBuilder.Entity<NotificationEventType>().HasData(
                new NotificationEventType
                {
                    Id = 1,
                    Event = "Created"
                },
                new NotificationEventType
                {
                    Id = 2,
                    Event = "Created a new Version of"
                },
                new NotificationEventType
                {
                    Id = 3,
                    Event = "Flagged"
                });
            modelBuilder.Entity<AuditStatus>().HasData(
                new AuditStatus
                {
                    Id = 1,
                    Status = "Not Started"
                },
                new AuditStatus
                {
                    Id = 2,
                    Status = "In Progress"
                },
                new AuditStatus
                {
                    Id = 3,
                    Status = "Completed"
                });
        }
    }
}
