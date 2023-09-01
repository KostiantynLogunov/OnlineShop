using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Library.Common.Interfaces;
using OnlineShop.Library.Common.Repos;
using OnlineShop.Library.GoodsService.Models;

namespace OnlineShop.OrdersService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrderedGoodsController : RepoControllerBase<OrderedGoods>
    {
        public OrderedGoodsController(IRepo<OrderedGoods> ordersRepo, ILogger<OrderedGoodsController> logger) : base(ordersRepo, logger)
        { }

        protected override void UpdateProperties(OrderedGoods source, OrderedGoods destination)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;

            if (destination.Price != source.Price)
            {
                destination.PriceListName = "Manualy assigned";
            }

            destination.Price = source.Price;
            destination.Quantity = source.Quantity;
        }
    }
}
