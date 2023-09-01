using OnlineShop.Library.Common.Repos;
using OnlineShop.Library.Data;
using OnlineShop.Library.GoodsService.Models;

namespace OnlineShop.Library.GoodsService.Repo
{
    public class PriceListsRepo : BaseRepo<PriceList>
    {
        public PriceListsRepo(OrdersDbContext context) : base(context)
        {
            Table = Context.PriceLists;
        }
    }
}
