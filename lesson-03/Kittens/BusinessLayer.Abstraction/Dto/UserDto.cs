
namespace BusinessLayer.Abstraction.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}
