namespace Server.src
{
    public class ClientHandler
    {
        private readonly AuthService _authService;
        private readonly IDataBaseAdapter _dataBaseConnector;
        private readonly IOutputHandler _outputHandler;
        private int clientId;

        public ClientHandler(AuthService authService, IDataBaseAdapter dataBaseConnector, IOutputHandler outputHandler)
        {
            _authService = authService;
            _dataBaseConnector = dataBaseConnector;
            _outputHandler = outputHandler;
            clientId = 0;
        }

        public async Task HandleClientAsync(IClient client)
        {
            try
            {
                while (true)
                {
                    var clientName = _authService.ClientNameAuthorization(client);
                    var currentId = clientId;
                    if (_dataBaseConnector.AddClient(clientName, client, currentId))
                    {
                        _outputHandler.ClientAddedToDataBase(clientName, currentId);
                    }
                    else
                    {
                        var clientData = _dataBaseConnector.GetClient(clientName);
                        if (clientData is not null)
                        {
                            if (clientData.GetPassword() is not null)
                            {
                                var password = _authService.ClientPasswordAuthorization(client);
                                if (password is not null && password == clientData.GetPassword())
                                {
                                    _outputHandler.ClientAddedToDataBase(clientName, currentId, password);
                                    clientId++;
                                    return;
                                }
                                else
                                {
                                    _outputHandler.ClientIsNoInDataBase(clientName, currentId);
                                    return;
                                }
                            }
                        }



                    }
                    _outputHandler.ClientIsAlreadyInDataBase(clientName, currentId);
                    return;
                }
            }
            catch (Exception ex)
            {
                _outputHandler.HandleClientError(ex);
            }
        }
    }
}