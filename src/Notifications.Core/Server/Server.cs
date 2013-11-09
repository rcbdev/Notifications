using System;
using System.Collections.Generic;

namespace Notifications.Core.Server
{
    class Server : IDisposable
    {
        private List<IDisposable> _servers;
 
        public Server()
        {
            _servers = new List<IDisposable>();
        }

        public void AddServer(IDisposable server)
        {
            _servers.Add(server);
        }

        public void Dispose()
        {
            foreach (var server in _servers)
            {
                server.Dispose();
            }
            _servers = new List<IDisposable>();
        }
    }
}
