using Microsoft.Extensions.Options;
using OnlineShop.Library.GoodsService.Models;
using OnlineShop.Library.Options;

namespace OnlineShop.Library.Clients.GoodsService
{
    public class PriceListsClient : RepoClientBase<PriceList>
    {
        public PriceListsClient(HttpClient client, IOptions<ServiceAdressOptions> options) : base(client, options)
        { }

        protected override void InitializeClient(IOptions<ServiceAdressOptions> options)
        {
            HttpClient.BaseAddress = new Uri(options.Value.GoodsService);
        }

        protected override void SetControllerName()
        {
            ControllerName = "PriceLists";
        }
    }
}
