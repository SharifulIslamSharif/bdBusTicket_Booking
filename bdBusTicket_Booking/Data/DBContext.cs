using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using bdBusTicket_Booking.Data.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;
using bdBusTicket_Booking.Data.Entity.Admin;
using bdBusTicket_Booking.Data.Entity.Notification;
using bdBusTicket_Booking.Areas.Notifications.Models;

namespace bdBusTicket_Booking.Data
{
    public class DBContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DBContext()
        {

        }
        public DBContext(DbContextOptions<DBContext> options, IHttpContextAccessor _httpContextAccessor) : base(options)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }


        #region Admin
        public DbSet<AdminInfo> adminInfos { get; set; }
        #endregion

        #region Customer
        public DbSet<Customer> customers { get; set; }
        #endregion


        #region Settings Configs
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {

            var entities = ChangeTracker.Entries().Where(x => x.Entity is Base && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var currentUsername = !string.IsNullOrEmpty(_httpContextAccessor?.HttpContext?.User?.Identity?.Name)
                ? _httpContextAccessor.HttpContext.User.Identity.Name
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((Base)entity.Entity).createdAt = DateTime.Now;
                    ((Base)entity.Entity).createdBy = currentUsername;
                }
                else
                {
                    entity.Property("createdAt").IsModified = false;
                    entity.Property("createdBy").IsModified = false;
                    ((Base)entity.Entity).updatedAt = DateTime.Now;
                    ((Base)entity.Entity).updatedBy = currentUsername;
                }

            }

        }
        #endregion

        #region Notification
        public DbSet<NotificationInfo>  notificationInfos { get; set; }

        public DbQuery<AllNotificationVM>  allNotificationVMs { get; set; }
        //public DbQuery<NotificationViewModel> notificationViewModels { get; set; }
        #endregion
		

    }
}
