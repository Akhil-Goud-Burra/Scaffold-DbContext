using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/employee")]

    public class EmployeeV1Controller : Controller
    {

        // https://localhost:7816/api/employee?api-version=1.0

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("employees from v1 controller");
        }
    }
}
