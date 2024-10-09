using crud.Models;
using crud.Models.PaginationParams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace crud.Controllers
{
    [ApiController]
    [Route("api/PaginatedData")]
    public class PaginationController : Controller
    {

        private readonly MyDbContext appDbContext;

        public PaginationController(MyDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        // Http Get Request
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeTable>> GetAllEmployees([FromQuery] Pagination pagination)
        {
            var All_Employees = appDbContext.EmployeeTables
                                    .Include(e => e.JobDescriptions) // This will include JobDescriptions in the query
                                    .ToList();

            // Apply Pagination
            var pagedEmployees = All_Employees.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();


            if (pagedEmployees == null || !pagedEmployees.Any())
            {
                return NotFound(new { Message = "No employees found in the DataBase" });
            }

            return Ok(pagedEmployees);
        }
    }
}
