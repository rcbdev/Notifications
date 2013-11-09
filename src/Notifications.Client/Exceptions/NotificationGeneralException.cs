using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Client.Exceptions
{
    public class NotificationGeneralException : Exception
    {
        public NotificationGeneralException(string message, Exception ex) :
            base(message, ex)
        {
        }
    }
}
