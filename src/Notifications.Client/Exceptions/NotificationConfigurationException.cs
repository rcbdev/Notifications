using System;

namespace Notifications.Client.Exceptions
{
    public class NotificationConfigurationException : Exception
    {
        public NotificationConfigurationException(string message, Exception ex) :
            base(message, ex)
        {
        }
    }
}
