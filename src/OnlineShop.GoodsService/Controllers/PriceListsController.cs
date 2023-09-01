using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Library.Common.Interfaces;
using OnlineShop.Library.Common.Repos;
using OnlineShop.Library.GoodsService.Models;

namespace OnlineShop.GoodsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PriceListsController : RepoControllerBase<PriceList>
    {
        public PriceListsController(IRepo<PriceList> priceListsRepo, ILogger<PriceListsController> logger) : base(priceListsRepo, logger)
        { }

        protected override void UpdateProperties(PriceList source, PriceList destination)
        {
            destination.Price = source.Price;
            destination.Name = source.Name;
            destination.ValidFrom = source.ValidFrom;
            destination.ValidTo = source.ValidTo;
        }
    }
}
