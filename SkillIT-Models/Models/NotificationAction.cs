using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_Models.Models
{
    public class NotificationAction
    {
        public NotificationAction()
        {

        }
        public NotificationAction(string name, string description, string command) {
            Name = name;
            Description = description;
            Command = command;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Command { get; set; }
    }
}
