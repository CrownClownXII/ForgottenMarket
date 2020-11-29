using CatalogAPI.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.DAL.Data
{
    public class CatalogContext: DbContext
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options) 
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}