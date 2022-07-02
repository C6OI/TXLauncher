using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace TXLauncher {
    internal class ServerConnection {
        private Launcher Launcher;

        public string gamePath { get; set; }

        private readonly string host = "main.txrevive.com";
        private readonly string stateServerPart = ":8080";
        private readonly ushort port = 5050;

        private readonly string listenHost = "localhost";
        private readonly ushort stateServerListenPort = 8081;
        private readonly ushort listenPort = 5051;

        private Process gameProcess;
        private Socket serverConnection;
        private Socket clientConnection;

        private ushort failedAttempts;
        private ushort retryTimeout = 5000;
        private DateTime connectionTime;


        private List<byte> initialChunks = new();
        private byte[] _buffer;
        private int _countOfBytes = 66;

        private ConnectionState state = ConnectionState.DISCONNECTED;

        public ServerConnection(Launcher launcher) {
            Launcher = launcher;
        }

        void setState(ConnectionState newState) {
            state = newState;
        }

        void BufferServerData(List<byte> buffer) {
            Console.WriteLine("got data from server");

            string isOverloaded = Encoding.UTF8.GetString(buffer.ToArray());

            if (isOverloaded == "OVERLOADED") {
                Console.WriteLine("server overloaded");

                setState(ConnectionState.DISCONNECTED);
                serverConnection.Close();
            }
            else {
                if (state != ConnectionState.CONNECTED_TO_SERVER) {
                    connectionTime = DateTime.Now;
                }

                setState(ConnectionState.CONNECTED_TO_SERVER);

                /*if (gamePath == "") {
                    MessageBox.Show("Укажите путь до файла игры");
                } else if (!gamePath.Trim().ToLower().EndsWith("tankix.exe")) {
                    MessageBox.Show("Укажите файл с названием \"tankix.exe\"");
                } else {
                    gameProcess ??= Process.Start(gamePath);
                }*/

                if (DateTime.Now > connectionTime + ) {
                    Console.WriteLine("connection timed out");
                    serverConnection.Close();
                }
                failedAttempts = 0;
            }

            initialChunks?.Clear();
            initialChunks.AddRange(buffer);
        }

        void Reconnect() {
            if (failedAttempts != null) {
                ConnectToServer();
            }
            else {
                while (state != ConnectionState.WAITING_FOR_DATA) {
                    ConnectToServer();
                    Task.Delay(retryTimeout * 2);
                }
            }
        }

        public void ConnectToServer() {
            _buffer = new byte[_countOfBytes];

            var address = Dns.GetHostAddresses(host);

            IPEndPoint server = new(address[0], port);
            Socket proxyToServer = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            while (!proxyToServer.Connected) {
                Console.WriteLine("connecting to server...");
                proxyToServer.Connect(server);
                Task.Delay(1000);
            }

            NetworkStream Stream = new(proxyToServer);

            Console.WriteLine("connected to server");
            serverConnection = proxyToServer;
            setState(ConnectionState.WAITING_FOR_DATA);

            connectionTime = DateTime.Now;

            try {
                Stream.BeginRead(_buffer, 0, _countOfBytes, ReceiveCallback, null);
            }
            catch (SocketException) {
                if (state == ConnectionState.CONNECTED_TO_SERVER ||
                    state == ConnectionState.READY ||
                    state == ConnectionState.CLOSED_BY_CLIENT) {
                    Console.WriteLine("disconnected from server after " + (DateTime.Now - connectionTime));
                }
                else {
                    Console.WriteLine($"connection attempt {++failedAttempts} failed");
                }
                setState(state == ConnectionState.READY ?
                    ConnectionState.CLOSED_BY_SERVER :
                    ConnectionState.DISCONNECTED);

                serverConnection = null;
                initialChunks = null;
                clientConnection?.Close();

                Reconnect();
            }
        }

        void ReceiveCallback(IAsyncResult result) {
            BufferServerData(_buffer.ToList());
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
