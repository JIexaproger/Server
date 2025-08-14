namespace Server.src.release
{
    public class ConsoleOutput : IOutputHandler
    {
        public void ServerStarted()
        {
            Console.WriteLine("Сервер запущен.");
        }
        public void ServerStartedError(Exception error)
        {
            Console.WriteLine($"При запуске сервера возникла ошибка: {error.Message}");
        }
        public void ServerStoped()
        {
            Console.WriteLine("Сервер остановлен.");
        }
        public void ServerStopedError(Exception error)
        {
            Console.WriteLine($"При остановке сервера возникла ошибка: {error.Message}");
        }

        public void AcceptClientConnection()
        {
            System.Console.WriteLine("Подключение клиента принято.");
        }
        public void AcceptClientConnectionError()
        {
            System.Console.WriteLine("Ошибка при принятии подключения клиента.");
        }

        public void ClientIsAlreadyInDataBase(string clientName, int id, string? password)
        {
            Console.WriteLine($"Клиент уже есть в базе данных: Name=\"{clientName}\", Id=\"{id}\", Info=\"{password}\"");
        }
        public void ClientIsNoInDataBase(string clientName, int id, string? password)
        {
            Console.WriteLine($"Клиента нет в базе данных: Name=\"{clientName}\", Id=\"{id}\", Info=\"{password}\"");
        }
        public void ClientAddedToDataBase(string clientName, int id, string? password)
        {
            Console.WriteLine($"Клиент добавлен в базу данных: Name=\"{clientName}\", Id=\"{id}\", Info=\"{password}\"");
        }
        public void ClientRemoveFromDataBase(string clientName, int id, string? password)
        {
            Console.WriteLine($"Клиент удалён из базы данных: Name=\"{clientName}\", Id=\"{id}\", Info=\"{password}\"");
        }

        public void ClientConnected(string clientName)
        {
            Console.WriteLine($"Клиент \"{clientName}\" подключился.");
        }
        public void ClientDisconnected(string clientName)
        {
            Console.WriteLine($"Клиент \"{clientName}\" отключился.");
        }
        public void ClientReconnected(string clientName)
        {
            Console.WriteLine($"Клиент \"{clientName}\" переподключился");
        }

        public void HandleClientError(Exception error)
        {
            Console.WriteLine($"Ошибка при обработке клиента: {error.Message}");
        }
    }
}