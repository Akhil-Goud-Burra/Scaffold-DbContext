using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{

    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/employee")]

    public class EmployeeV2Controller : Controller
    {

        // https://localhost:7816/api/employee?api-version=2.0
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("employees from v2 controller");
        }

    }
}
