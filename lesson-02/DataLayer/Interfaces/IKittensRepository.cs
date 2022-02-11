
namespace DataLayer.Interfaces
{
    public interface IKittensRepository
    {
        public Responses.GetKittensResponse GetKittens();

        public Models.KittenModel GetKittenById(int id);

        public bool SaveKitten(Requests.SaveKittenRequest request);
    }
}
