using Notifications.Sender.Configuration;
using Notifications.Sender.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Sender
{
    public class NotificationSender
    {
        public enum NotificationType
        {
            Info,
            Success,
            Warning,
            Error
        };

        private static string _host;
        private static string _port;

        private static string Host
        {
            get
            {
                InitConfig();
                return _host;
            }
        }

        private static string Port
        {
            get
            {
                InitConfig();
                return _port;
            }
        }

        private static void InitConfig()
        {
            if (_host == null && _port == null)
            {
                SenderConfigurationSection config;
                try
                {
                    config = (SenderConfigurationSection)System.Configuration.ConfigurationManager.GetSection("notificationHub");
                }
                catch(Exception ex)
                {
                    throw new NotificationConfigurationException("Configuration section could not be found", ex);
                }
                _host = config.Host;
                _port = config.Port;
            }
        }

        private static string GetNotificationType(NotificationType type)
        {
            switch (type)
            {
                case NotificationType.Info:
                    return "info";
                case NotificationType.Success:
                    return "success";
                case NotificationType.Warning:
                    return "warning";
                case NotificationType.Error:
                    return "error";
            }
            return "";
        }

        public static void SendNotification(string message, string title, NotificationType type = NotificationType.Info, string notificationUrl = "")
        {
            var url = string.Format("http://{0}:{1}/api/notification", Host, Port);
            var uri = new Uri(url);

            using (var webClient = new WebClient())
            {
                webClient.Credentials = CredentialCache.DefaultNetworkCredentials;
                webClient.UploadValuesAsync(uri, "POST", new NameValueCollection{
                    {"message", message},
                    {"title", title},
                    {"type", GetNotificationType(type)},
                    {"url", notificationUrl}
                });
            }
        }
    }
}
