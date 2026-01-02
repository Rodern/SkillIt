using SkillIT_Models.Entities.Core;
using SkillIT_Models.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface INotificationService
    {
        Notification GetAccountNotification(long accountId);
        Notification GetAccountNotification(string notificationGuid);
        ObservableCollection<Notification> GetAccountNotifications(long accountId);
        ObservableCollection<Notification> GetAccountNotificationsWithRange(long accountId, DateTime date1, DateTime date2);
        Notification GetAccountNotificationyId(long notificationId);
        ObservableCollection<Notification> GetAccountReadNotifications(long accountId);
        ObservableCollection<Notification> GetAccountUnreadNotifications(long accountId);
        ObservableCollection<Notification> GetNotifications();
        ResponseModel MarkAccountNotificationAsRead(long accountId);
    }
}
