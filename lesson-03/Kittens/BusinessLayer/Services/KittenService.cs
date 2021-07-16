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

        public async Task<KittenDto> AddKittenAsync(KittenDto kitten)
        {
            return MapKitten(await _repository.AddKittenAsync(MapKitten(kitten)));
        }

        public Task DeleteKittenAsync(int id)
        {
            return _repository.DeleteKittenAsync(id);
        }

        public async Task<KittenDto> GetKittenByIdAsync(int id)
        {
            var kitten = await _repository.GetKittenAsync(id);
            return MapKitten(kitten);
        }

        public async Task<IEnumerable<KittenDto>> GetKittensAsync(string search, int page, int size)
        {
            var result = await _repository.GetKittenAsync(search, page, size);
            return result.Select(k => MapKitten(k)).ToArray();
        }

        public async Task UpdateKittenAsync(KittenDto kitten)
        {
            await _repository.UpdateKittenAsync(MapKitten(kitten));
        }

        private Kitten MapKitten(KittenDto kitten)
        {
            return new Kitten
            {
                Color = kitten.Color,
                Feed = kitten.Feed,
                HasCirtificate = kitten.HasCirtificate,
                Id = kitten.Id,
                NickName = kitten.NickName,
                Weight = kitten.Weight
            };
        }

        private KittenDto MapKitten(Kitten kitten)
        {
            return new KittenDto
            {
                Color = kitten.Color,
                Feed = kitten.Feed,
                HasCirtificate = kitten.HasCirtificate,
                Id = kitten.Id,
                NickName = kitten.NickName,
                Weight = kitten.Weight
            };
        }
    }
}
