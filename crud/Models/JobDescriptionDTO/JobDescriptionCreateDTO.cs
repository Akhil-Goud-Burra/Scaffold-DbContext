using System.ComponentModel.DataAnnotations;

namespace crud.Models.JobDescriptionDTO
{
    public class JobDescriptionCreateDTO
    {
        [Required]
        public string? JobTitle { get; set; }

        public DateTime StartDate { get; set; }

        public string? EndDate { get; set; }

        [Required]
        public int? EmployeeId { get; set; }
    }
}
