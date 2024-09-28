using crud.Models;
using crud.Models.EmoloyeeModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    [Route("api/employeeapi/")]
    [ApiController]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]


    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class EmployeeModelController : Controller
    {
        private readonly MyDbContext appDbContext;

        public EmployeeModelController(MyDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        // Http Get Request
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeTable>> GetAllEmployees()
        {
            var All_Employees = appDbContext.EmployeeTables
                                    .Include(e => e.JobDescriptions) // This will include JobDescriptions in the query
                                    .ToList();

            if (All_Employees == null || !All_Employees.Any())
            {
                return NotFound(new { Message = "No employees found in the DataBase" });
            }

            return Ok(All_Employees);
        }





        [HttpPost]
        public ActionResult<EmployeeCreateDTO> CreateEmployee([FromBody] EmployeeCreateDTO Input)
        {
            try
            {
                EmployeeTable model = new()
                {
                    Firstname = Input.Firstname,
                    Lastname = Input.Lastname,
                };

                appDbContext.EmployeeTables.Add(model);
                appDbContext.SaveChanges();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while retrieving employees", Details = ex.Message });
            }
        }

        


        [HttpDelete]
        public IActionResult DeleteEmployee([FromBody] EmployeeDeleteDTO Input_Form_Data)
        {
            try
            {
                var employeeToBeDeleted = appDbContext.EmployeeTables.FirstOrDefault(u => u.Id == (Input_Form_Data.Id));

                appDbContext.EmployeeTables.Remove(employeeToBeDeleted);
                appDbContext.SaveChanges();

                return StatusCode(204, "Employee has been successfully deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Unknown Error: An error occurred while deleting employees", Details = ex.Message });
            }
        }





        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] EmployeeUpdateDTO Input_Form_Data)
        {
            try
            {
                var ExistingEmployee = appDbContext.EmployeeTables.Find(Input_Form_Data.Id);

                ExistingEmployee.Firstname = Input_Form_Data.Firstname;
                ExistingEmployee.Lastname = Input_Form_Data.Lastname;

                appDbContext.EmployeeTables.Update(ExistingEmployee);
                appDbContext.SaveChanges();

                return Ok(ExistingEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Unknown Error: An error occurred while Updating employees", Details = ex.Message });
            }
        }



    }
}
