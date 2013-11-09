using Notifications.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Client.Event
{
    public class NotificationEventArgs : EventArgs
    {
        public NotificationMessage Notification { get; set; }
    }
}
