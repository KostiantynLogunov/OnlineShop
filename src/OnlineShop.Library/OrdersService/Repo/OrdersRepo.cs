using Microsoft.EntityFrameworkCore;
using OnlineShop.Library.Common.Interfaces;
using OnlineShop.Library.Common.Repos;
using OnlineShop.Library.Data;
using OnlineShop.Library.GoodsService.Models;
using OnlineShop.Library.OrdersService.Model;

namespace OnlineShop.Library.OrdersService.Repo
{
    public class OrdersRepo : BaseRepo<Order>
    {
        private readonly IRepo<OrderedGoods> _orderedGoodsRepo;

        public OrdersRepo(IRepo<OrderedGoods> orderedGoodsRepo, OrdersDbContext context) : base(context)
        {
            _orderedGoodsRepo = orderedGoodsRepo;
            Table = Context.Orders;
        }

        public override async Task<IEnumerable<Order>> GetAllAsync() => 
            await Table.Include(nameof(Order.Goods)).ToListAsync();

        public override async Task<Order> GetOneAsync(Guid id) => 
            await Task.Run(() => Table.Include(nameof(Order.Goods)).FirstOrDefault(entity => entity.Id == id));
    }
}
