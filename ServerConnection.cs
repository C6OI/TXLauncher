using System.Net.NetworkInformation;

namespace TX_Launcher {
    class ServerConnection {
        string host = "play.scptx.tk";
        string stateServerPart = ":8080";
        ushort port = 5050;

        string listenHost = "localhost";
        ushort stateServerListenPort = 8081;
        ushort listenPort = 5051;

        public void Connect(string GamePath) {
            string gamePath = GamePath;
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
