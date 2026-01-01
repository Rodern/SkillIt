using BusinessLogic.Interfaces;
using SkillIT_Models.Data;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NotificationService: INotificationService
    {
        private readonly ApplicationDbContext DbContext;

        public NotificationService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ObservableCollection<Notification> GetNotifications()
        {
            return new(DbContext.Notifications.OrderByDescending(n => n.DateCreated));
        }

        public ObservableCollection<Notification> GetAccountNotifications(long accountId)
        {
            return new(DbContext.Notifications.Where(n => n.AccountId == accountId).OrderByDescending(n => n.DateCreated));
        }

        public ObservableCollection<Notification> GetAccountUnreadNotifications(long accountId)
        {
            return new(DbContext.Notifications.Where(n => n.AccountId == accountId && n.MarkedAsRead == false).OrderByDescending(n => n.DateCreated));
        }

        public ObservableCollection<Notification> GetAccountReadNotifications(long accountId)
        {
            return new(DbContext.Notifications.Where(n => n.AccountId == accountId && n.MarkedAsRead == true).OrderByDescending(n => n.DateCreated));
        }

        public ObservableCollection<Notification> GetAccountNotificationsWithRange(long accountId, DateTime date1, DateTime date2)
        {
            return new(DbContext.Notifications.Where(n => n.AccountId == accountId).Where(n => n.DateCreated >= date1 && n.DateCreated <= date2).OrderByDescending(n => n.DateCreated));
        }

        public Notification GetAccountNotification(long accountId)
        {
            return DbContext.Notifications.FirstOrDefault(n => n.AccountId == accountId);
        }

        public Notification GetAccountNotificationyId(long notificationId)
        {
            return DbContext.Notifications.FirstOrDefault(n => n.NotificationId == notificationId);
        }

        public Notification GetAccountNotification(string notificationGuid)
        {
            return DbContext.Notifications.FirstOrDefault(n => n.NotificationGuid == notificationGuid);
        }

        public ResponseModel MarkAccountNotificationAsRead(long accountId)
        {
            DbContext.Notifications.Where(n => n.AccountId == accountId && n.MarkedAsRead == false).ToList().All(n => { n.MarkedAsRead = true; n.DateRead = DateTime.UtcNow; return true; });
            DbContext.SaveChanges();
            return new(true, "MarkedAllAsRead");
        }

    }
}
