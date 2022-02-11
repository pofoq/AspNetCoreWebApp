using DataLayer.Abstraction.Entities;
using System.Threading.Tasks;

namespace DataLayer.Abstraction.Repositories
{
    public interface IKittenRepository : IRepositoryBase<Kitten>
    {
        Task AddClinicAsync(int catId, int clinicId);
        Task<Kitten> GetKittenClinicAsync(int catId);
    }
}
