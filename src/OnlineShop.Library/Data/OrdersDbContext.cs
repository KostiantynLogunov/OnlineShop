using Microsoft.EntityFrameworkCore;
using OnlineShop.Library.GoodsService.Models;
using OnlineShop.Library.OrdersService.Model;

namespace OnlineShop.Library.Data
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderedGoods>()
                .HasOne<Order>(e => e.Order)
                .WithMany(d => d.Goods)
                .HasForeignKey(e => e.OrderId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderedGoods> OrderedGoods { get; set; }
    }
}
