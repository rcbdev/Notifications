using System.Collections.Generic;
using System.Web.Http;
using Notifications.Core.Hubs;
using Notifications.Core.Models;

namespace Notifications.Core.Api
{
    public class NotificationController : ApiController
    {
        public void PostNotification([FromBody] NotificationMessage notification)
        {
            NotificationHub.SendNotification(notification);
        }
    }
}
