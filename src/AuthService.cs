namespace Server.src
{
    public class AuthService
    {
        private readonly int _minNameLength;
        private readonly int _maxNameLength;
        private readonly int _minPasswordLength;
        private readonly int _maxPasswordLength;
        private readonly int _passwordAttempts;


        public AuthService(int minNameLength = 3, int maxNameLength = 64, int minPasswordLength = 0, int maxPasswordLength = 128, int passwordAttempts = 2)
        {
            _minNameLength = minNameLength;
            _maxNameLength = maxNameLength;
            _minPasswordLength = minPasswordLength;
            _maxPasswordLength = maxPasswordLength;
            _passwordAttempts = passwordAttempts;
        }


        public string ClientNameAuthorization(IClient client)
        {
            while (true)
            {
                var name = GetClientInput(client);
                if (IsValidName(name))
                {
                    return name;
                }
            }
        }
        public string? ClientPasswordAuthorization(IClient client)
        {
            for (int attempt = 0; attempt < _passwordAttempts; attempt++)
            {
                var password = GetClientInput(client);
                if (IsValidPassword(password))
                {
                    return password;
                }
            }
            return null;
        }


        private string GetClientInput(IClient client)
        {
            while (true)
            {
                var name = client.Read().Result;
                if (!string.IsNullOrEmpty(name))
                {
                    return name;
                }
            }
        }

        public bool IsValidName(string name)
        {
            name = FixWhitespaceInString(name);

            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            if (name.Length < _minNameLength || name.Length > _maxNameLength)
            {
                return false;
            }

            return true;
        }        
        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            else if (password.Length < _minPasswordLength || password.Length > _maxPasswordLength)
            {
                return false;
            }
            return true;
        }

        private string FixWhitespaceInString(string str)
        {
            return string.Join(" ", str.Split([' '], StringSplitOptions.RemoveEmptyEntries));
        }
    }
}