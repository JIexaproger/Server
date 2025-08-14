using System.Threading.Tasks;

namespace Server.src
{
    public class ClientHandler
    {
        private readonly AuthService _authService;
        private readonly IDataBaseAdapter _dataBase;
        private readonly IOutputHandler _outputHandler;
        private int clientId;

        public ClientHandler(AuthService authService, IDataBaseAdapter dataBaseConnector, IOutputHandler outputHandler)
        {
            _authService = authService;
            _dataBase = dataBaseConnector;
            _outputHandler = outputHandler;
            clientId = 0;
        }

        public async Task HandleClientAsync(IClient client)
        {

        }


        private async Task<string> RegisterClient(IClient client)
        {
            var clientName = await _authService.ClientNameAuthorizationAsync(client);
            var clientData = _dataBase.GetClient(clientName);

            if (clientData == null)
            {
                return RegisterNewClientAsync(client, clientName);
            }

            return await HandleExistingClientAsync(client, clientName, clientData);
        }

        private string RegisterNewClientAsync(IClient client, string clientName)
        {
            var currentId = clientId;
            _dataBase.AddClient(clientName, client, currentId);
            _outputHandler.ClientAddedToDataBase(clientName, currentId);
            clientId++;
            return clientName;
        }

        private async Task<string> HandleExistingClientAsync(IClient client, string clientName, ClientConfig clientData)
        {
            if (clientData.GetIClient() == null)
            {
                _outputHandler.ClientReconnected(clientName, clientData.GetId());
                _dataBase.UpdateClient(clientName, client, clientData.GetId(), clientData.GetPassword());
                return clientName;
            }
            var clientPassword = await _authService.ClientPasswordAuthorizationAsync(client);

        }
    }
}
