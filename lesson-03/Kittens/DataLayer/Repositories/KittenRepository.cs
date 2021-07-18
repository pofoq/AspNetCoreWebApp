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

        public async Task<Kitten> AddAsync(Kitten kitten)
        {
                await _context.Kittens.AddAsync(kitten);
                await _context.SaveChangesAsync();
                return kitten;
        }

        public async Task AddClinicAsync(int catId, int clinicId)
        {
            var cat = await _context.Kittens.SingleOrDefaultAsync(k => k.Id == catId);
            var clinic = await _context.Clinics.SingleOrDefaultAsync(c => c.Id == clinicId);
            if (clinic != null)
            {
                cat.Clinics.Add(clinic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var kitten = await _context.Kittens.FirstOrDefaultAsync(k => k.Id == id);
            if (kitten != null)
            {
                _context.Kittens.Remove(kitten);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Kitten>> GetAsync(string search, int page, int size)
        {
            search = search is null ? "" : search;
            page = page - 1 < 0 ? 0 : page - 1;

            return await _context.Kittens
                .Where(k => k.NickName.ToLower().Contains(search.ToLower()))
                .Skip(page * size)
                .Take(size)
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<Kitten> GetAsync(int id)
        {
            return await _context.Kittens
                .Where(k => k.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Kitten> GetKittenClinicAsync(int catId)
        {
            var cat = await _context.Kittens.AsNoTracking().Include(k => k.Clinics).SingleOrDefaultAsync(k => k.Id == catId);
            return cat;
        }

        public async Task UpdateAsync(Kitten kitten)
        {
            _context.Kittens.Update(kitten);
            await _context.SaveChangesAsync();
        }
    }
}
