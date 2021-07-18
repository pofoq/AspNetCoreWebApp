using DataLayer.Abstraction.Entities;
using DataLayer.Abstraction.Repositories;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private ApplicationDataContext _context;

        public ClinicRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public async Task<Clinic> AddAsync(Clinic clinic)
        {
                await _context.Clinics.AddAsync(clinic);
                await _context.SaveChangesAsync();
                return clinic;
        }

        public async Task DeleteAsync(int id)
        {
            var clinic = await _context.Clinics.FirstOrDefaultAsync(k => k.Id == id);
            if (clinic != null)
            {
                _context.Clinics.Remove(clinic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Clinic>> GetAsync(string search, int page, int size)
        {
            search = search is null ? "" : search;
            page = page - 1 < 0 ? 0 : page - 1;

            return await _context.Clinics
                .AsNoTracking()
                .Where(k => k.Name.ToLower().Contains(search.ToLower()))
                .Skip(page * size)
                .Take(size)
                .ToArrayAsync();
        }

        public async Task<Clinic> GetAsync(int id)
        {
            return await _context.Clinics
                .AsNoTracking()
                .Where(k => k.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Clinic clinic)
        {
            _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();
        }
    }
}
