using Microsoft.AspNet.SignalR.Client;
using Notifications.Client.Entities;
using Notifications.Client.Event;
using Notifications.Client.Exceptions;
using Notifications.Client.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Client
{
    public class NotificationListener : IDisposable
    {
        private readonly ClientConfigurationSection _configuration;
        private readonly HubConnection _hubConnection;
        private readonly IHubProxy _hubProxy;

        public event NotificationEventHandler OnNotification;

        public NotificationListener()
        {
            try
            {
                _configuration = (ClientConfigurationSection)ConfigurationManager.GetSection("notificationHub");
            }
            catch (Exception ex)
            {
                throw new NotificationConfigurationException("Configuration section could not be found", ex);
            }

            try
            {
                var url = string.Format("http://{0}:{1}/", _configuration.Host, _configuration.Port);
                _hubConnection = new HubConnection(url);
                _hubConnection.Credentials = CredentialCache.DefaultNetworkCredentials;
                _hubProxy = _hubConnection.CreateHubProxy("NotificationHub");
                _hubProxy.On<string, string, string, string>("showMessage", HandleMessage);
                _hubConnection.Start();
            }
            catch (Exception ex)
            {
                throw new NotificationGeneralException("Error establishing connection to notification hub", ex);
            }
        }

        private void HandleMessage(string message, string title, string type, string url)
        {
            var notificationMessage = new NotificationMessage
            {
                Message = message,
                Title = title,
                Type = type,
                Url = url
            };
            var eventArgs = new NotificationEventArgs
            {
                Notification = notificationMessage
            };

            OnNotification(this, eventArgs);
        }

        public void Dispose()
        {
            _hubConnection.Dispose();
        }

        public void SubscribeTo(string group)
        {
            _hubProxy.Invoke("SubscribeTo", new[] { group });
        }
    }
}
