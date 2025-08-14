namespace Server.src
{
    public interface IClient : IDisposable
    {
        public bool GetConnectionStatus();
        public Task Write(string message);
        public Task<string?> Read();
    }
}