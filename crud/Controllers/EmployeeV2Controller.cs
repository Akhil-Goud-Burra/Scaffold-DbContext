using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{

    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/employee")] //URL based Versioning

    public class EmployeeV2Controller : Controller
    {

        // https://localhost:7816/api/2.0/employee
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("employees from v2 controller");
        }

    }
}
