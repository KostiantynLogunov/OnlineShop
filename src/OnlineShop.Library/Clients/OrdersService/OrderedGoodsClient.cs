using Microsoft.Extensions.Options;
using OnlineShop.Library.GoodsService.Models;
using OnlineShop.Library.Options;

namespace OnlineShop.Library.Clients.OrdersService
{
    public class OrderedGoodsClient : RepoClientBase<OrderedGoods>
    {
        public OrderedGoodsClient(HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options)
        { }

        protected override void InitializeClient(IOptions<ServiceAdressOptions> options)
        {
            HttpClient.BaseAddress = new Uri(options.Value.OrdersService);
        }

        protected override void SetControllerName()
        {
            ControllerName = "OrderedGoods";
        }
    }
}
