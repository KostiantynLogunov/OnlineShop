using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.UserManagmentService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous] // we don't need any auth here
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public string Check() => "service is online";
    }
}
