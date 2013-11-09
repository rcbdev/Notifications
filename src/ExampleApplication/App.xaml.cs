using Notifications.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ExampleApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NotificationListener _notificationListener;

        protected override void OnStartup(StartupEventArgs e)
        {
            _notificationListener = new NotificationListener();
            _notificationListener.OnNotification += _notificationListener_OnNotification;

            base.OnStartup(e);
        }

        private void _notificationListener_OnNotification(object source, Notifications.Client.Event.NotificationEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                var window = new NotificationToast(e.Notification.Message, e.Notification.Title, e.Notification.Type, e.Notification.Url);
                window.Show();
            }));
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notificationListener.Dispose();
            base.OnExit(e);
        }
    }
}
