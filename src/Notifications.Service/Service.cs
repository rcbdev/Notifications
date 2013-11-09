using Notifications.Core.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Service
{
    public partial class Service : ServiceBase
    {
        private IDisposable _server;

        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _server = Startup.Start();
        }

        protected override void OnStop()
        {
            _server.Dispose();
        }
    }
}
