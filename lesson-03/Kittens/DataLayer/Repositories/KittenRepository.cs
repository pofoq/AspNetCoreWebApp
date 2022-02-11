using DataLayer.Abstraction.Entities;
using DataLayer.Abstraction.Repositories;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class KittenRepository : IKittenRepository
    {
        private ApplicationDataContext _context;

        public KittenRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Kitten> AddKittenAsync(Kitten kitten)
        {
                await _context.Kittens.AddAsync(kitten);
                await _context.SaveChangesAsync();
                return kitten;
        }

        public async Task DeleteKittenAsync(int id)
        {
            var kitten = await _context.Kittens.FirstOrDefaultAsync(k => k.Id == id);
            if (kitten != null)
            {
                _context.Kittens.Remove(kitten);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Kitten>> GetKittenAsync(string search, int page, int size)
        {
            search = search is null ? "" : search;

            return await _context.Kittens
                .AsNoTracking()
                .Where(k => k.NickName.ToLower().Contains(search.ToLower()))
                .Skip(page * size)
                .Take(size)
                .ToArrayAsync();
        }

        public async Task<Kitten> GetKittenAsync(int id)
        {
            return await _context.Kittens
                .AsNoTracking()
                .Where(k => k.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateKittenAsync(Kitten kitten)
        {
            _context.Kittens.Update(kitten);
            await _context.SaveChangesAsync();
        }
    }
}
