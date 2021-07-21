
namespace BusinessLayer.Abstraction.Dto
{
    public sealed class TokenResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
