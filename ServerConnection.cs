using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace TX_Launcher {
    internal class ServerConnection {
        private readonly string host = "play.scptx.tk";
        private readonly string stateServerPart = ":8080";
        private readonly ushort port = 5050;
        
        private readonly string listenHost = "localhost";
        private readonly ushort stateServerListenPort = 8081;
        private readonly ushort listenPort = 5051;
        
        private Process gameProcess;
        
        private ushort failedAttempts;
        private readonly ushort retryTimeout;
        private uint connectionTime;
        
        private Socket serverConnection;
        private Socket clientConnection;

        private Buffer initialChunks;

        public void Connect(string GamePath) {
            string gamePath = GamePath + @"\tankix.exe";
        }
    }

    public static class CheckNetwork {
        public static bool CheckNetworkAvailable() {
            var ping = new Ping();
            string host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            var options = new PingOptions();

            try {
                var reply = ping.Send(host, timeout, buffer, options);
                return reply.Status == IPStatus.Success;
            }
            catch (PingException) {
                return false;
            }
        }
    }
}
