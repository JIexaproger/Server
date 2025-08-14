using System.Net;
using System.Net.Sockets;

namespace Server.src.release
{
    public class TcpListenerAdapter : IListener
    {
        private TcpListener _tcpListener;

        public TcpListenerAdapter(string ipAddress, int port)
        {
            _tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
        }

        IClient IListener.AcceptClient()
        {
            return new TcpClientAdapter(_tcpListener.AcceptTcpClient());
        }

        void IListener.Start()
        {
            _tcpListener.Start();
        }

        void IListener.Stop()
        {
            _tcpListener.Stop();
        }
    }
}