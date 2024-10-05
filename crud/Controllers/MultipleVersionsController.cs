using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    [ApiController]
    [Route("api/MultipleVersions")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]

    public class MultipleVersionsController : Controller
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult GetV1()
        {
            return new OkObjectResult("employees from v1 Method");
        }



        [HttpGet]
        [MapToApiVersion("2.0")]
        public IActionResult GetV2()
        {
            return new OkObjectResult("employees from v2 Method");
        }
    }
}
