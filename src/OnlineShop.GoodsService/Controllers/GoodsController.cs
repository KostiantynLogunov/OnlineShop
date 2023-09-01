using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Library.Common.Interfaces;
using OnlineShop.Library.Common.Repos;
using OnlineShop.Library.GoodsService.Models;

namespace OnlineShop.GoodsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class GoodsController : RepoControllerBase<Goods>
    {
        public GoodsController(IRepo<Goods> articlesRepo, ILogger<GoodsController> logger) : base(articlesRepo, logger)
        { }

        protected override void UpdateProperties(Goods source, Goods destination)
        {
            destination.Name = source.Name;
            destination.Description = source.Description;
        }
    }
}
