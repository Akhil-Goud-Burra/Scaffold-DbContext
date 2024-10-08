﻿using crud.Models;
using crud.Models.EmoloyeeModelDTO;
using crud.Models.JobDescriptionDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    [Route("api/jobdescriptionapi/")]
    [ApiController]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]


    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class JobDescriptionController : Controller
    {
        private readonly MyDbContext appDbContext;

        public JobDescriptionController(MyDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        // Http Get Request
        [HttpGet]
        public ActionResult<IEnumerable<JobDescription>> GetAllJobDescriptions()
        {

            var All_JobDescriptions = appDbContext.JobDescriptions.ToList();

            if (All_JobDescriptions == null || !All_JobDescriptions.Any())
            {
                return NotFound(new { Message = "No All_JobDescriptions found in the DataBase" });
            }

            return Ok(All_JobDescriptions);
        }


        [HttpPost]
        public ActionResult<JobDescriptionCreateDTO> CreateJobDescription([FromBody] JobDescriptionCreateDTO Input)
        {
            try
            {
                JobDescription model = new()
                {
                    JobTitle = Input.JobTitle,
                    StartDate = Input.StartDate,
                    EndDate = Input.EndDate,
                    EmployeeId = Input.EmployeeId
                };

                appDbContext.JobDescriptions.Add(model);
                appDbContext.SaveChanges();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred while retrieving JobDescriptions From DataBase", Details = ex.Message });
            }
        }




        // Deleting a Employee
        [HttpDelete]
        public IActionResult DeleteEmployee([FromBody] JobDescriptionDeleteDTO Input_Form_Data)
        {
            try
            {
                var employeeToBeDeleted = appDbContext.JobDescriptions.FirstOrDefault(u => u.JobDescriptionId == (Input_Form_Data.JobDescriptionId));


                appDbContext.JobDescriptions.Remove(employeeToBeDeleted);
                appDbContext.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Unknown Error: An error occurred while deleting JobDescriptions", Details = ex.Message });
            }
        }


        [HttpPut]
        public IActionResult UpdateJobDescription([FromBody] JobDescriptionUpdateDTO Input_Form_Data)
        {
            try
            {
                var ExistingEmployee = appDbContext.JobDescriptions.Find(Input_Form_Data.JobDescriptionId);

                ExistingEmployee.JobTitle = Input_Form_Data.JobTitle;
                ExistingEmployee.StartDate = Input_Form_Data.StartDate;
                ExistingEmployee.EndDate = Input_Form_Data.EndDate;

                appDbContext.JobDescriptions.Update(ExistingEmployee);
                appDbContext.SaveChanges();

                return Ok(ExistingEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Unknown Error: An error occurred while Updating JobDescription", Details = ex.Message });
            }
        }

    }
}
