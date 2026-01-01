using System;
using System.Collections.Generic;

#nullable disable

namespace SkillIT_Models.DatabaseModels
{
    public partial class Notification
    {
        public long NotificationId { get; set; }
        public string NotificationGuid { get; set; }
        public long AccountId { get; set; }
        public string Caption { get; set; }
        public string Details { get; set; }
        public string Actions { get; set; }
        public string Icon { get; set; }
        public bool MarkedAsRead { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateRead { get; set; }

        public virtual Account Account { get; set; }
    }
}
