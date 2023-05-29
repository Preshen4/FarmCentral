namespace FarmCentral.Shared
{
    public sealed class UserLoginDto
    {
        private static readonly UserLoginDto instance = new UserLoginDto();
        static UserLoginDto()
        {
        }
        private UserLoginDto()
        {
        }
        public static UserLoginDto Instance
        {
            get
            {
                return instance;
            }
        }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public int ID { get; set; } = 0;
    }
}
