using Microsoft.AspNetCore.Mvc;

namespace tenantApi.Controllers.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        [Route("serverStatusAlive")]
        public bool serverStatusAlive()
        {
            return true;
        }
    }
}
