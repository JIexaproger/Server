using System.Net.Sockets;

namespace Server.src
{
    public class ClientAcceptor
    {
        private readonly IListener _listener;
        private readonly ClientHandler _clientHandler;
        private readonly IOutputHandler _outputHandler;

        public ClientAcceptor(IListener listener, ClientHandler clientHandler, IOutputHandler outputHandler)
        {
            _listener = listener;
            _clientHandler = clientHandler;
            _outputHandler = outputHandler;
        }


        public void StartAcceptClient()
        {
            try
            {
                while (true)
                {
                    var client = _listener.AcceptClient();
                    if (client != null)
                    {
                        _ = _clientHandler.HandleClientAsync(client);
                    }
                }
            }
            catch (SocketException) { }
            catch (Exception ex)
            {
                _outputHandler.ServerStartedError(ex);
            }
        }
    }
}