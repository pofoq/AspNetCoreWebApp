using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstraction.Dto;
using BusinessLayer.Abstraction.Services;
using DataLayer.Abstraction.Entities;
using DataLayer.Abstraction.Repositories;


namespace BusinessLayer.Services
{
    public class KittenService : IKittenService
    {
        private IKittenRepository _repository;

        public KittenService(IKittenRepository repository)
        {
            _repository = repository;
        }

        public async Task<KittenDto> AddAsync(KittenDto kitten)
        {
            return Mapper.Map(await _repository.AddAsync(Mapper.Map(kitten)));
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<KittenDto> GetByIdAsync(int id)
        {
            var kitten = await _repository.GetAsync(id);
            return Mapper.Map(kitten);
        }

        public async Task<IEnumerable<KittenDto>> GetAsync(string search, int page, int size)
        {
            var result = await _repository.GetAsync(search, page, size);
            return result.Select(k => Mapper.Map(k)).ToArray();
        }

        public async Task UpdateAsync(KittenDto kitten)
        {
            await _repository.UpdateAsync(Mapper.Map(kitten));
        }

        public async Task AddClinicAsync(int catId, int clinicId)
        {
            await _repository.AddClinicAsync(catId, clinicId);
        }

        public async Task<KittenDto> GetKittenClinicAsync(int catId)
        {
            var kitten = await _repository.GetKittenClinicAsync(catId);
            return Mapper.Map(kitten);
        }
    }
}
