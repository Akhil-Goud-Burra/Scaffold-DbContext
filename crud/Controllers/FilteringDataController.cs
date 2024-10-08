using crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    [ApiController]
    [Route("api/FilterData")]
    public class FilteringDataController : Controller
    {
        private readonly MyDbContext appDbContext;

        public FilteringDataController(MyDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        // Http Get Request
        [HttpGet("GetAllEmployees")]
        public ActionResult<IEnumerable<EmployeeTable>> GetAllEmployees([FromQuery]String? Firstname , [FromQuery] String? Lastname)
        {

            List<EmployeeTable> All_Employees;

            if (!string.IsNullOrEmpty(Firstname) || !string.IsNullOrEmpty(Lastname))
            {
                All_Employees = appDbContext.EmployeeTables
                                            .Where(x => x.Firstname == Firstname || x.Lastname == Lastname)
                                            .Include(e => e.JobDescriptions) // This will include JobDescriptions in the query
                                            .ToList();
            }
            else
            {
                All_Employees = appDbContext.EmployeeTables
                                            .Include(e => e.JobDescriptions) // This will include JobDescriptions in the query
                                            .ToList();
            }




            if (All_Employees == null || !All_Employees.Any())
            {
                return NotFound(new { Message = "No employees found in the DataBase" });
            }

            return Ok(All_Employees);
        }


    }
}
