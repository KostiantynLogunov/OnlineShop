using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Library.Common.Interfaces;
using OnlineShop.Library.Common.Repos;
using OnlineShop.Library.OrdersService.Model;

namespace OnlineShop.OrdersService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController : RepoControllerBase<Order>
    {
        public OrdersController(IRepo<Order> ordersRepo, ILogger<OrdersController> logger) : base(ordersRepo, logger)
        { }

        protected override void UpdateProperties(Order source, Order destination)
        {
            destination.AddressId = source.AddressId;
            destination.UserId = source.UserId;
            destination.Goods = source.Goods;
            destination.Modified = DateTime.UtcNow;
        }
    }
}
