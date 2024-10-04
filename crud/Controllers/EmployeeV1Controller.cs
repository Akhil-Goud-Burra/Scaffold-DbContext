using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/{v:apiVersion}/employee")] //URL based Versioning

    public class EmployeeV1Controller : Controller
    {

        // https://localhost:7816/api/1.0/employee

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("employees from v1 controller");
        }
    }
}
