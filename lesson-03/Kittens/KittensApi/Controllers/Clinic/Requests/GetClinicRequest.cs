
namespace KittensApi.Controllers.Clinic.Requests
{
    public class GetClinicRequest
    {
        public string Search { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }
    }
}
