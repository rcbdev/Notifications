using Microsoft.AspNet.SignalR;
using Notifications.Core.Models;
using System;
using System.Collections.Generic;

namespace Notifications.Core.Hubs
{
    public class NotificationHub : Hub
    {
        private static Subscriptions _subscriptions = new Subscriptions();

        internal static void SendNotification(NotificationMessage message)
        {
            message.SetDefaults();

            var hub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

            if (message.SendTo.Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                hub.Clients.All.showMessage(message.Message, message.Title, message.Type, message.Url);
            }
            else if (_subscriptions.HasGroup(message.SendTo))
            {
                foreach (var user in _subscriptions[message.SendTo])
                {
                    hub.Clients.User(user).showMessage(message.Message, message.Title, message.Type, message.Url);
                }
            }
            else
            {
                hub.Clients.User(message.SendTo).showMessage(message.Message, message.Title, message.Type, message.Url);
            }
        }

        public void SubscribeTo(string group)
        {
            _subscriptions.Add(group, Context.User.Identity.Name);
        }
    }
}
