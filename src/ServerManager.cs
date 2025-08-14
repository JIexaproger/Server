namespace Server.src
{
    public class ServerManager
    {
        private readonly IListener _listener;
        private readonly ClientAcceptor _clientAcceptor;
        private readonly IOutputHandler _outputHandler;

        public ServerManager(IListener listener, ClientAcceptor clientAcceptor, IOutputHandler outputHandler)
        {
            _listener = listener;
            _clientAcceptor = clientAcceptor;
            _outputHandler = outputHandler;
        }

        public void StartServer()
        {
            try
            {
                _listener.Start();
                _clientAcceptor.StartAcceptClient();
                _outputHandler.ServerStarted();
            }
            catch (Exception ex)
            {
                _outputHandler.ServerStartedError(ex);
            }
        }

        public void StopServer()
        {
            try
            {
                _listener.Stop();
                _outputHandler.ServerStoped();
            }
            catch (Exception ex)
            {
                _outputHandler.ServerStopedError(ex);
            }
        }
    }
}