using DataLayer.Abstraction.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {

        }

        public DbSet<Kitten> Kittens { get; set; }

        public DbSet<Clinic> Clinics { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Kitten>().Ignore(k => k.Clinics);
        //    builder.Entity<Clinic>().Ignore(c => c.Kittens);
        //}
    }
}
