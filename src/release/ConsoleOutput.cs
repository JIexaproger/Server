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

        public void ClientIsAlreadyInDataBase(string name, int id, string? info)
        {
            Console.WriteLine($"Клиент уже есть в базе данных: Name=\"{name}\", Id=\"{id}\", Info=\"{info}\"");
        }
        public void ClientIsNoInDataBase(string name, int id, string? info)
        {
            Console.WriteLine($"Клиента нет в базе данных: Name=\"{name}\", Id=\"{id}\", Info=\"{info}\"");
        }
        public void ClientAddedToDataBase(string name, int id, string? info)
        {
            Console.WriteLine($"Клиент добавлен в базу данных: Name=\"{name}\", Id=\"{id}\", Info=\"{info}\"");
        }
        public void ClientRemoveFromDataBase(string name, int id, string? info)
        {
            Console.WriteLine($"Клиент удалён из базы данных: Name=\"{name}\", Id=\"{id}\", Info=\"{info}\"");
        }

        public void ClientConnected()
        {
            Console.WriteLine("Клиент подключился.");
        }
        public void ClientDisconnected()
        {
            Console.WriteLine("Клиент отключился.");
        }

        public void HandleClientError(Exception error)
        {
            Console.WriteLine($"Ошибка при обработке клиента: {error.Message}");
        }
    }
}