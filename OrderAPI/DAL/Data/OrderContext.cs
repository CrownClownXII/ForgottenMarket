using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderAPI.DAL.Model;

namespace OrderAPI.DAL.Data
{
    public class OrderContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) 
            : base(options)
        {
              this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseHiLo();
            base.OnModelCreating(modelBuilder);
        }
    }
}