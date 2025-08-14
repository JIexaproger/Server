using System.Net.Sockets;

namespace Server.src.release
{
    public class TcpClientAdapter : IClient
    {
        private TcpClient _tcpClient;
        private NetworkStream _stream;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;

        public TcpClientAdapter(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
            _stream = tcpClient.GetStream();
            _streamReader = new StreamReader(_stream);
            _streamWriter = new StreamWriter(_stream) { AutoFlush = true };
        }

        public async Task<string?> Read()
        {
            return await _streamReader.ReadLineAsync();
        }

        public async Task Write(string message)
        {
            await _streamWriter.WriteLineAsync(message);
        }

        public bool GetConnectionStatus()
        {
            return _tcpClient.Connected;
        }

        public void Dispose()
        {
            _streamReader?.Dispose();
            _streamWriter?.Dispose();
            _stream?.Dispose();
            _tcpClient?.Dispose();
        }
    }
}