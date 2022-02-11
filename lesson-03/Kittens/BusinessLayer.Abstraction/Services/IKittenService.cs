using BusinessLayer.Abstraction.Dto;
using System.Threading.Tasks;

namespace BusinessLayer.Abstraction.Services
{
    public interface IKittenService : ICrudServiceBase<KittenDto>
    {
        Task AddClinicAsync(int catId, int clinicId);
        Task<KittenDto> GetKittenClinicAsync(int catId);
    }
}
