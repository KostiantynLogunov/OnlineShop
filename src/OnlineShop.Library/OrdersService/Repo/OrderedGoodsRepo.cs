using OnlineShop.Library.Common.Repos;
using OnlineShop.Library.Data;
using OnlineShop.Library.GoodsService.Models;

namespace OnlineShop.Library.OrdersService.Repo
{
    public class OrderedGoodsRepo : BaseRepo<OrderedGoods>
    {
        public OrderedGoodsRepo(OrdersDbContext context) : base(context)
        {
            Table = Context.OrderedGoods;
        }
    }
}
