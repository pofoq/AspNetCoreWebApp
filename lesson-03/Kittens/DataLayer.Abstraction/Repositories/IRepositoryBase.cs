using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Abstraction.Repositories
{
    public interface IRepositoryBase<TModel>
    {
        Task<TModel> AddAsync(TModel request);

        Task<IEnumerable<TModel>> GetAsync(string search, int page, int size);

        Task<TModel> GetAsync(int id);

        Task DeleteAsync(int id);

        Task UpdateAsync(TModel kitten);
    }
}
