using System;

namespace DataLayer.Abstraction.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public string RefreshToken { get; set; }

        public DateTime Expires { get; set; }
    }
}
