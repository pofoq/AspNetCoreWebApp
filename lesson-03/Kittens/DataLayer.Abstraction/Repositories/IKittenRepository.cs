using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Abstraction.Entities;

namespace DataLayer.Abstraction.Repositories
{
    public interface IKittenRepository
    {
        Task<Kitten> AddKittenAsync(Kitten request);

        Task<IEnumerable<Kitten>> GetKittenAsync(string search, int page, int size);

        Task<Kitten> GetKittenAsync(int id);

        Task DeleteKittenAsync(int id);
        Task UpdateKittenAsync(Kitten kitten);
    }
}
