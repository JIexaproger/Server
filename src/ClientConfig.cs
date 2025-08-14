namespace Server.src
{
    public class ClientConfig
    {
        private IClient? _client;
        private int _id;
        private string? _password;

        public IClient? GetIClient()
        {
            return _client;
        }
        public int GetId()
        {
            return _id;
        }
        public string? GetPassword()
        {
            return _password;
        }


        public ClientConfig(IClient client, int id, string? password = null)
        {
            _client = client;
            _id = id;
            _password = password;
        }

        public ClientConfig(int id, string? password = null)
        { 
            _id = id;
            _password = password;
        }
    }
}
