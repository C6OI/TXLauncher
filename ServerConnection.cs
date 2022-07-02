using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace TXLauncher {
    internal class ServerConnection {
        private Launcher Launcher = new();

        public string gamePath { get; set; }

        private readonly string host = "play.scptx.tk";
        private readonly string stateServerPart = ":8080";
        private readonly ushort port = 5050;

        private readonly string listenHost = "localhost";
        private readonly ushort stateServerListenPort = 8081;
        private readonly ushort listenPort = 5051;

        private Process gameProcess;
        private Socket serverConnection;
        private Socket clientConnection;

        private ushort failedAttempts;
        private ushort retryTimeout;
        private DateTime connectionTime;

        private byte[] initialChunks = null;
        private byte[] _buffer;
        private int _countOfBytes;

        private ConnectionState state = ConnectionState.DISCONNECTED;

        void setState(ConnectionState newState) {
            state = newState;
        }

        void BufferServerData(byte[] buffer) {
            Launcher.ConsoleLabelOutput("got data from server");

            string isOverloaded = Encoding.UTF8.GetString(buffer);

            if (isOverloaded == "OVERLOADED") {
                Launcher.ConsoleLabelOutput("server overloaded");

                setState(ConnectionState.DISCONNECTED);
                serverConnection.Close();
            } else {
                if (state != ConnectionState.CONNECTED_TO_SERVER) {
                    connectionTime = DateTime.Now;
                }

                setState(ConnectionState.CONNECTED_TO_SERVER);

                if (gamePath == "") {
                    MessageBox.Show("Укажите путь до файла игры");
                } else if (!gamePath.Trim().ToLower().EndsWith("tankix.exe")) {
                    MessageBox.Show("Укажите файл с названием \"tankix.exe\"");
                } else {
                    gameProcess ??= Process.Start(gamePath);
                }

                if (DateTime.Now > connectionTime) {
                    Launcher.ConsoleLabelOutput("connection timed out");
                    serverConnection.Close();
                }
                failedAttempts = 0;
            }

            initialChunks ??= new byte[] { };
            Array.Copy(buffer, initialChunks, initialChunks.Length + buffer.Length);
        }

        void ConnectToServer() {
            _buffer = new byte[_countOfBytes];

            IPEndPoint server = new(IPAddress.Parse(host), port);

            Socket proxyToServer = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            proxyToServer.Connect(server);

            while (!proxyToServer.Connected) {
                Launcher.ConsoleLabelOutput("connecting to server...");
                Task.Delay(1000);
            }

            Launcher.ConsoleLabelOutput("connected to server");
            serverConnection = proxyToServer;
            setState(ConnectionState.WAITING_FOR_DATA);

            connectionTime = DateTime.Now;
            NetworkStream Stream = new(proxyToServer);
            Stream.BeginRead(_buffer, 0, _countOfBytes, ReceiveCallback, null);
        }

        void ReceiveCallback(IAsyncResult result) {
            BufferServerData(_buffer);
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
