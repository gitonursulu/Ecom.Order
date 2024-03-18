using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Context
{
    public class SQLDbContext : DbContext
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Order entity için yapılandırma
            modelBuilder.Entity<Order.Domain.Models.Order>(entity =>
            {
                // Primary key tanımı
                entity.HasKey(e => e.Id);

                // OrderAddress değer nesnesi için yapılandırma
                entity.OwnsOne(o => o.OrderAddress, address =>
                {
                    address.WithOwner();

                    // Opsiyonel olarak, değer nesnesi için tablo ismi ve sütun isimleri belirleyebilirsiniz
                    address.Property(p => p.City).HasColumnName("City");
                    address.Property(p => p.PostCode).HasColumnName("PostCode");
                });
            });

        }

        public DbSet<Order.Domain.Models.Order> Orders { get; set; }
        public DbSet<Order.Domain.Models.OrderItem> OrderItems { get; set; }
    }
}
