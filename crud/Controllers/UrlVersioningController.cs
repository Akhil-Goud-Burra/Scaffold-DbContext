using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    
    [ApiController]
    [Route("api/v{v:apiVersion}/UrlVersioning")] //URL based Versioning with Swagger
    [ApiVersion("1.0")]
    public class UrlVersioningController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("employees from v1 controller");
        }
    }
}
