using System.Collections.Concurrent;

namespace Server.src.release
{
    public class ClientDataBase : IDataBaseAdapter
    {
        private ConcurrentDictionary<string, ClientConfig> _clients;

        public ClientDataBase()
        {
            _clients = new ConcurrentDictionary<string, ClientConfig>();
        }

        public bool AddClient(string clientName, IClient client, int id, string? password = null)
        {
            return _clients.TryAdd(clientName, new ClientConfig(client, id, password));
        }
        public bool RemoveClient(string clientName)
        {
            return _clients.TryRemove(clientName, out _);
        }

        public ClientConfig? GetClient(string clientName)
        {
            _clients.TryGetValue(clientName, out var clientConfig);
            return clientConfig;
        }

        public bool UpdateClient(string clientName, IClient client, int id, string? password = null)
        {
            if (_clients.ContainsKey(clientName))
            {
                _clients[clientName] = new ClientConfig(client, id, password);
                return true;
            }
            return false;
        }
    }
}