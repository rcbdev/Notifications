using System.Configuration;

namespace Notifications.Sender.Configuration
{
    public class SenderConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("port", DefaultValue = "8080", IsRequired = false)]
        public string Port
        {
            get { return (string)this["port"]; }
            set { this["port"] = value; }
        }

        [ConfigurationProperty("host", DefaultValue = "localhost", IsRequired = false)]
        public string Host
        {
            get { return (string)this["host"]; }
            set { this["host"] = value; }
        }
    }
}
