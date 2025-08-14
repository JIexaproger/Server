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
        public void ClientConnected();
        public void ClientDisconnected();

        public void HandleClientError(Exception error);
    }
}