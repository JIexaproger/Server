namespace Server.src
{
    public interface IOutputHandler
    {
        // Server events
        public void ServerStarted();
        public void ServerStartedError(Exception error);
        public void ServerStoped();
        public void ServerStopedError(Exception error);

        // Accept client events
        public void AcceptClientConnection();
        public void AcceptClientConnectionError();

        // DataBase events
        public void ClientAddedToDataBase(string clientName, int clientId, string? password = null);
        public void ClientIsAlreadyInDataBase(string clientName, int clientId, string? password = null);
        public void ClientRemoveFromDataBase(string clientName, int clientId, string? password = null);
        public void ClientIsNoInDataBase(string clientName, int clientId, string? password = null);

        // Client events
        public void ClientConnected(string clientName);
        public void ClientDisconnected(string clientName);
        public void ClientReconnected(string clientName);

        public void HandleClientError(Exception error);

        public void ClientPasswordIsIncorrect(string clientName);
        public void ClientPasswordIsCorrect(string clientName, string password);
    }
}