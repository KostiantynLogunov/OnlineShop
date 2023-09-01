using Microsoft.EntityFrameworkCore;
using OnlineShop.Library.Common.Repos;
using OnlineShop.Library.Data;
using OnlineShop.Library.GoodsService.Models;

namespace OnlineShop.Library.GoodsService.Repo
{
    public class GoodsRepo : BaseRepo<Goods>
    {
        public GoodsRepo(OrdersDbContext context) : base(context)
        {
            Table = Context.Goods;
        }

        public override async Task<IEnumerable<Goods>> GetAllAsync() => 
            await Table.Include(nameof(Goods.PriceLists)).ToListAsync();

        public override async Task<Goods> GetOneAsync(Guid id) => 
            await Task.Run(() => Table.Include(nameof(Goods.PriceLists))
                    .FirstOrDefault(entity => entity.Id == id));
    }
}
