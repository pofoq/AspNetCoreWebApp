using BusinessLayer.Abstraction.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Abstraction.Services
{
    public interface IKittenService
    {
        Task<KittenDto> AddKittenAsync(KittenDto kitten);

        Task<IEnumerable<KittenDto>> GetKittensAsync(string search, int page, int size);

        Task DeleteKittenAsync(int id);

        Task<KittenDto> GetKittenByIdAsync(int id);

        Task UpdateKittenAsync(KittenDto kitten);
    }
}
