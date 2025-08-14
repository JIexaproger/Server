using System.Collections.Concurrent;

namespace Server.src
{
    public class Server
    {
        public string _ip { get; private set; }
        public int _port { get; private set; }
        public bool _isRunning { get; private set; }
        // public IDataBaseAdapter _clients { get; private set; }
        private readonly ServerManager _serverManager;


        public Server(string ip, int port, IListener listener, IDataBaseAdapter dataBaseAdapter, IOutputHandler outputHandler)
        {
            _ip = ip;
            _port = port;
            _isRunning = false;

            _serverManager = new ServerManager(
                listener,
                new ClientAcceptor(listener, new ClientHandler(new AuthService(), dataBaseAdapter, outputHandler), outputHandler),
                outputHandler);
        }


        public void Start()
        {
            _isRunning = true;
            _serverManager.StartServer();
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}