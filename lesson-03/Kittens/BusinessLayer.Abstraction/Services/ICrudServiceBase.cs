using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Abstraction.Services
{
    public interface ICrudServiceBase<TDto>
    {
        Task<TDto> AddAsync(TDto dto);

        Task<IEnumerable<TDto>> GetAsync(string search, int page, int size);

        Task<TDto> GetByIdAsync(int id);

        Task UpdateAsync(TDto dto);

        Task DeleteAsync(int id);
    }
}
