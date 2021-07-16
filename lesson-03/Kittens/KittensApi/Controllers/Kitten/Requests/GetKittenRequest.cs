
namespace KittensApi.Controllers.Kitten.Requests
{
    public class GetKittenRequest
    {
        public string Serach { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }
    }
}
