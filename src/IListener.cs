namespace Server.src
{
    public interface IListener
    {
        public void Start();
        public void Stop();
        public IClient AcceptClient();
    }
}