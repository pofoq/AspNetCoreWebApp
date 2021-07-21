

namespace BusinessLayer.Abstraction.Dto
{
    public class AuthResponse
    {
        public string Password { get; set; }

        public RefreshToken LatestRefreshToken { get; set; }
    }
}
