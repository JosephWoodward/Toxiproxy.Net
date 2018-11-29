using System;
using System.Diagnostics;

namespace Toxiproxy.Net.Tests
{
    public class ToxiproxyTestsBase : IDisposable
    {
        protected Connection _connection;
        protected Process _process;

        protected readonly Proxy ProxyOne = new Proxy
        {
            Name = "one",
            Enabled = true,
            Listen = "127.0.0.1:11111",
            Upstream = "one.com"
        };

        protected readonly Proxy ProxyTwo = new Proxy {
            Name = "two",
            Enabled = true,
            Listen = "127.0.0.1:22222",
            Upstream = "two.com"
        };

        protected readonly Proxy ProxyThree = new Proxy {
            Name = "three",
            Enabled = true,
            Listen = "127.0.0.1:33333",
            Upstream = "three.com"
        };

        public ToxiproxyTestsBase() 
        {
            var processInfo = new ProcessStartInfo()
            {
                FileName = @"..\..\..\compiled\toxiproxy-server-2.1.3-windows-amd64.exe"
            };
            _process = new Process()
            {
                StartInfo = processInfo
            };
            _process.Start();
            
            _connection = new Connection();
        }

        public void Dispose()
        {
            if (_process.HasExited == false)
            {
                _process.Kill();
            }
        }
    }
}