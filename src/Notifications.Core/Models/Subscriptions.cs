using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Core.Models
{
    class Subscriptions
    {
        private Dictionary<string, List<string>> _subscriptions = new Dictionary<string, List<string>>();

        public void Add(string group, string user)
        {
            if (!_subscriptions.ContainsKey(group))
            {
                _subscriptions.Add(group, new List<string>());
            }
            _subscriptions[group].Add(user);
        }

        public bool HasGroup(string group)
        {
            return _subscriptions.ContainsKey(group);
        }

        public List<string> this[string key]
        {
            get
            {
                return _subscriptions[key];
            }
        }
    }
}
