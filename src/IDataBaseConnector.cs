namespace Server.src
{
    public interface IDataBaseAdapter
    {
        bool AddClient(string clientName, IClient client, int id, string? password = null);
        bool RemoveClient(string clientName);
        ClientConfig? GetClient(string clientName);
        bool UpdateClient(string clientName, IClient client, int id, string? password = null);
    }
}