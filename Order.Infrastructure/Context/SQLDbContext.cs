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

        public DbSet<Order.Domain.Models.Order> Orders { get; set; }
        public DbSet<Order.Domain.Models.OrderItem> OrderItems { get; set; }
    }
}
