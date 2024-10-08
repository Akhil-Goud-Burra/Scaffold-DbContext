using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{

    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/{v:apiVersion}/employee")] //URL based Versioning

    public class EmployeeV1Controller : Controller
    {
        // https://localhost:7816/api/1.0/employee

        [HttpGet("getemployeesGet1")]
        [ResponseCache(CacheProfileName= "Default30")]
        public IActionResult Get1()
        {
            return new OkObjectResult("employees from v11 controller");
        }
    }
}
