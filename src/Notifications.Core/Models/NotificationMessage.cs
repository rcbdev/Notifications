using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Core.Models
{
    public class NotificationMessage
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string SendTo { get; set; }

        internal void SetDefaults()
        {
            if (string.IsNullOrWhiteSpace(Type))
            {
                Type = "info";
            }
            if (string.IsNullOrWhiteSpace(SendTo))
            {
                SendTo = "all";
            }
            if (Url == null)
            {
                Url = "";
            }
        }
    }
}
