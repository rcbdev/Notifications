using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Client.Entities
{
    public class NotificationMessage
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
    }
}
