using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Sender.Exceptions
{
    public class NotificationConfigurationException : Exception
    {
        public NotificationConfigurationException(string message, Exception ex):
            base(message, ex)
        {
        }
    }
}
