using DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Tikect> tbl_ticket { set; get; }
        public async Task<T> InsertartDb<T>(T entidad)
        {
            try
            {

                Add(entidad);
                await SaveChangesAsync();
                return entidad;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
        public async Task<T> UdateDB<T>(T entidad)
        {
            try
            {
                Update(entidad);
                await SaveChangesAsync();
                return entidad;

            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
        public async Task<T> PachtDB<T>(T entidad)
        {
            try
            {
                Entry(entidad).State = EntityState.Modified;
                await SaveChangesAsync();
                return entidad;

            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
        public async Task<T> Delette<T>(T entidad)
        {
            try
            {
                Remove(entidad);
                await SaveChangesAsync();
                return entidad;

            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.UseCollation("utf8_bin");
            modelBuilder.HasCharSet("utf8");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }


    }
}
